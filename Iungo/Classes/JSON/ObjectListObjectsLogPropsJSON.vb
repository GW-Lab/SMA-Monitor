' Program..: ObjectListObjectsLogPropsJSON.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (ObjectListObjectsLogPropsJSON)
Imports Newtonsoft.Json

Public Class ObjectListObjectsLogPropsJSON
   Public Ok As Boolean
   Public [Type] As String
   Public Rv As RVValuesLevel0
   Public [Error] As String
   Public Systime As UInteger

   Public Class RVValuesLevel0
      Public Propsval As List(Of RVValuesLevel1)
   End Class

   Public Class RVValuesLevel1
      Public Properties As List(Of String)
      Public Driver As String
      Public Type As String
      Public Oid As String
   End Class

   Public Function ToJsonString() As String
      Return JsonConvert.SerializeObject(Me)
   End Function
End Class

'object_list_objects_log_props
'List all properties that have logging enabled

'{"ok"true,"type":"response","time":0.013469486999384,'"rv":{"propsval":
'[{"properties":["usage","T1","T2","-T1","-T2","L1I","L2I","L3I","L1Pimp","L2Pimp","L3Pimp","L1Pexp","L2Pexp","L3Pexp","c_tariff","gas_usage","gas","Cost-T1","Cost-T2","Cost-nT1","Cost-nT2","Cost-gas"],'"driver":"energy-dsmr4","type":"energy","oid":"538d72d9"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"1907702f"},
'{"properties":["solar","voltage","pulstotal","import","export"],"driver":"energy-solar-sdm220-modbus","type":"solar","oid":"bef04aef"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"849a7431"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"21b3cfd5"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"7439c1a7"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"27258ea1"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"a5836a76"}]},"error":false,"systime":1510061725}