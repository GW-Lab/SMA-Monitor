' Program..: DatalogGetLastDailyValueBeforJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DatalogGetLastDailyValueBeforJSON)

Imports Newtonsoft.Json

Public Class DatalogGetLastDailyValueBeforeJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public Rv As RVValues
   Public [Error] As String
   Public Systime As UInteger

   Public Class RVValues
      Public Timestamp As UInteger
      Public Value As UInteger
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class
