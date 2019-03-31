' Program..: DataLogGetJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DataLogGetJSON)
Imports Newtonsoft.Json

Public Class DataLogGetJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInteger
   Public [Error] As String
   Public Systime As UInteger

   Public Rv As RVValues

   Public Class RVValues
      Public Data As List(Of List(Of String))
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class
'{"ok":false,"type":"response","time":0.0069378769985633,"rv":false,"error":"start (1511782140) should be less than end (1511778540)","systime":1511778541}