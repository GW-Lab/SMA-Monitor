' Program..: IungoClient.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (IungoClient)

Imports System.Net

Public Class IungoClient : Inherits IungoBase
   Public Gas As Gas
   Public Electricity As Electricity
   Public Solar As Solar
   Public Status As ConnectionState
   Public ZWave As New ZWave
   Public Weather As Weather

#Region "Constructor"
   Public Sub New(ip As IPAddress)
      MyBase.New(ip)
      Dim dataloglistvalidlogs = New DataLogListValidLogs(Me).GetData.Rv.Logs

      Me.Electricity = New Electricity(dataloglistvalidlogs, Me)
      Me.Weather = New Weather(dataloglistvalidlogs, Me)

      For Each value In New ObjListObjectsLogProps(Me).GetData.Rv.Propsval
         Select Case value.Type
            Case "energy"
               For Each prop In value.Properties
                  If prop = "gas" Then
                     Me.Gas = New Gas(value.Oid, Me)
                  Else
                     Me.Electricity.Add(prop, New Device(value.Oid, prop, Me))
                  End If
               Next
            Case "powerswitch"
               For Each prop In value.Properties
                  Dim powerswitch = New PowerSwitch(value.Oid, Me)

                  If Not Me.ZWave.PowerSwitches.ContainsKey(powerswitch.Name) Then
                     Me.ZWave.PowerSwitches.Add(powerswitch.Name, powerswitch)
                  End If
               Next
            Case "solar"
               Me.Solar = New Solar(value.Oid, Me)
            Case "weather"
               For Each prop In value.Properties
                  Me.Weather.Add(prop, New Device(value.Oid, prop, Me))
               Next
         End Select
      Next

      Me.Status = If(Me.Electricity.Count > 0, ConnectionState.Open, ConnectionState.Closed)
   End Sub
#End Region

#Region "Remove all user settings and logs"
   Public Function Reboot() As String
      Return ApiRequest("{""method"":""fw_sys_reboot""}")
   End Function

   Public Function FwCleanData() As String
      Return ApiRequest("{""method"":""fw_clean_data""}")
   End Function
#End Region

   Public Shared Function ConvertUnixTimeStampToDate(value As Long) As Date
      Dim origin = New Date(1970, 1, 1, 0, 0, 0, 0)
      Return origin.AddSeconds(value)
   End Function

   Public Shared Function ConvertDateToUnixTimestamp(value As Date) As UInteger
      Dim span = value - New Date(1970, 1, 1, 0, 0, 0, 0)                                                                      ' create Timespan by subtracting the value provided from the Unix Epoch
      Return CUInt(span.TotalSeconds)                                                                                          ' return the total seconds (which is a UNIX timestamp)
   End Function
End Class
