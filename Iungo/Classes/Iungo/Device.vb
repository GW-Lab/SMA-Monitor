' Program..: Device.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (Device)

Imports Newtonsoft.Json

Public Class Device
   Private ReadOnly GWI As IungoBase
   Public ReadOnly oid As String
   Private ReadOnly prop As String

   Public Power As DataLog
   Public Energy As DataLog

   Enum DeviceFilter As Integer
      alert
      bridge
      button
      clock
      energy
      powerswitch
      solar
      users
   End Enum
   ' - prop -
   '   T1
   '   T2
   '   -T1
   '   -T2
   '   L1I
   '   L2I
   '   L3I
   '   L1Pimp
   '   L2Pimp
   '   L3Pimp
   '   L1Pexp
   '   L2Pexp
   '   L3Pexp
   '   c_tariff
   '   gas_usage
   '   gas
   '   Cost-T1
   '   Cost-T2
   '   Cost-nT1
   '   Cost-nT2
   '   Cost-gas

   Public Sub New(oid As String, prop As String, iBase As IungoBase)
      Me.GWI = iBase
      Me.oid = oid
      Me.prop = prop

      Me.Power = New DataLog(oid, "power", iBase)
      Me.Energy = New DataLog(oid, Me.prop, iBase)
   End Sub

#Region "Devices"
   Public Function Value() as double
      Return JsonConvert.DeserializeObject(Of P1JSON)(Me.GWI.ObjectPropGet(Me.oid, Me.prop)).rv.value
   End Function
#End Region
End Class
