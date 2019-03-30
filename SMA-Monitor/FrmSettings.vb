﻿Public Class FrmSettings
   Private ReadOnly frm As FrmSMAMonitor

   Public Sub New(frm As FrmSMAMonitor)
      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me.frm = frm
   End Sub

   Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
      IpBox1.Text = My.Settings.IPAddress
      NudInverval.Value = My.Settings.Interval
      NudModBusID.Value = My.Settings.ModBusID
      ChkTopMost.Checked = My.Settings.TopMost
      Location = Me.frm.Location
   End Sub

   Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
      My.Settings.IPAddress = IpBox1.Text
      My.Settings.Interval = CInt(NudInverval.Value)
      My.Settings.ModBusID = CByte(NudInverval.Value)
      My.Settings.TopMost = ChkTopMost.Checked

      Close()
   End Sub
End Class