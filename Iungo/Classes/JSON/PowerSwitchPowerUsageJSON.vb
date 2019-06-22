' Program..: PowerSwitchPowerAndUsageJSON.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (PowerSwitchPowerAndUsageJSON)
Imports Newtonsoft.Json

Public Class PowerSwitchPowerUsageJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public [Error] As String
   Public Rv As RVValue
   Public Systime As UInteger

   Public Class RVValue
      Public Value As Double
   End Class
   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'{"ok":true,"type":"response","time":0.00059378099103924,"rv":{"value":9.84},"error":false,"systime":1509487437}