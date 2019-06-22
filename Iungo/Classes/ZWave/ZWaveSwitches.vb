' Program..: ZWaveSwitches.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (ZWave)
Imports Newtonsoft.Json

Public Class ZWaveSwitches : Inherits Dictionary(Of String, PowerSwitch)

   Public Class PowerSwitch : Inherits Dictionary(Of String, DataLog)
      Private ReadOnly IBase As IungoBase
      Public ReadOnly Oid As String = ""
      Public ReadOnly Prop As String = ""

      Public Name As String = ""
      Enum PowerSwitchEnum
         Usage = 0
         Power = 1
         State = 2
      End Enum
      Enum PowerSwitchOnOff
         Off
         [On]
      End Enum
      Public Sub New(oid As String, prop As String, iBase As IungoBase)
         Me.IBase = iBase
         Me.Oid = oid
         Me.Prop = prop

         Me.Name = JsonConvert.DeserializeObject(Of ObjectListPropsValuesJSON)(ObjListPropsValues()).Rv.Propsval(0).Value
      End Sub
      Public Property State As PowerSwitchOnOff
         Get
            Return If(JsonConvert.DeserializeObject(Of PowerSwitchOnOffJSON)(Me.IBase.ObjectPropGet(Me.Oid, PowerSwitchEnum.State.ToString)).Rv.Value = "on", PowerSwitchOnOff.On, PowerSwitchOnOff.Off)
         End Get
         Set(value As PowerSwitchOnOff)
            Dim dummy = ObjPropSet(value)
         End Set
      End Property
      Private ReadOnly Property ObjListPropsValues() As String ' {"type":"response","time":0.013969507999718,"systime":1509965198,"error":{}}
         Get
            Return Me.IBase.ApiRequest("{""method"":""object_list_props_values"",""arguments"":{""oid"":""" + Me.Oid + """}}")
         End Get
      End Property
      Private ReadOnly Property ObjPropSet(cmd As PowerSwitchOnOff) As String ' {"type":"response","time":0.013969507999718,"systime":1509965198,"error":{}}
         Get
            Return Me.IBase.ObjectPropSet(Me.Oid, "command", cmd.ToString.ToLower)
            '"{""method"":""object_prop_set"",""arguments"":{""oid"":""" + Me.oid + """,""prop"":""command"",""value"":""" + cmd.ToString + """}}"
         End Get
      End Property
   End Class



End Class

