﻿Public Class FrmSettings
   Private ReadOnly frm As FrmSMAMonitor

#Region "Constructor"
   Public Sub New(frm As FrmSMAMonitor)
      InitializeComponent()   ' This call is required by the designer.

      Me.frm = frm            ' Add any initialization after the InitializeComponent() call.
   End Sub
#End Region

   Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
      NudInverval.Value = My.Settings.Interval
      NudModBusID.Value = My.Settings.ModBusID
      ChkTopMost.Checked = My.Settings.TopMost

      IpbSMA.Text = My.Settings.IP_SMA
      IpbIungo.Text = My.Settings.IP_Iungo

      Location = Me.frm.Location
   End Sub

   Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
      My.Settings.Interval = CInt(NudInverval.Value)
      My.Settings.ModBusID = CByte(NudInverval.Value)
      My.Settings.TopMost = ChkTopMost.Checked

      My.Settings.IP_SMA = IpbSMA.Text
      My.Settings.IP_Iungo = IpbIungo.Text

      Me.frm.TmrMain.Interval = My.Settings.Interval

      Close()
   End Sub
End Class