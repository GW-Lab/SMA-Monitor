' Program..: DataLogListValidLogs.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DataLogListValidLogs)

Imports Newtonsoft.Json

Public Class DataLogListValidLogs : Inherits Dictionary(Of String, DataLog)
   Private ReadOnly iBase As IungoBase

   Public Sub New(iBase As IungoBase)
      Me.iBase = iBase

      For Each log In GetData.rv.Logs
         If Not ContainsKey(log.Prop) Then Add(log.Prop, New DataLog(log.Oid, log.Prop, iBase))
      Next
   End Sub

   Public Function GetData() As DataLogListValidLogsJSON
      Try
         Return JsonConvert.DeserializeObject(Of DataLogListValidLogsJSON)(Me.iBase.ApiRequest("{""method"":""datalog_list_valid_logs""}"))
      Catch ex As Exception
         Return New DataLogListValidLogsJSON
      End Try
   End Function
End Class
'{"ok":true,"type":"response","time":0.10831994609907,"rv":{"logs":[{"prop":"import","oid":"ae587066"},{"prop":"solar","oid":"ae587066"},{"prop":"pulstotal","oid":"ae587066"},{"prop":"L1P","oid":"ae587066"},{"prop":"L2P","oid":"ae587066"},{"prop":"L3P","oid":"ae587066"},{"prop":"export","oid":"ae587066"},{"prop":"Cost-T1","oid":"7bbf70c3"},{"prop":"Cost-T2","oid":"7bbf70c3"},{"prop":"Cost-gas","oid":"7bbf70c3"},{"prop":"Cost-nT1","oid":"7bbf70c3"},{"prop":"Cost-nT2","oid":"7bbf70c3"},{"prop":"power","oid":"5ff7f06c"},{"prop":"usage","oid":"5ff7f06c"},{"prop":"L1Pimp","oid":"538d72d9"},{"prop":"L1I","oid":"538d72d9"},{"prop":"L1Pexp","oid":"538d72d9"},{"prop":"L2Pimp","oid":"538d72d9"},{"prop":"L2I","oid":"538d72d9"},{"prop":"L3I","oid":"538d72d9"},{"prop":"L2Pexp","oid":"538d72d9"},{"prop":"L3Pimp","oid":"538d72d9"},{"prop":"usage","oid":"538d72d9"},{"prop":"Cost-T1","oid":"538d72d9"},{"prop":"Cost-T2","oid":"538d72d9"},{"prop":"Cost-gas","oid":"538d72d9"},{"prop":"T1","oid":"538d72d9"},{"prop":"T2","oid":"538d72d9"},{"prop":"c_tariff","oid":"538d72d9"},{"prop":"Cost-nT1","oid":"538d72d9"},{"prop":"Cost-nT2","oid":"538d72d9"},{"prop":"gas","oid":"538d72d9"},{"prop":"L3Pexp","oid":"538d72d9"},{"prop":"gas_usage","oid":"538d72d9"},{"prop":"-T1","oid":"538d72d9"},{"prop":"-T2","oid":"538d72d9"}]},"error":false,"systime":1509573384}

'{"ok"true,"type""response","time":0.14344741497189,"rv":{"logs":
'[{"prop":"import","oid":"ae587066"},
'{"prop":"solar","oid":"ae587066"},
'{"prop":"pulstotal","oid":"ae587066"},
'{"prop":"L1P","oid":"ae587066"},
'{"prop":"L2P","oid":"ae587066"},
'{"prop":"L3P","oid":"ae587066"},
'{"prop":"export","oid":"ae587066"},

'{"prop":"Cost-T1","oid":"7bbf70c3"},
'{"prop":"Cost-T2","oid":"7bbf70c3"},
'{"prop":"Cost-gas","oid":"7bbf70c3"},
'{"prop":"Cost-nT1","oid":"7bbf70c3"},
'{"prop":"Cost-nT2","oid":"7bbf70c3"},

'{"prop":"power","oid":"5ff7f06c"},
'{"prop":"usage","oid":"5ff7f06c"},

'{"prop":"L1Pimp","oid":"538d72d9"},
'{"prop":"L1I","oid":"538d72d9"},
'{"prop":"L1Pexp","oid":"538d72d9"},
'{"prop":"L2Pimp","oid":"538d72d9"},
'{"prop":"L2I","oid":"538d72d9"},
'{"prop":"L3I","oid":"538d72d9"},
'{"prop":"L2Pexp","oid":"538d72d9"},
'{"prop":"L3Pimp","oid":"538d72d9"},
'{"prop":"usage","oid":"538d72d9"},
'{"prop":"Cost-T1","oid":"538d72d9"},
'{"prop":"Cost-T2","oid":"538d72d9"},
'{"prop":"Cost-gas","oid":"538d72d9"},
'{"prop":"T1","oid":"538d72d9"},
'{"prop":"T2","oid":"538d72d9"},
'{"prop":"c_tariff","oid":"538d72d9"}
',{"prop":"Cost-nT1","oid":"538d72d9"},
'{"prop":"Cost-nT2","oid":"538d72d9"},
'{"prop":"gas","oid":"538d72d9"},
'{"prop":"L3Pexp","oid":"538d72d9"},
'{"prop":"gas_usage","oid":"538d72d9"},
'{"prop":"-T1","oid":"538d72d9"},
'{"prop":"-T2","oid":"538d72d9"}]},

'"error":false,"systime":1511988870}