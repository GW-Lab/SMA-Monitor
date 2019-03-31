' Program..: Gas.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB 16.0 RC4 .NET Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Type Class (Gas)

Imports Newtonsoft.Json

Public Class Gas
   Private ReadOnly GWIungo As IungoBase
   Public ReadOnly oid As String

   Public Power As DataLog
   Public Energy As DataLog

   Public Enum GasProp As Integer
      gas
      gas_usage
   End Enum

   Public Sub New(oid As String, iBase As IungoBase)
      Me.GWIungo = iBase
      Me.oid = oid

      Me.Power = New DataLog(oid, "gas_usage", iBase)
      Me.Energy = New DataLog(oid, "gas", iBase)
   End Sub

   Public Function Value(prop As GasProp) as double
      Return JsonConvert.DeserializeObject(Of SolarJSON)(Me.GWIungo.ObjectPropGet(Me.oid, prop.ToString)).rv.value
   End Function
End Class
