' Program..: IungoClient.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (IungoClient)

Imports System.Net

Public Class IungoClient : Inherits IungoBase
   Public ModBuses As New ModBuses
   Public SmartMeter As SmartMeter
   Public Solar As Solar
   Public Status As ConnectionState
   Public ZWaveSwitches As New ZWaveSwitches
   Public Weather As Weather
   Public Sub New(ip As IPAddress)
      MyBase.New(ip)
      Dim dataloglistvalidlogs = New DataLogListValidLogs(Me).GetData.Rv.Logs

      Me.SmartMeter = New SmartMeter(Me)
      Me.Weather = New Weather(dataloglistvalidlogs, Me)

      For Each value In New ObjListObjectsLogProps(Me).GetData.Rv.Propsval
         Select Case value.Type
            Case "energy"     ' SmartMeter
               For Each prop In value.Properties
                  Me.SmartMeter.Add(prop, New Data(value.Oid, prop, Me))
               Next
            Case "modbusenergy"
               For Each prop In value.Properties
                  Dim modbus = New Modbus(value.Oid, prop, Me)

                  If Me.ModBuses.ContainsKey(modbus.Name) Then
                     Me.ModBuses(modbus.Name).Add(prop, New DataLog(value.Oid, prop, Me))
                  Else
                     Me.ModBuses.Add(modbus.Name, modbus)
                  End If
               Next
            Case "powerswitch"
               For Each prop In value.Properties
                  Dim powerswitch = New ZWaveSwitches.PowerSwitch(value.Oid, prop, Me)

                  If Me.ZWaveSwitches.ContainsKey(powerswitch.Name) Then
                     Me.ZWaveSwitches(powerswitch.Name).Add(prop, New DataLog(value.Oid, prop, Me))
                  Else
                     Me.ZWaveSwitches.Add(powerswitch.Name, powerswitch)
                  End If
               Next
            Case "solar"
               Me.Solar = New Solar(value.Oid, Me)
            Case "weather"
               For Each prop In value.Properties
                  Me.Weather.Add(prop, New Data(value.Oid, prop, Me))
               Next
         End Select
      Next

      Me.Status = If(Me.SmartMeter.Count > 0, ConnectionState.Open, ConnectionState.Closed)
   End Sub

#Region "Remove all user settings and logs"
   Public Function Reboot() As String
      Return ApiRequest("{""method"":""fw_sys_reboot""}")
   End Function
   Public Function FwCleanData() As String
      Return ApiRequest("{""method"":""fw_clean_data""}")
   End Function
#End Region
   Public Shared Function ConvertTimeStampToDate(value As Long) As Date
      Dim origin = New Date(1970, 1, 1, 0, 0, 0, 0)
      Return origin.AddSeconds(value)
   End Function
   Public Shared Function ConvertDateToUnixTimestamp(value As Date) As UInteger
      Dim span = value - New Date(1970, 1, 1, 0, 0, 0, 0)                                                                      ' create Timespan by subtracting the value provided from the Unix Epoch
      Return CUInt(span.TotalSeconds)                                                                                          ' return the total seconds (which is a UNIX timestamp)
   End Function
End Class
