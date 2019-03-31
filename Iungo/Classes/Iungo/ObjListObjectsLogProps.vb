' Program..: ObjListObjectsLogProps.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (ObjListObjectsLogProps)

Imports Newtonsoft.Json

Public Class ObjListObjectsLogProps
   Private ReadOnly iBase As IungoBase

   Public Sub New(iBase As IungoBase)
      Me.iBase = iBase
   End Sub

   Public Function GetData() As ObjectListObjectsLogPropsJSON
      Return JsonConvert.DeserializeObject(Of ObjectListObjectsLogPropsJSON)(Me.iBase.ApiRequest("{""method"":""object_list_objects_log_props""}"))
   End Function
End Class

'{"ok":true,"type":"response","time":0.011969559000136,"rv":{"propsval":[
'{"properties":["usage","T1","T2","-T1","-T2","L1I","L2I","L3I","L1Pimp","L2Pimp","L3Pimp","L1Pexp","L2Pexp","L3Pexp","c_tariff","gas_usage","gas","Cost-T1","Cost-T2","Cost-nT1","Cost-nT2","Cost-gas"],"driver":"energy-dsmr4","type":"energy","oid":"538d72d9"},
'{"properties":["solar","voltage","pulstotal","import","export"],"driver":"energy-solar-sdm220-modbus","type":"solar","oid":"bef04aef"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"1907702f"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"7439c1a7"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"21b3cfd5"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"27258ea1"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"a5836a76"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"849a7431"}]},"error":false,"systime":1510084174}
