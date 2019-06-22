' Program..: IungoBase.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class (IungoBase)

'http://192.168.2.122/iungo/control?cmd=api_list
'http://192.168.16.66/iungo/control?cmd=api_list

Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class IungoBase : Inherits WebRequest
   Private ReadOnly URI As Uri
   Public Sub New(ip As IPAddress)
      Me.URI = New Uri($"Http://{ip.ToString}/iungo/api_request")
   End Sub
   Public Shared Function GetMyIungoIP() As IPAddress
      Try
         Using response As WebResponse = CreateHttp("http://www.atedec.com/iungo/myiungoip").GetResponse
            Using sr = New StreamReader(response.GetResponseStream)                                                                             ' IP = 83.161.138.97 Open the stream using a StreamReader for easy access. 
               Return IPAddress.Parse(sr.ReadToEnd)
            End Using
         End Using
      Catch ex As Exception
         Return New IPAddress({127, 0, 0, 1})
      End Try
   End Function

#Region "Get -> object-property"
   Public Function ObjectPropGet(oid As String, prop As String) As String                                                                       ' Return ApiRequest("{""sec"":1,""method"":""object_prop_get"",""arguments"":{""oid"":""" + oid + """,""prop"":""" + prop + """}}")
      Return ApiRequest("{""method"":""object_prop_get"",""arguments"":{""oid"":""" + oid + """,""prop"":""" + prop + """}}")
   End Function
   Public Function ObjectPropSet(oid As String, prop As String, cmd As String) As String
      Return ApiRequest("{""method"":""object_prop_set"",""arguments"":{""oid"":""" + oid + """,""prop"":""" + prop + """,""value"":""" + cmd.ToString + """}}")
   End Function
#End Region

#Region "Get First/Last dates"
   Public Function DataLogGetFirst(oid As String, prop As String) As List(Of List(Of String))                                                                ' {"ok":true,"type":"response","time":0.076535414002137,"rv":{"data":[[1507054386]]},"error":false,"systime":1509739280}
      'Work a rond via -> datalog_get_day_start_values

      Return JsonConvert.DeserializeObject(Of DataLogGetJSON)(ApiRequest("{""method"":""datalog_get_day_start_values"",""arguments"":{""prop"":""" + prop +
                                                                         """,""oid"":""" + oid +
                                                                         """,""t1"":""" + "0" +
                                                                         """,""t2"":""" + "999999999999" + """}}")).Rv.Data
   End Function

   Public Function DataLogGetLast(oid As String, prop As String) As List(Of List(Of String))
      ' Do not use defect
      Return JsonConvert.DeserializeObject(Of DataLogGetJSON)(ApiRequest("{""method"":""datalog_get_day_start_values"",""arguments"":{""prop"":""" + prop +
                                                                         """,""oid"":""" + oid +
                                                                         """,""t1"":""" + "299999999999" +
                                                                         """,""t2"":""" + "999999999999" + """}}")).Rv.Data
   End Function

   'Public Function DatalogGetFirstOfDay(oid As String, prop As String, timestamp As UInteger) As UInteger
   '   Return JsonConvert.DeserializeObject(Of DataLogGetJSON)(ApiRequest("{""method"":""datalog_get_first_of_day"",
   '                                                                      ""arguments"":{""oid"":""" + oid +
   '                                                                      """,""prop"":""" + prop +
   '                                                                      """,""timestamp"":""" + timestamp.ToString + """}}")).Rv.Timestamp
   'End Function

   Public Function DatalogGetFirstValueAfter(oid As String, prop As String, timestamp As UInteger) As UInteger
      Return JsonConvert.DeserializeObject(Of DatalogGetFirstValueAfterJSON)(ApiRequest("{""method"":""datalog_get_first_value_after"",
                                                                                        ""arguments"":{""oid"":""" + oid +
                                                                                        """,""prop"":""" + prop +
                                                                                        """,""timestamp"":""" + timestamp.ToString + """}}")).Rv.Timestamp
   End Function
   Public Function DatalogGetLastDailyValueBefore(oid As String, prop As String, timestamp As UInteger) As UInteger
      Return JsonConvert.DeserializeObject(Of DatalogGetLastDailyValueBeforeJSON)(ApiRequest("{""method"":""datalog_get_last_daily_value_before"",
                                                                                             ""arguments"":{""oid"":""" + oid +
                                                                                             """,""prop"":""" + prop +
                                                                                             """,""timestamp"":""" + timestamp.ToString + """}}")).Rv.TimeStamp
   End Function
#End Region
   Friend Function ApiRequest(jsonQuery As String) As String                                                                    '  ServicePointManager.Expect100Continue = False (see: app.config}
      Dim webReq = CreateHttp(Me.URI.AbsoluteUri)
      webReq.Method = "POST"
      webReq.ContentType = "application/json"
      webReq.ServicePoint.Expect100Continue = False
      Try
         Using sw = New StreamWriter(webReq.GetRequestStream)
            sw.Write(jsonQuery)
            sw.Flush()

            Using sr = New StreamReader(webReq.GetResponse.GetResponseStream)
               Return sr.ReadToEnd
            End Using
         End Using
      Catch ex As Exception
         '  MessageBox.Show("Iungo: " + ex.Message)
         Return ""
      End Try
   End Function
End Class

'Public Function Ping_Host(ByVal buffer_size As Integer, ByVal timeout As Integer) As String
'   Dim ping_Reply = ""
'   Dim ip = Me.Get_IP_From_Host(Me.strHostname)
'   Dim buffer = New Byte(buffer_size - 1) {}
'   If ip IsNot Nothing Then
'      Using p = New Ping()
'         Using are = New AutoResetEvent(False)
'            p.SendAsync(ip, timeout, buffer, New PingOptions With {.Ttl = 64, .DontFragment = True}, are)
'            p.PingCompleted += Function(o, e)
'                                  Strping_Reply = e.Reply.Status.ToString()
'                               End Function
'         End Using
'      End Using

'      Return Strping_Reply
'   Else
'      Return Nothing
'   End If
'End Function

'{"ok":true,
'"type":"response",
'"time":0.028814121993491,
'"rv":{"data":[[1519659937,258.899],
'              [1519686000,259.009],
'              [1519772401,259.578],
'              [1519858800,259.996],
'              [1519945200,261.311],
'              [1520031600,262.237],
'              [1520118000,263.897],
'              [1520204400,267.882],
'              [1520290801,268.534],
'              [1520377200,269.286],
'              [1520463600,269.837],
'              [1520550000,270.385],
'              [1520636401,271.484],
'              [1520722800,273.14],
'              [1520809200,275.076],
'              [1520895600,275.65],
'              [1520982000,276.26],
'              [1521068400,277.129],
'              [1521154800,278.025],
'              [1521241201,278.753],
'              [1521327600,280.584],
'              [1521414001,281.847],
'              [1521500400,282.438],
'              [1521586801,283.17],
'              [1521673200,283.681],
'              [1521759600,284.265],
'              [1521846000,285.389],
'              [1521932400,288.084],
'              [1522015200,290.235],
'              [1522101600,291.019],
'              [1522188000,291.68],
'              [1522274404,292.228],
'              [1522360800,292.868],
'              [1522447200,293.357],
'              [1522533600,295.154],
'              [1522620000,296.573]
'              ,[1522706400,298.478]]},
'              "error":false,"systime":1522762110}
