Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class EnvilineClient
   Private Status As Weather = Weather.Cloudy
   Private ReadOnly port As Integer = 8888

   Public Event Status_Changed(status As Weather)

   Public Enum Weather
      Cloudy
      Blue_Sky
      Status
   End Enum

   Public WriteOnly Property Send As Weather
      Set(value As Weather)
         If value <> Me.Status Then BroadcastMsg(value.ToString) ' Prevent unnecessary server calls
      End Set
   End Property

   Public Sub New(Optional port As Integer = 8888)
      Me.port = port
   End Sub

   Private Sub BroadcastMsg(msg As String)
      Using client = New UdpClient()
         Dim RequestData = Encoding.ASCII.GetBytes(msg)
         Dim ServerEp = New IPEndPoint(IPAddress.Any, 0)

         client.EnableBroadcast = True
         client.Send(RequestData, RequestData.Length, New IPEndPoint(IPAddress.Broadcast, Me.port))
         Dim serverReply = Encoding.ASCII.GetString(client.Receive(ServerEp)) ' Wait for reply

         Select Case serverReply.ToLower
            Case "blue_sky" : Me.Status = Weather.Blue_Sky
            Case "cloudy" : Me.Status = Weather.Cloudy
            Case Else : Me.Status = Weather.Status
         End Select
      End Using

      RaiseEvent Status_Changed(Me.Status)
   End Sub
End Class
