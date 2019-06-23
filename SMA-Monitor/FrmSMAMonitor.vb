' Program..: FrmSMAMonitor.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0.1 .NET Framework 4.7.2
' Files....: None
' GitHub...: https://github.com/GW-Lab/SMA-Monitor.git
' Reserved.:This SOFTWARE PRODUCT is provided by THE PROVIDER "as is" and "with all faults." THE PROVIDER makes no representations or warranties of any kind concerning the safety,
'          : suitability, lack Of viruses, inaccuracies, typographical errors, Or other harmful components Of this SOFTWARE PRODUCT.
'          : There are inherent dangers In the use Of any software, And you are solely responsible For determining whether this SOFTWARE PRODUCT Is compatible With your equipment
'          : And other software installed On your equipment.
'          : You are also solely responsible For the protection Of your equipment And backup Of your data, And THE PROVIDER will Not be liable For any damages you may suffer In connection
'          : With Using, modifying, Or distributing this SOFTWARE PRODUCT.
'          : Free To use 

Imports GWModBus
Imports GWModBus.ModBusClient
Imports GWEnvilineClient

Public Class FrmSMAMonitor
   Const RemoveMSBMask As Byte = &B0111_1111
   Private SB3600TL As ModBusClient
   Private iungo As IungoClient

   Private WithEvents Enviline As EnvilineClient

   Private CurrDisplay As DisplayItem
   Private DisplayPower As Boolean = True

   Enum SB3600TLStatus As Integer
      Fault = 35
      Off = 303
      Ok = 307
      Warning = 455
   End Enum

   Enum DisplayItem
      Power             ' Not Used
      Ampere
      DailyYield
      Temp
      TotalYield
      Volt
   End Enum

   Enum SB3600TLOperatingStatus As Integer
      ConstantVoltage = 443
      Degrating = 2119
      Fault = 1392
      MPP = 295
      StandAloneOperation = 1855
      Start = 1467
      [Stop] = 381
      ShutDown = 1469
      WaitingForCompagnie = 1480
      WaitingForPVVoltage = 1393
   End Enum

   Private Sub FrmSB3600TLMonitor_Load() Handles Me.Load
      TopMost = My.Settings.TopMost
      Location = New Point(My.Settings.LocationX, My.Settings.LocationY)
      TmrMain.Interval = My.Settings.Interval * 1000

      Me.CurrDisplay = DisplayItem.Volt

      Try

         Me.SB3600TL = New ModBusClient(My.Settings.ModBusID, Net.IPAddress.Parse(My.Settings.IP_SMA), 502)
         Me.SB3600TL.Connect()

         Me.iungo = New IungoClient(Net.IPAddress.Parse(My.Settings.IP_Iungo))
         ' Me.iungo.ZWave.PowerSwitches("Iungo switch Name").State = PowerSwitch.PowerSwitchStatus.Off

         Enviline = New EnvilineClient
         Enviline.Send = EnvilineClient.Weather.Status

         LblStatusValue.BackColor = Color.Green
      Catch ex As Exception
         LblStatusValue.BackColor = Color.Red
      End Try

      ContextMenuStrip = CmsMain
   End Sub

   Private Sub FrmSB3600TLMonitor_Closing() Handles Me.Closing
      My.Settings.LocationX = Location.X
      My.Settings.LocationY = Location.Y

      Me.SB3600TL.Disconnect()
   End Sub

   Private Sub MnuSettings_Click(sender As Object, e As EventArgs) Handles MnuSettings.Click
      Dim frmSettings = New FrmSettings(Me)
      frmSettings.Show()
   End Sub

   Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
      Close()
   End Sub

   Private Sub TmrMain_TickAsync(sender As Object, e As EventArgs) Handles TmrMain.Tick
      Try
         Select Case ConvertToInt(Me.SB3600TL.ReadInputAsync(30201, 2))                                                                         ' Get Status from Inverter register number 30201
            Case SB3600TLStatus.Ok
               If Me.DisplayPower Then
                  LblStatusValue.BackColor = Color.Green

                  Dim power = Me.SB3600TL.ReadInputAsync(30775, 2)                                                                              ' 30775 True Power -> Alternative: 308805 reactive power or apperent power 30813
                  power(0) = power(0) And RemoveMSBMask                                                                                         ' Remove sign bit
                  LblSunPowerVal.Text = ConvertToInt(power).ToString()                                                                          ' Power in W(att)
                  LblUsedPowerVal.Text = (Me.iungo.SmartMeter("usage").Energy.Current + ConvertToInt(power)).ToString

                  Dim UnusedPowerTotal = CInt(LblSunPowerVal.Text) - CSng(LblUsedPowerVal.Text)
                  LblUsedPowerTotalVal.BackColor = If(UnusedPowerTotal >= 0, Color.LightGreen, Color.Red)
                  LblUsedPowerTotalVal.ForeColor = If(UnusedPowerTotal >= 0, Color.Black, Color.White)
                  LblUsedPowerTotalVal.Text = UnusedPowerTotal.ToString

                  If My.Settings.PVAutoHotWater Then
                     Enviline.Send = If(UnusedPowerTotal > My.Settings.PVTresholdWatt, EnvilineClient.Weather.Blue_Sky, EnvilineClient.Weather.Cloudy)
                  End If

                  Me.DisplayPower = False
               Else
                  Select Case Me.CurrDisplay
                     Case DisplayItem.Volt
                        Dim voltage = Me.SB3600TL.ReadInputAsync(30783, 2)                                                                      ' Get voltage from the inverter register number 30783
                        LblVoltageValue.Text = (ConvertToInt(voltage) / 100).ToString("#0.0")
                        Me.CurrDisplay = DisplayItem.Ampere
                     Case DisplayItem.Ampere
                        Dim ampere = Me.SB3600TL.ReadInputAsync(30795, 2)                                                                       ' Get ampere from the inverter register number 30795
                        LblAmpereValue.Text = (ConvertToInt(ampere) / 1000).ToString("#0.0")
                        Me.CurrDisplay = DisplayItem.Temp
                     Case DisplayItem.Temp
                        Dim temp = Me.SB3600TL.ReadInputAsync(34113, 2)                                                                         ' Get Temperature from the inverter register Number 34113 
                        ' Alternative: 30963
                        temp(0) = temp(0) And RemoveMSBMask                                                                                     ' Remove sign bit
                        LblTempCelsiusValue.Text = (ConvertToInt(temp) / 10).ToString("#0.0")
                        Me.CurrDisplay = DisplayItem.DailyYield
                     Case DisplayItem.DailyYield
                        LblDayYieldValue.Text = (ConvertToLong(Me.SB3600TL.ReadInputAsync(30517, 4)) / 1000).ToString("#0.00")                  ' Get Total-day-yield (kWh) from the inverter register Number 30517 
                        Me.CurrDisplay = DisplayItem.TotalYield
                     Case DisplayItem.TotalYield
                        LblTotalYieldValue.Text = (ConvertToLong(Me.SB3600TL.ReadInputAsync(30513, 4)) / 1000000).ToString("##0.00")            ' Get Total-yield (kWh) from the inverter register Number 30513 
                        Me.CurrDisplay = DisplayItem.Volt
                  End Select

                  Me.DisplayPower = True
               End If
            Case SB3600TLStatus.Fault
               LblStatusValue.BackColor = Color.Red
            Case SB3600TLStatus.Off
               LblStatusValue.BackColor = Color.Black
            Case SB3600TLStatus.Warning
               LblStatusValue.BackColor = Color.Yellow
         End Select

         Refresh()
      Catch ex As Exception
         LblStatusValue.BackColor = Color.Red
         LblSunPowerVal.Text = "0"
         LblTempCelsiusValue.Text = "0"
         LblDayYieldValue.Text = "0.0"
         LblTotalYieldValue.Text = "0.0"
      End Try
   End Sub

   Private Sub Enviline_Status_Changed(status As EnvilineClient.Weather) Handles Enviline.Status_Changed
      LblHotWaterValue.Visible = My.Settings.PVAutoHotWater
      LblHotWaterValue.BackColor = If(status = EnvilineClient.Weather.Blue_Sky, Color.Green, Color.Red)
   End Sub

   Private Sub LblHotWaterValue_Click(sender As Object, e As EventArgs) Handles LblHotWaterValue.Click   ' Force one-time to make Hot water
      Enviline.Send = EnvilineClient.Weather.Blue_Sky
   End Sub
End Class
