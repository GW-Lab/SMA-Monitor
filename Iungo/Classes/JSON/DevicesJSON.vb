' Program..: DevicesJSON.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (DevicesJSON)
Imports Newtonsoft.Json

Public Class DevicesJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Time As UInt32
   Public Rv As RVValues
   Public [Error] As String
   Public Systime As UInteger

   Public Class RVValues
      Public Objects As List(Of Values)
   End Class

   Public Class Values
      Public Driver As String
      Public Name As String
      Public Oid As String
      Public Uid As String
      Public [Type] As String
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'{"ok":true,"type":"response","time":0.0032189729972742,"rv":{"objects":[
'{"driver":"alert-log","name":"-","oid":"20fa6711","uid":"log alerts","type":"alert"},
'{"driver":"bridge-zwave","name":"-","oid":"b8d4960b","uid":"via 1-1.3:1.1","type":"bridge"},
'{"driver":"energy-dsmr4","name":"Greenchoice","oid":"538d72d9","uid":"-","type":"energy"},
'{"driver":"energy-solar-sdm220-modbus","name":"Eastron sdm220","oid":"bef04aef","uid":"2","type":"solar"},
'{"driver":"bridge-modbus","name":"-","oid":"b9cb127f","uid":"via 1-1.2:1.0","type":"bridge"},
'{"driver":"button-gpio","name":"-","oid":"c430d9e0","uid":"button","type":"button"},
'{"driver":"clock","name":"Clock","oid":"ce9577e3","uid":"system clock","type":"clock"},
'{"driver":"bridge-zigbee","name":"-","oid":"fb979233","uid":"via 1-1.3:1.0","type":"bridge"},
'{"driver":"smartbridge-uart","name":"-","oid":"36c1fc52","uid":"\/dev\/ttyAPP:9600:e71","type":"bridge"},
'{"driver":"users","name":"admin","oid":"ebbe39cd","uid":"admin","type":"users"},
'{"driver":"bridge-usbuart","name":"-","oid":"ce7985b3","uid":"1-1.3:1.1;115200","type":"bridge"},
'{"driver":"powerswitch-zwave","name":"Sleeping Room TV","oid":"21b3cfd5","uid":"8278:5","type":"powerswitch"},
'{"driver":"alert-email","name":"Gijs Wassink","oid":"b4286b84","uid":"e-mail alerts","type":"alert"},
'{"driver":"powerswitch-zwave","name":"Living Room TV","oid":"27258ea1","uid":"8278:4","type":"powerswitch"},
'{"driver":"bridge-usbuart","name":"-","oid":"285b91de","uid":"1-1.3:1.0;19200","type":"bridge"},
'{"driver":"bridge-gpio","name":"-","oid":"b7bae611","uid":"39","type":"bridge"},
'{"driver":"powerswitch-zwave","name":"Koelkast","oid":"7439c1a7","uid":"8278:3","type":"powerswitch"},
'{"driver":"bridge-usbuart","name":"-","oid":"0cbea738","uid":"1-1.2:1.0;9600","type":"bridge"}]},"error":false,"systime":1509539351}

' solar bef04aef
