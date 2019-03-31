' Program..: Electricity.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (Electricity)

' power, usage, Cost - T1, Cost - T2, Cost - gas, gas, L1Pimp, L1I, L1Pexp, L2Pimp, L2I, L3I, L2Pexp, L3Pimp, T1, T2, c_tariff, Cost - nT1, Cost - nT2, L3Pexp, gas_usage, -T1, -T2, import, solar, pulstotal, export, voltage

Public Class Electricity : Inherits Dictionary(Of String, Device)
   Public EnergyT181 As DataLog
   Public EnergyT182 As DataLog
   Public EnergyT281 As DataLog
   Public EnergyT282 As DataLog

   ' Public Power As DataLog
   Public Sub New(dataLogListValidLogs As List(Of DataLogListValidLogsJSON.Values), iBase As IungoBase)
      Me.EnergyT181 = New DataLog(dataLogListValidLogs.First(Function(log) log.Prop = "T1").Oid, "T1", iBase)
      Me.EnergyT182 = New DataLog(dataLogListValidLogs.First(Function(log) log.Prop = "T2").Oid, "T2", iBase)
      Me.EnergyT281 = New DataLog(dataLogListValidLogs.First(Function(log) log.Prop = "-T1").Oid, "-T1", iBase)
      Me.EnergyT282 = New DataLog(dataLogListValidLogs.First(Function(log) log.Prop = "-T2").Oid, "-T2", iBase)
   End Sub
End Class

'{"ok":true,"type":"response","time":0.00090629899932537,"rv":{"value":0},"error":false,"systime":1509791241}

'iod = 538d72d9 

'1         "prop": "power",
'         "oid": "57838165"
'2         "prop": "usage",
'         "oid": "57838165"
'3         "prop": "power",
'         "oid": "a5836a76"
'4         "prop": "usage",
'         "oid": "a5836a76"
'5         "prop": "power",
'         "oid": "1907702f"
'6         "prop": "usage",
'         "oid": "1907702f"
'7         "prop": "Cost-T1",
'         "oid": "2204995f"
'8         "prop": "Cost-T2",
'         "oid": "2204995f"
'9         "prop": "Cost-gas",
'         "oid": "2204995f"
'10         "prop": "gas",
'         "oid": "2204995f"
'11         "prop": "power",
'         "oid": "27258ea1"
'12         "prop": "usage",
'         "oid": "27258ea1"
'13         "prop": "power",
'         "oid": "21b3cfd5"
'         "prop": "usage",
'14         "oid": "21b3cfd5"
'         "prop": "power",
'         "oid": "849a7431"
'15         "prop": "usage",
'         "oid": "849a7431"
'         "prop": "power",
'16         "oid": "7439c1a7"
'         "prop": "usage",
'17         "oid": "7439c1a7"
'         "prop": "L1Pimp",
'         "oid": "538d72d9"
'18         "prop": "L1I",
'         "oid": "538d72d9"
'19         "prop": "L1Pexp",
'         "oid": "538d72d9"
'         "prop": "L2Pimp",
'         "oid": "538d72d9"
'         "prop": "L2I",
'         "oid": "538d72d9"
'         "prop": "L3I",
'         "oid": "538d72d9"
'         "prop": "L2Pexp",
'         "oid": "538d72d9"
'         "prop": "L3Pimp",
'         "oid": "538d72d9"
'         "prop": "usage",
'         "oid": "538d72d9"
'         "prop": "Cost-T1",
'         "oid": "538d72d9"
'         "prop": "Cost-T2",
'         "oid": "538d72d9"
'         "prop": "Cost-gas",
'         "oid": "538d72d9"
'         "prop": "T1",
'         "oid": "538d72d9"
'         "prop": "T2",
'         "oid": "538d72d9"
'         "prop": "c_tariff",
'         "oid": "538d72d9"
'         "prop": "Cost-nT1",
'         "oid": "538d72d9"
'         "prop": "Cost-nT2",
'         "oid": "538d72d9"
'         "prop": "gas",
'         "oid": "538d72d9"
'         "prop": "L3Pexp",
'         "oid": "538d72d9"
'         "prop": "gas_usage",
'         "oid": "538d72d9"
'         "prop": "-T1",
'         "oid": "538d72d9"
'         "prop": "-T2",
'         "oid": "538d72d9"
'         "prop": "import",
'         "oid": "bef04aef"
'         "prop": "solar",
'         "oid": "bef04aef"
'         "prop": "pulstotal",
'         "oid": "bef04aef"
'         "prop": "export",
'         "oid": "bef04aef"
'         "prop": "voltage",
'         "oid": "bef04aef"
