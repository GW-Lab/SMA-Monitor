' Program..: Modbus.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (Electricity)

' power, usage, Cost - T1, Cost - T2, Cost - gas, gas, L1Pimp, L1I, L1Pexp, L2Pimp, L2I, L3I, L2Pexp, L3Pimp, T1, T2, c_tariff, Cost - nT1, Cost - nT2, L3Pexp, gas_usage, -T1, -T2, import, solar, pulstotal, export, voltage

Imports Newtonsoft.Json

Public Class ModBuses : Inherits Dictionary(Of String, Modbus) ' Key => ModBus-Name
End Class

Public Class Modbus : Inherits Dictionary(Of String, DataLog) ' Key => prop 
   Private ReadOnly IBase As IungoBase
   Public ReadOnly Oid As String = ""
   Public ReadOnly prop As String = ""

   Public Name As String = ""

   Public Sub New(oid As String, prop As String, iBase As IungoBase)
      Me.IBase = iBase
      Me.Oid = oid
      Me.prop = prop

      Me.Name = JsonConvert.DeserializeObject(Of ObjectListPropsValuesJSON)(ObjListPropsValues()).Rv.Propsval(0).Value
   End Sub

   Private ReadOnly Property ObjListPropsValues() As String ' {"type":"response","time":0.013969507999718,"systime":1509965198,"error":{}}
      Get
         Return Me.IBase.ApiRequest("{""method"":""object_list_props_values"",""arguments"":{""oid"":""" + Me.Oid + """}}")
      End Get
   End Property
End Class