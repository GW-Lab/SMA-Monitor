' Program..: Weather.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (Weather)

Public Class Weather : Inherits Dictionary(Of String, Data)
   Public Temperature As DataLog
   Public Humidity As DataLog
   Public WindSpeedMS As DataLog
   Public WindDirection As DataLog
   Public AirPressure As DataLog
   Public Rain As DataLog
   Public SolarIntensity As DataLog
   Public Sub New(dataloglistvalidlogs As List(Of DataLogListValidLogsJSON.Values), iBase As IungoBase)
      Me.Temperature = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "temp_current").Oid, "temp_current", iBase)
      Me.Humidity = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "humidity").Oid, "humidity", iBase)
      Me.WindSpeedMS = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "windspeedMS").Oid, "windspeedMS", iBase)
      Me.WindDirection = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "winddirection").Oid, "winddirection", iBase)
      Me.AirPressure = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "airpressure").Oid, "airpressure", iBase)
      Me.Rain = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "rain").Oid, "rain", iBase)
      Me.SolarIntensity = New DataLog(dataloglistvalidlogs.First(Function(log) log.Prop = "solarintensity").Oid, "solarintensity", iBase)
   End Sub
End Class
