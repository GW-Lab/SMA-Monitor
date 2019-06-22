' Program..: SmartMeter.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (Electricity)

' power, usage, Cost - T1, Cost - T2, Cost - gas, gas, L1Pimp, L1I, L1Pexp, L2Pimp, L2I, L3I, L2Pexp, L3Pimp, T1, T2, c_tariff, Cost - nT1, Cost - nT2, L3Pexp, gas_usage, -T1, -T2, import, solar, pulstotal, export, voltage

Public Class SmartMeter : Inherits Dictionary(Of String, Data)
   Private ReadOnly iBase As IungoBase
   Public Data As DataLog

   Public Sub New(iBase As IungoBase)
      Me.iBase = iBase
   End Sub
End Class
'{"ok":true,"type":"response","time":0.00090629899932537,"rv":{"value":0},"error":false,"systime":1509791241}

'iod = 538d72d9 

'{"ok":true,
'"type""response",
'"time":0.027157790995261,
'"rv":{"propsval":[{"properties":["usage","T1","T2","-T1","-T2","L1I","L2I","L3I","L1Pimp","L2Pimp","L3Pimp","L1Pexp","L2Pexp","L3Pexp","c_tariff","gas_usage","gas","Cost-T1","Cost-T2","Cost-nT1","Cost-nT2","Cost-gas"],"driver":"energy-dsmr4","type":"energy","oid":"538d72d9"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"1907702f"},
'{"properties":["solar","voltage","pulstotal","import","export"],"driver":"energy-solar-sdm220-modbus","type":"solar","oid":"bef04aef"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"ea463852"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"849a7431"},
'{"properties":["usage","T1","-T1","Cost-T1","Cost-nT1"],"driver":"energymeter-sdm630-modbus","type":"modbusenergy","oid":"4bb2852a"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"27258ea1"},
'{"properties":["usage","T1","-T1","Cost-T1","Cost-nT1"],"driver":"energymeter-sdm630-modbus","type":"modbusenergy","oid":"9681dca5"},
'{"properties":["temp_current","humidity","windspeedMS","winddirection","airpressure","rain","solarintensity"],"driver":"weather-buienradar","type":"weather","oid":"e485ecc4"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"7439c1a7"},
'{"properties":["usage","power"],"driver":"powerswitch-zwave","type":"powerswitch","oid":"21b3cfd5"}]},
'"error":false,"systime":1561192586}