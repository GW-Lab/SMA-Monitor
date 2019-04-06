' Program..: PowerSwitch.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (PowerSwitch)

Imports Newtonsoft.Json
Public Class PowerSwitches : Inherits Dictionary(Of String, PowerSwitch)
End Class

Public Class PowerSwitch
   Private ReadOnly IBase As IungoBase
   Public ReadOnly Oid As String = ""

   Public Name As String = ""
   Public Energy As DataLog
   Public Power As DataLog

   Enum PowerSwitchEnum
      Usage = 0
      Power = 1
      State = 2
   End Enum

   Enum PowerSwitchStatus
      Off
      [On]
   End Enum

#Region "Constructor"
   Public Sub New(oid As String, iBase As IungoBase)
      Me.IBase = iBase
      Me.Oid = oid
      Me.Name = JsonConvert.DeserializeObject(Of ObjectListPropsValuesJSON)(ObjListPropsValues()).Rv.Propsval(0).Value

      Me.Energy = New DataLog(oid, "usage", iBase)
      Me.Power = New DataLog(oid, "power", iBase)
   End Sub
#End Region

   Public Property State As PowerSwitchStatus
      Get
         Return If(JsonConvert.DeserializeObject(Of PowerSwitchOnOffJSON)(Me.IBase.ObjectPropGet(Me.Oid, PowerSwitchEnum.State.ToString)).Rv.Value = "on", PowerSwitchStatus.On, PowerSwitchStatus.Off)
      End Get
      Set(value As PowerSwitchStatus)
         Dim dummy = ObjPropSet(value)
      End Set
   End Property

   Private ReadOnly Property ObjListPropsValues() As String ' {"type":"response","time":0.013969507999718,"systime":1509965198,"error":{}}
      Get
         Return Me.IBase.ApiRequest("{""method"":""object_list_props_values"",""arguments"":{""oid"":""" + Me.Oid + """}}")
      End Get
   End Property

   Private ReadOnly Property ObjPropSet(cmd As PowerSwitchStatus) As String ' {"type":"response","time":0.013969507999718,"systime":1509965198,"error":{}}
      Get
         Return Me.IBase.ObjectPropSet(Me.Oid, "command", cmd.ToString.ToLower)
         '"{""method"":""object_prop_set"",""arguments"":{""oid"":""" + Me.oid + """,""prop"":""command"",""value"":""" + cmd.ToString + """}}"
      End Get
   End Property
End Class

