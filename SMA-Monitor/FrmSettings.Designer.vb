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
      Me.IpbSMA = New GWIPBox.IPBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.NudModBusID = New System.Windows.Forms.NumericUpDown()
      Me.IpbIungo = New GWIPBox.IPBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.ChkPVAutoHotWater = New System.Windows.Forms.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.NudPVTresholdWatt = New System.Windows.Forms.NumericUpDown()
      Me.LblPVTresholdWatt = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.NudModBusID, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      CType(Me.NudPVTresholdWatt, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(143, 221)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(47, 23)
      Me.btnOK.TabIndex = 1
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 23)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(20, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "IP:"
      '
      'ChkTopMost
      '
      Me.ChkTopMost.AutoSize = True
      Me.ChkTopMost.Location = New System.Drawing.Point(11, 225)
      Me.ChkTopMost.Name = "ChkTopMost"
      Me.ChkTopMost.Size = New System.Drawing.Size(70, 17)
      Me.ChkTopMost.TabIndex = 3
      Me.ChkTopMost.Text = "Top most"
      Me.ChkTopMost.UseVisualStyleBackColor = True
      '
      'LblPollingInterval
      '
      Me.LblPollingInterval.AutoSize = True
      Me.LblPollingInterval.Location = New System.Drawing.Point(5, 84)
      Me.LblPollingInterval.Name = "LblPollingInterval"
      Me.LblPollingInterval.Size = New System.Drawing.Size(79, 13)
      Me.LblPollingInterval.TabIndex = 4
      Me.LblPollingInterval.Text = "Polling Interval:"
      '
      'LblIntervalSeconds
      '
      Me.LblIntervalSeconds.AutoSize = True
      Me.LblIntervalSeconds.Location = New System.Drawing.Point(132, 81)
      Me.LblIntervalSeconds.Name = "LblIntervalSeconds"
      Me.LblIntervalSeconds.Size = New System.Drawing.Size(49, 13)
      Me.LblIntervalSeconds.TabIndex = 5
      Me.LblIntervalSeconds.Text = "Seconds"
      '
      'NudInverval
      '
      Me.NudInverval.Location = New System.Drawing.Point(86, 80)
      Me.NudInverval.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
      Me.NudInverval.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.NudInverval.Name = "NudInverval"
      Me.NudInverval.Size = New System.Drawing.Size(41, 20)
      Me.NudInverval.TabIndex = 6
      Me.NudInverval.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'IpbSMA
      '
      Me.IpbSMA.Borderstyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.IpbSMA.IPAdress = CType(resources.GetObject("IpbSMA.IPAdress"), System.Net.IPAddress)
      Me.IpbSMA.Location = New System.Drawing.Point(32, 16)
      Me.IpbSMA.Name = "IpbSMA"
      Me.IpbSMA.Size = New System.Drawing.Size(119, 27)
      Me.IpbSMA.TabIndex = 7
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(5, 58)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(63, 13)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "ModBus ID:"
      '
      'NudModBusID
      '
      Me.NudModBusID.Location = New System.Drawing.Point(86, 53)
      Me.NudModBusID.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
      Me.NudModBusID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.NudModBusID.Name = "NudModBusID"
      Me.NudModBusID.Size = New System.Drawing.Size(41, 20)
      Me.NudModBusID.TabIndex = 9
      Me.NudModBusID.Value = New Decimal(New Integer() {3, 0, 0, 0})
      '
      'IpbIungo
      '
      Me.IpbIungo.Borderstyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.IpbIungo.IPAdress = CType(resources.GetObject("IpbIungo.IPAdress"), System.Net.IPAddress)
      Me.IpbIungo.Location = New System.Drawing.Point(26, 14)
      Me.IpbIungo.Name = "IpbIungo"
      Me.IpbIungo.Size = New System.Drawing.Size(119, 27)
      Me.IpbIungo.TabIndex = 11
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(5, 21)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(20, 13)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "IP:"
      '
      'ChkPVAutoHotWater
      '
      Me.ChkPVAutoHotWater.AutoSize = True
      Me.ChkPVAutoHotWater.Location = New System.Drawing.Point(9, 49)
      Me.ChkPVAutoHotWater.Name = "ChkPVAutoHotWater"
      Me.ChkPVAutoHotWater.Size = New System.Drawing.Size(124, 17)
      Me.ChkPVAutoHotWater.TabIndex = 12
      Me.ChkPVAutoHotWater.Text = "Auto make hot water"
      Me.ChkPVAutoHotWater.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.LblPVTresholdWatt)
      Me.GroupBox1.Controls.Add(Me.NudPVTresholdWatt)
      Me.GroupBox1.Controls.Add(Me.IpbSMA)
      Me.GroupBox1.Controls.Add(Me.ChkPVAutoHotWater)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Location = New System.Drawing.Point(6, 5)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(191, 100)
      Me.GroupBox1.TabIndex = 13
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "PV system (SMA)"
      '
      'NudPVTresholdWatt
      '
      Me.NudPVTresholdWatt.Increment = New Decimal(New Integer() {100, 0, 0, 0})
      Me.NudPVTresholdWatt.Location = New System.Drawing.Point(79, 68)
      Me.NudPVTresholdWatt.Maximum = New Decimal(New Integer() {4000, 0, 0, 0})
      Me.NudPVTresholdWatt.Minimum = New Decimal(New Integer() {1500, 0, 0, 0})
      Me.NudPVTresholdWatt.Name = "NudPVTresholdWatt"
      Me.NudPVTresholdWatt.Size = New System.Drawing.Size(48, 20)
      Me.NudPVTresholdWatt.TabIndex = 13
      Me.NudPVTresholdWatt.Value = New Decimal(New Integer() {1500, 0, 0, 0})
      '
      'LblPVTresholdWatt
      '
      Me.LblPVTresholdWatt.AutoSize = True
      Me.LblPVTresholdWatt.Location = New System.Drawing.Point(24, 71)
      Me.LblPVTresholdWatt.Name = "LblPVTresholdWatt"
      Me.LblPVTresholdWatt.Size = New System.Drawing.Size(51, 13)
      Me.LblPVTresholdWatt.TabIndex = 14
      Me.LblPVTresholdWatt.Text = "Treshold:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(133, 70)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(30, 13)
      Me.Label4.TabIndex = 15
      Me.Label4.Text = "Watt"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.NudInverval)
      Me.GroupBox2.Controls.Add(Me.LblPollingInterval)
      Me.GroupBox2.Controls.Add(Me.IpbIungo)
      Me.GroupBox2.Controls.Add(Me.LblIntervalSeconds)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.Label2)
      Me.GroupBox2.Controls.Add(Me.NudModBusID)
      Me.GroupBox2.Location = New System.Drawing.Point(6, 113)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(191, 106)
      Me.GroupBox2.TabIndex = 14
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Enery manager (Iungo)"
      '
      'FrmSettings
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(201, 245)
      Me.ControlBox = False
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.ChkTopMost)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmSettings"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Settings"
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.NudModBusID, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.NudPVTresholdWatt, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents btnOK As Button
   Friend WithEvents Label1 As Label
   Friend WithEvents ChkTopMost As CheckBox
   Friend WithEvents LblPollingInterval As Label
   Friend WithEvents LblIntervalSeconds As Label
   Friend WithEvents NudInverval As NumericUpDown
   Friend WithEvents IpbSMA As GWIPBox.IPBox
   Friend WithEvents Label2 As Label
   Friend WithEvents NudModBusID As NumericUpDown
   Friend WithEvents IpbIungo As GWIPBox.IPBox
   Friend WithEvents Label3 As Label
   Friend WithEvents ChkPVAutoHotWater As CheckBox
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents Label4 As Label
   Friend WithEvents LblPVTresholdWatt As Label
   Friend WithEvents NudPVTresholdWatt As NumericUpDown
   Friend WithEvents GroupBox2 As GroupBox

   '  Friend WithEvents IpAddressControl1 As IPAddressControlLib.IPAddressControl
End Class
