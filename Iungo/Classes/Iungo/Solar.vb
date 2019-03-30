' Program..: Solar.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 15.6.6 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (Solar)

Imports Newtonsoft.Json

Public Class Solar
   Private ReadOnly iBase As IungoBase
   Public ReadOnly oid As String

   Public P1L As DataLog
   Public P2L As DataLog
   Public P3L As DataLog
   Public Power As DataLog
   Public Energy As DataLog
   Public Voltage As DataLog
   Public ppkwh As DataLog

   Public Enum SolarProp As Integer
      ppkwh
      Pulstotal
      P1L
      P2L
      P3L
      Solar
      Voltage
   End Enum

   Public Sub New(oid As String, iBase As IungoBase)
      Me.iBase = iBase
      Me.oid = oid

      Me.P1L = New DataLog(oid, SolarProp.P1L.ToString, iBase)
      Me.P2L = New DataLog(oid, SolarProp.P2L.ToString, iBase)
      Me.P3L = New DataLog(oid, SolarProp.P3L.ToString, iBase)

      Me.Energy = New DataLog(oid, SolarProp.Pulstotal.ToString.ToLower, iBase)
      Me.Power = New DataLog(oid, SolarProp.Solar.ToString.ToLower, iBase)
      Me.ppkwh = New DataLog(oid, SolarProp.ppkwh.ToString.ToLower, iBase)
      Me.Voltage = New DataLog(oid, SolarProp.Voltage.ToString.ToLower, iBase)
   End Sub

   Public Function Value(prop As SolarProp) as double
      Return JsonConvert.DeserializeObject(Of SolarJSON)(Me.iBase.ObjectPropGet(Me.oid, prop.ToString)).Rv.Value
   End Function
End Class
