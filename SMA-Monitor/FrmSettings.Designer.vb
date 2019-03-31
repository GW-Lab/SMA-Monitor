<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSettings
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
      Me.btnOK = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ChkTopMost = New System.Windows.Forms.CheckBox()
      Me.LblPollingInterval = New System.Windows.Forms.Label()
      Me.LblIntervalSeconds = New System.Windows.Forms.Label()
      Me.NudInverval = New System.Windows.Forms.NumericUpDown()
      Me.IpBox1 = New GWIPBox.IPBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.NudModBusID = New System.Windows.Forms.NumericUpDown()
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.NudModBusID, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(128, 83)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(47, 23)
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(2, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "IPAddress:"
      '
      'ChkTopMost
      '
      Me.ChkTopMost.AutoSize = True
      Me.ChkTopMost.Location = New System.Drawing.Point(5, 87)
      Me.ChkTopMost.Name = "ChkTopMost"
      Me.ChkTopMost.Size = New System.Drawing.Size(70, 17)
      Me.ChkTopMost.TabIndex = 3
      Me.ChkTopMost.Text = "Top most"
      Me.ChkTopMost.UseVisualStyleBackColor = True
      '
      'LblPollingInterval
      '
      Me.LblPollingInterval.AutoSize = True
      Me.LblPollingInterval.Location = New System.Drawing.Point(2, 63)
      Me.LblPollingInterval.Name = "LblPollingInterval"
      Me.LblPollingInterval.Size = New System.Drawing.Size(79, 13)
      Me.LblPollingInterval.TabIndex = 4
      Me.LblPollingInterval.Text = "Polling Interval:"
      '
      'LblIntervalSeconds
      '
      Me.LblIntervalSeconds.AutoSize = True
      Me.LblIntervalSeconds.Location = New System.Drawing.Point(129, 60)
      Me.LblIntervalSeconds.Name = "LblIntervalSeconds"
      Me.LblIntervalSeconds.Size = New System.Drawing.Size(49, 13)
      Me.LblIntervalSeconds.TabIndex = 5
      Me.LblIntervalSeconds.Text = "Seconds"
      '
      'NudInverval
      '
      Me.NudInverval.Location = New System.Drawing.Point(83, 59)
      Me.NudInverval.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
      Me.NudInverval.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.NudInverval.Name = "NudInverval"
      Me.NudInverval.Size = New System.Drawing.Size(41, 20)
      Me.NudInverval.TabIndex = 6
      Me.NudInverval.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'IpBox1
      '
      Me.IpBox1.Borderstyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.IpBox1.IPAdress = CType(resources.GetObject("IpBox1.IPAdress"), System.Net.IPAddress)
      Me.IpBox1.Location = New System.Drawing.Point(62, 2)
      Me.IpBox1.Name = "IpBox1"
      Me.IpBox1.Size = New System.Drawing.Size(119, 27)
      Me.IpBox1.TabIndex = 7
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(2, 37)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(63, 13)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "ModBus ID:"
      '
      'NudModBusID
      '
      Me.NudModBusID.Location = New System.Drawing.Point(83, 32)
      Me.NudModBusID.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
      Me.NudModBusID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.NudModBusID.Name = "NudModBusID"
      Me.NudModBusID.Size = New System.Drawing.Size(41, 20)
      Me.NudModBusID.TabIndex = 9
      Me.NudModBusID.Value = New Decimal(New Integer() {3, 0, 0, 0})
      '
      'FrmSettings
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(181, 111)
      Me.ControlBox = False
      Me.Controls.Add(Me.NudModBusID)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.IpBox1)
      Me.Controls.Add(Me.NudInverval)
      Me.Controls.Add(Me.LblIntervalSeconds)
      Me.Controls.Add(Me.LblPollingInterval)
      Me.Controls.Add(Me.ChkTopMost)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmSettings"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Settings"
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.NudModBusID, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents btnOK As Button
   Friend WithEvents Label1 As Label
   Friend WithEvents ChkTopMost As CheckBox
   Friend WithEvents LblPollingInterval As Label
   Friend WithEvents LblIntervalSeconds As Label
   Friend WithEvents NudInverval As NumericUpDown
   Friend WithEvents IpBox1 As GWIPBox.IPBox
   Friend WithEvents Label2 As Label
   Friend WithEvents NudModBusID As NumericUpDown

   '  Friend WithEvents IpAddressControl1 As IPAddressControlLib.IPAddressControl
End Class
