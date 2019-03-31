' Program..: SolarJSON.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (SolarJSON)
Imports Newtonsoft.Json

Public Class SolarJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public Rv As RVValues
   Public [Error] As Boolean
   Public Systime As UInteger

   Public Class RVValues
      Public [Error] As Boolean
      Public Systime As ULong
      Public Value As UInteger
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

' {"ok":true,"type":"response","time":0.00037501999759115,"rv":{"value":0},"error":false,"systime":1509482305}