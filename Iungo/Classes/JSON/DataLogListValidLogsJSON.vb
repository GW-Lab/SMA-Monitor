' Program..: DataLogListValidLogsJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DataLogListValidLogsJSON)
Imports Newtonsoft.Json

Public Class DataLogListValidLogsJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public Rv As RVValues
   Public [Error] As String
   Public Systime As UInteger

   Public Class RVValues
      Public Logs As List(Of Values)
   End Class

   Public Class Values
      Public Prop As String
      Public Oid As String
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'{"ok":true,"type":"response","time":0.10831994609907,'"rv":{"logs":
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
'{"prop""usage","oid":"5ff7f06c"},
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
'{"prop":"c_tariff","oid":"538d72d9"},
'{"prop""Cost-nT1","oid":"538d72d9"},
'{"prop":"Cost-nT2","oid":"538d72d9"},
'{"prop":"gas","oid":"538d72d9"},
'{"prop":"L3Pexp","oid":"538d72d9"},
'{"prop":"gas_usage","oid":"538d72d9"},
'{"prop":"-T1","oid":"538d72d9"},
'{"prop":"-T2","oid":"538d72d9"}]},
'"error":false,"systime":1509573384}

