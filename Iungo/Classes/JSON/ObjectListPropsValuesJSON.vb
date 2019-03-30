' Program..: ObjectListPropsValuesJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (ObjectListPropsValuesJSON)
Imports Newtonsoft.Json

Public Class ObjectListPropsValuesJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInt32
   Public Rv As RVValues
   Public [Error] As String
   Public Systime As UInteger

   Public Class RVValues
      Public Propsval As List(Of Values)
   End Class

   Public Class Values
      Public Id As String
      Public Value As String
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'{"ok"true,"type":"response","time":0.0016251160000138,"rv":{"propsval":[
'{"id":"name","value":"Bedroom IR Panel"},
'{"id":"state","value":"off"},{"id":"usage","value":0},
'{"id":"power","value":0},
'{"id":"classes","value":"{0x5e ,0x22 ,0x85 ,0x59 ,0x70 ,0x56 ,0x5a ,0x7a ,0x72 ,0x32 ,0x8e ,0x71 ,0x73 ,0x98 ,0x31 ,0x25 ,0x86 }"},
'{"id":"hidden","value":false},
'{"id":"available","value":true}]},
'"error":false,"systime":1510082251}
