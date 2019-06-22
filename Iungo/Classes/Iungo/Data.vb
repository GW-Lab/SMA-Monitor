' Program..: Data.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (Device)

Imports Newtonsoft.Json

Public Class Data
   Private ReadOnly iBase As IungoBase
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
      Me.iBase = iBase
      Me.oid = oid
      Me.prop = prop

      Me.Power = New DataLog(oid, "power", iBase)
      Me.Energy = New DataLog(oid, Me.prop, iBase)
   End Sub
#Region "Devices"
   Public Function Value() As Double
      Return JsonConvert.DeserializeObject(Of P1JSON)(Me.iBase.ObjectPropGet(Me.oid, Me.prop)).Rv.Value
   End Function
#End Region
End Class
