' Program..: FrmSMAMonitor.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.:This SOFTWARE PRODUCT is provided by THE PROVIDER "as is" and "with all faults." THE PROVIDER makes no representations or warranties of any kind concerning the safety,
'          : suitability, lack Of viruses, inaccuracies, typographical errors, Or other harmful components Of this SOFTWARE PRODUCT.
'          : There are inherent dangers In the use Of any software, And you are solely responsible For determining whether this SOFTWARE PRODUCT Is compatible With your equipment
'          : And other software installed On your equipment.
'          : You are also solely responsible For the protection Of your equipment And backup Of your data, And THE PROVIDER will Not be liable For any damages you may suffer In connection
'          : With Using, modifying, Or distributing this SOFTWARE PRODUCT.
'          : Free To use 

Imports GWModBus
Imports GWModBus.ModBusClient
Imports GWIungo

Public Class FrmSMAMonitor
   Private ReadOnly RemoveSignBitmask As Byte = &B0111_1111
   Private frmSettings As FrmSettings

   Private SB3600TL As ModBusClient
   Private iungo As IungoClient

   Private Display As DisplayItem
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
      DaylyYield
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

      Me.Display = DisplayItem.Volt

      Try
         Me.iungo = New IungoClient(New Net.IPAddress({192, 168, 2, 122}))
         LblStatusValue.BackColor = Color.Green
      Catch ex As Exception
         LblStatusValue.BackColor = Color.Red
         Me.SB3600TL.Dispose()
      End Try

      ContextMenuStrip = CmsMain
   End Sub

   Private Sub FrmSB3600TLMonitor_Closing() Handles Me.Closing
      My.Settings.LocationX = Location.X
      My.Settings.LocationY = Location.Y
      TmrMain.Interval = My.Settings.Interval

      Me.SB3600TL.Disconnect()
   End Sub

   Private Async Sub TmrMain_TickAsync(sender As Object, e As EventArgs) Handles TmrMain.Tick
      Try
         Me.SB3600TL = New ModBusClient(My.Settings.ModBusID, Net.IPAddress.Parse(My.Settings.IPAddress), 502)
         Me.SB3600TL.Connect()

         Select Case ConvertRegistersToInt(Await Me.SB3600TL.ReadInputRegistersAsync(30201, 2))
            Case SB3600TLStatus.Ok
               LblStatusValue.BackColor = Color.Green

               If Me.DisplayPower Then
                  Dim power = Await Me.SB3600TL.ReadInputRegistersAsync(30775, 2)                                                                              ' 30775 True Power -> Alternative: 308805 reactive power or apperent power 30813

                  power(0) = power(0) And Me.RemoveSignBitmask                                                                                                 ' Remove sign bit
                  LblSunPowerVal.Text = ConvertRegistersToInt(power).ToString()                                                                                 ' Power in W(att)

                  '     LblUsedPowerVal.Text = (Me.iungo.Electricity("usage").Energy.Current + ConvertRegistersToInt(power)).ToString

                  Dim totalUsedPower = CInt(LblSunPowerVal.Text) - CDbl(LblUsedPowerVal.Text)

                  LblUsedPowerTotalVal.BackColor = If(totalUsedPower >= 0, Color.LightGreen, Color.Red)
                  LblUsedPowerTotalVal.ForeColor = If(totalUsedPower >= 0, Color.Black, Color.White)
                  LblUsedPowerTotalVal.Text = totalUsedPower.ToString

                  LblSunPowerVal.Refresh()
                  Me.DisplayPower = False
               Else
                  Select Case Me.Display
                     Case DisplayItem.Volt
                        Dim voltage = Await Me.SB3600TL.ReadInputRegistersAsync(30783, 2)
                        '   voltage(0) = voltage(0) And Me.RemoveSignBitmask
                        LblVoltageValue.Text = (ConvertRegistersToInt(voltage) / 100).ToString("#0.0")
                        Me.Display = DisplayItem.Ampere
                     Case DisplayItem.Ampere
                        Dim ampere = Await Me.SB3600TL.ReadInputRegistersAsync(30795, 2)
                        '   ampere(0) = ampere(0) And Me.RemoveSignBitmask
                        LblAmpereValue.Text = (ConvertRegistersToInt(ampere) / 1000).ToString("#0.0")
                        Me.Display = DisplayItem.Temp
                     Case DisplayItem.Temp
                        Dim temp = Await Me.SB3600TL.ReadInputRegistersAsync(34113, 2)
                        ' Alternative: 30963
                        temp(0) = temp(0) And Me.RemoveSignBitmask                                                                                             ' Remove sign bit
                        LblTempCelsiusValue.Text = (ConvertRegistersToInt(temp) / 10).ToString("#0.0")
                        Me.Display = DisplayItem.DaylyYield
                     Case DisplayItem.DaylyYield
                        LblDayYieldValue.Text = (ConvertRegistersToLong(Await Me.SB3600TL.ReadInputRegistersAsync(30517, 4)) / 1000).ToString("#0.00")         ' kWh 
                        Me.Display = DisplayItem.TotalYield
                     Case DisplayItem.TotalYield
                        LblTotalYieldValue.Text = (ConvertRegistersToLong(Await Me.SB3600TL.ReadInputRegistersAsync(30513, 4)) / 1000000).ToString("##0.00")  ' MWh
                        Me.Display = DisplayItem.Volt
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

         Me.SB3600TL.Close()
      Catch ex As Exception
         LblStatusValue.BackColor = Color.Red
         LblSunPowerVal.Text = "0"
         LblTempCelsiusValue.Text = "0"
         LblDayYieldValue.Text = "0.0"
         LblTotalYieldValue.Text = "0.0"
      End Try
   End Sub

   Private Sub MnuSettings_Click(sender As Object, e As EventArgs) Handles MnuSettings.Click
      Me.frmSettings = New FrmSettings(Me)
      Me.frmSettings.Show(Me)
   End Sub

   Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
      Close()
   End Sub
End Class
