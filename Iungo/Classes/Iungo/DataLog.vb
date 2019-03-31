' power, usage, Cost-T1, Cost-T2, Cost-gas, gas, L1Pimp, L1I, L1Pexp, L2Pimp, L2I, L3I, L2Pexp, L3Pimp, T1, T2, c_tariff, Cost-nT1, Cost-nT2, L3Pexp, gas_usage, -T1, -T2, import, solar, pulstotal, export, voltage
' Program..: DataLog.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DataLog)

Imports Newtonsoft.Json

Public Class DataLog
   Private ReadOnly iBase As IungoBase
   Private ReadOnly oid As String
   Private ReadOnly prop As String

   Public Sub New(oid As String, prop As String, iBase As IungoBase)
      Me.iBase = iBase
      Me.oid = oid
      Me.prop = prop
   End Sub

   Public ReadOnly Property Current As Double
      Get
         Return JsonConvert.DeserializeObject(Of PowerSwitchPowerUsageJSON)(Me.iBase.ObjectPropGet(Me.oid, Me.prop)).Rv.Value
      End Get
   End Property

   Public ReadOnly Property GetFirstDateTimeStamp As UInteger
      Get
         Return CUInt(Me.iBase.DataLogGetFirst(Me.oid, Me.prop).Item(0).Item(0))
      End Get
   End Property

   Public ReadOnly Property GetLastDateTimeStamp As UInteger
      Get
         Return CUInt(Me.iBase.DataLogGetLast(Me.oid, Me.prop).Item(0).Item(0))
      End Get
   End Property

   Public Function Values(t1 As Date, t2 As Date, Optional resolution As Integer = 600) As DataLogCSVJSON
      Dim steps = 0
      Dim obj = JsonConvert.DeserializeObject(Of DataLogCSVJSON)(Me.iBase.ApiRequest("{""method"":""datalog_get"",""arguments"":{""prop"":""" + Me.prop +
                                                                                     """,""oid"":""" + Me.oid +
                                                                                     """,""steps"":""" + steps.ToString +
                                                                                     """,""resolution"":""" + resolution.ToString +
                                                                                     """,""t1"":""" + IungoClient.ConvertDateToUnixTimestamp(t1).ToString +
                                                                                     """,""t2"":""" + IungoClient.ConvertDateToUnixTimestamp(t2).ToString + """}}"))
      Select Case Me.prop
         Case "humidity", "rain", "solarintensity", "temp_current", "winddirection", "windspeedMS"
            For Each item In obj.rv.Data
               If item.Count = 1 Then
                  item.Add(0)     ' if Only dateTimeStamp is present then add the 0 value  
               End If
            Next
         Case "airpressure", "T1", "T2", "-T1", "-T2", "gas", "pulstotal", "water"
            For Each item In obj.rv.Data
               If item.Count = 1 Then
                  item.Add(0)
               End If
            Next

            For ndx = 0 To obj.rv.Data.Count - 2
               If obj.rv.Data(ndx).Item(1) > obj.rv.Data(ndx + 1).Item(1) Then
                  obj.rv.Data(ndx + 1).Item(1) = obj.rv.Data(ndx).Item(1)
               End If
            Next
      End Select

      Return obj
   End Function

   Public Function Values(t1TimeStamp As UInteger, t2TimeStamp As UInteger, Optional resolution As Integer = 600) As DataLogCSVJSON
      Dim steps = 0
      Dim obj = JsonConvert.DeserializeObject(Of DataLogCSVJSON)(Me.iBase.ApiRequest("{""method"":""datalog_get"",""arguments"":{""prop"":""" + Me.prop +
                                                                                     """,""oid"":""" + Me.oid +
                                                                                     """,""steps"":""" + steps.ToString +
                                                                                     """,""resolution"":""" + resolution.ToString +
                                                                                     """,""t1"":""" + t1TimeStamp.ToString +
                                                                                     """,""t2"":""" + t2TimeStamp.ToString + """}}"))
      Select Case Me.prop
         Case "humidity", "rain", "solarintensit", "tempcurrent", "winddirection", "windspeedMS"
            For Each item In obj.rv.Data
               If item.Count = 1 Then
                  item.Add(0)     ' if Only dateTimeStamp is present then add the 0 value  
               End If
            Next
         Case "airpressure", "T1", "T2", "-T1", "-T2"
            For Each item In obj.rv.Data
               If item.Count = 1 Then
                  item.Add(0)
               End If
            Next

            For ndx = 0 To obj.rv.Data.Count - 2
               If obj.rv.Data(ndx).Item(1) > obj.rv.Data(ndx + 1).Item(1) Then
                  obj.rv.Data(ndx + 1).Item(1) = obj.rv.Data(ndx).Item(1)
               End If
            Next
         Case ""
      End Select

      Return obj
   End Function
End Class
'api_method_info
'Detailed info For given method

'method:  Method name(mandatory)

'Call method

'{
'   "arguments": {
'      "t2": {
'         "type": "number",
'         "description": "End timestamp",
'         "mandatory": true
'      },
'      "t1": {
'         "type": "number",
'         "description": "Start timestamp",
'         "mandatory": true
'      },
'      "oid": {
'         "type": "string",
'         "description": "Object ID",
'         "mandatory": true
'      },
'      "steps": {
'         "type": "number",
'         "description": "Number of steps",
'         "mandatory": false
'      },
'      "resolution": {
'         "type": "number",
'         "description": "Resolution",
'         "mandatory": false
'      },
'      "aggregate": {
'         "type": "string",
'         "description": "Aggretagion function (AVERAGE/MIN/MAX)",
'         "mandatory": false
'      },
'      "prop": {
'         "type": "boolean",
'         "description": "Property name",
'         "mandatory": true
'      }
'   },
'   "description": "Get datalog from property",
'   "auth": {
'      "any": true
'   }
'}
