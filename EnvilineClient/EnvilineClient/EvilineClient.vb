' Program..: EnvilineClient.vb
' Author...: G. Wassink
' Design...:
' Date.....: 15/11/2017 Last revised: 19/09/2018
' Notice...: Copyright 1999, All Rights Reserved
' Notes....: VB16.1.3 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Type Class Do synchronous Udp communication - (UdpClient)

Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class EnvilineClient
   Const timeOut = 2000                                                          ' Udp communication 2 seconds timeout
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
      Using udpClient = New UdpClient()
         udpClient.Client.ReceiveTimeout = timeOut
         udpClient.Client.SendTimeout = timeOut

         Dim RequestData = Encoding.ASCII.GetBytes(msg)
         Dim ServerEp = New IPEndPoint(IPAddress.Any, 0)

         udpClient.EnableBroadcast = True
         udpClient.Send(RequestData, RequestData.Length, New IPEndPoint(IPAddress.Broadcast, Me.port))
         Dim serverReply = Encoding.ASCII.GetString(udpClient.Receive(ServerEp)) ' Wait for reply

         Select Case serverReply.ToLower
            Case "blue_sky" : Me.Status = Weather.Blue_Sky
            Case "cloudy" : Me.Status = Weather.Cloudy
            Case Else : Me.Status = Weather.Status
         End Select
      End Using

      RaiseEvent Status_Changed(Me.Status)
   End Sub
End Class
