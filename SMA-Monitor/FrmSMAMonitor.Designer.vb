<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSMAMonitor
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSMAMonitor))
      Me.TmrMain = New System.Windows.Forms.Timer(Me.components)
      Me.LblTempCelsiusValue = New System.Windows.Forms.Label()
      Me.LblPowerW = New System.Windows.Forms.Label()
      Me.LblSunPowerVal = New System.Windows.Forms.Label()
      Me.LblDayYield = New System.Windows.Forms.Label()
      Me.LblTotalYieldMWh = New System.Windows.Forms.Label()
      Me.LblTotalYieldValue = New System.Windows.Forms.Label()
      Me.LblTotalYield = New System.Windows.Forms.Label()
      Me.LblDayYieldValue = New System.Windows.Forms.Label()
      Me.LblDayYieldkWh = New System.Windows.Forms.Label()
      Me.LblStatusValue = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.TmrConnect = New System.Windows.Forms.Timer(Me.components)
      Me.LblTempCelsius = New System.Windows.Forms.Label()
      Me.CmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.MnuSettings = New System.Windows.Forms.ToolStripMenuItem()
      Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
      Me.LblAmpere = New System.Windows.Forms.Label()
      Me.LblAmpereValue = New System.Windows.Forms.Label()
      Me.LblVoltageValue = New System.Windows.Forms.Label()
      Me.LblVoltage = New System.Windows.Forms.Label()
      Me.LblUsedW = New System.Windows.Forms.Label()
      Me.LblUsedPowerVal = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.LblUsedPowerTotalVal = New System.Windows.Forms.Label()
      Me.LblHotWaterValue = New System.Windows.Forms.Label()
      Me.GroupBox1.SuspendLayout()
      Me.CmsMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'TmrMain
      '
      Me.TmrMain.Enabled = True
      Me.TmrMain.Interval = 10000
      '
      'LblTempCelsiusValue
      '
      Me.LblTempCelsiusValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblTempCelsiusValue.Location = New System.Drawing.Point(29, 94)
      Me.LblTempCelsiusValue.Name = "LblTempCelsiusValue"
      Me.LblTempCelsiusValue.Size = New System.Drawing.Size(49, 16)
      Me.LblTempCelsiusValue.TabIndex = 24
      Me.LblTempCelsiusValue.Text = "0"
      Me.LblTempCelsiusValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblPowerW
      '
      Me.LblPowerW.AutoSize = True
      Me.LblPowerW.Location = New System.Drawing.Point(81, 3)
      Me.LblPowerW.Name = "LblPowerW"
      Me.LblPowerW.Size = New System.Drawing.Size(18, 13)
      Me.LblPowerW.TabIndex = 21
      Me.LblPowerW.Text = "W"
      '
      'LblSunPowerVal
      '
      Me.LblSunPowerVal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.LblSunPowerVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblSunPowerVal.Location = New System.Drawing.Point(28, 1)
      Me.LblSunPowerVal.Name = "LblSunPowerVal"
      Me.LblSunPowerVal.Size = New System.Drawing.Size(50, 14)
      Me.LblSunPowerVal.TabIndex = 19
      Me.LblSunPowerVal.Text = "0"
      Me.LblSunPowerVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblDayYield
      '
      Me.LblDayYield.AutoSize = True
      Me.LblDayYield.Location = New System.Drawing.Point(1, 13)
      Me.LblDayYield.Name = "LblDayYield"
      Me.LblDayYield.Size = New System.Drawing.Size(29, 13)
      Me.LblDayYield.TabIndex = 10
      Me.LblDayYield.Text = "Day:"
      '
      'LblTotalYieldMWh
      '
      Me.LblTotalYieldMWh.AutoSize = True
      Me.LblTotalYieldMWh.Location = New System.Drawing.Point(74, 35)
      Me.LblTotalYieldMWh.Name = "LblTotalYieldMWh"
      Me.LblTotalYieldMWh.Size = New System.Drawing.Size(33, 13)
      Me.LblTotalYieldMWh.TabIndex = 12
      Me.LblTotalYieldMWh.Text = "MWh"
      '
      'LblTotalYieldValue
      '
      Me.LblTotalYieldValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblTotalYieldValue.Location = New System.Drawing.Point(32, 33)
      Me.LblTotalYieldValue.Name = "LblTotalYieldValue"
      Me.LblTotalYieldValue.Size = New System.Drawing.Size(45, 15)
      Me.LblTotalYieldValue.TabIndex = 11
      Me.LblTotalYieldValue.Text = "0"
      Me.LblTotalYieldValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblTotalYield
      '
      Me.LblTotalYield.AutoSize = True
      Me.LblTotalYield.Location = New System.Drawing.Point(1, 34)
      Me.LblTotalYield.Name = "LblTotalYield"
      Me.LblTotalYield.Size = New System.Drawing.Size(34, 13)
      Me.LblTotalYield.TabIndex = 13
      Me.LblTotalYield.Text = "Total:"
      '
      'LblDayYieldValue
      '
      Me.LblDayYieldValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblDayYieldValue.Location = New System.Drawing.Point(32, 13)
      Me.LblDayYieldValue.Name = "LblDayYieldValue"
      Me.LblDayYieldValue.Size = New System.Drawing.Size(45, 15)
      Me.LblDayYieldValue.TabIndex = 8
      Me.LblDayYieldValue.Text = "0"
      Me.LblDayYieldValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblDayYieldkWh
      '
      Me.LblDayYieldkWh.AutoSize = True
      Me.LblDayYieldkWh.Location = New System.Drawing.Point(75, 15)
      Me.LblDayYieldkWh.Name = "LblDayYieldkWh"
      Me.LblDayYieldkWh.Size = New System.Drawing.Size(30, 13)
      Me.LblDayYieldkWh.TabIndex = 9
      Me.LblDayYieldkWh.Text = "kWh"
      '
      'LblStatusValue
      '
      Me.LblStatusValue.BackColor = System.Drawing.Color.Red
      Me.LblStatusValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.LblStatusValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblStatusValue.Location = New System.Drawing.Point(0, 0)
      Me.LblStatusValue.Name = "LblStatusValue"
      Me.LblStatusValue.Size = New System.Drawing.Size(8, 8)
      Me.LblStatusValue.TabIndex = 23
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.LblDayYield)
      Me.GroupBox1.Controls.Add(Me.LblTotalYieldMWh)
      Me.GroupBox1.Controls.Add(Me.LblTotalYieldValue)
      Me.GroupBox1.Controls.Add(Me.LblTotalYield)
      Me.GroupBox1.Controls.Add(Me.LblDayYieldValue)
      Me.GroupBox1.Controls.Add(Me.LblDayYieldkWh)
      Me.GroupBox1.Location = New System.Drawing.Point(1, 110)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(108, 52)
      Me.GroupBox1.TabIndex = 22
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Yield:"
      '
      'TmrConnect
      '
      Me.TmrConnect.Interval = 10000
      '
      'LblTempCelsius
      '
      Me.LblTempCelsius.AutoSize = True
      Me.LblTempCelsius.Location = New System.Drawing.Point(80, 97)
      Me.LblTempCelsius.Name = "LblTempCelsius"
      Me.LblTempCelsius.Size = New System.Drawing.Size(18, 13)
      Me.LblTempCelsius.TabIndex = 25
      Me.LblTempCelsius.Text = "°C"
      '
      'CmsMain
      '
      Me.CmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSettings, Me.MnuExit})
      Me.CmsMain.Name = "CmsMain"
      Me.CmsMain.Size = New System.Drawing.Size(117, 48)
      '
      'MnuSettings
      '
      Me.MnuSettings.Image = CType(resources.GetObject("MnuSettings.Image"), System.Drawing.Image)
      Me.MnuSettings.Name = "MnuSettings"
      Me.MnuSettings.Size = New System.Drawing.Size(116, 22)
      Me.MnuSettings.Text = "Settings"
      '
      'MnuExit
      '
      Me.MnuExit.Image = CType(resources.GetObject("MnuExit.Image"), System.Drawing.Image)
      Me.MnuExit.Name = "MnuExit"
      Me.MnuExit.Size = New System.Drawing.Size(116, 22)
      Me.MnuExit.Text = "Exit"
      '
      'LblAmpere
      '
      Me.LblAmpere.AutoSize = True
      Me.LblAmpere.Location = New System.Drawing.Point(81, 79)
      Me.LblAmpere.Name = "LblAmpere"
      Me.LblAmpere.Size = New System.Drawing.Size(28, 13)
      Me.LblAmpere.TabIndex = 26
      Me.LblAmpere.Text = "Amp"
      '
      'LblAmpereValue
      '
      Me.LblAmpereValue.Location = New System.Drawing.Point(30, 79)
      Me.LblAmpereValue.Name = "LblAmpereValue"
      Me.LblAmpereValue.Size = New System.Drawing.Size(48, 13)
      Me.LblAmpereValue.TabIndex = 27
      Me.LblAmpereValue.Text = "0"
      Me.LblAmpereValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblVoltageValue
      '
      Me.LblVoltageValue.Location = New System.Drawing.Point(33, 61)
      Me.LblVoltageValue.Name = "LblVoltageValue"
      Me.LblVoltageValue.Size = New System.Drawing.Size(45, 13)
      Me.LblVoltageValue.TabIndex = 29
      Me.LblVoltageValue.Text = "0"
      Me.LblVoltageValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblVoltage
      '
      Me.LblVoltage.AutoSize = True
      Me.LblVoltage.Location = New System.Drawing.Point(81, 61)
      Me.LblVoltage.Name = "LblVoltage"
      Me.LblVoltage.Size = New System.Drawing.Size(25, 13)
      Me.LblVoltage.TabIndex = 28
      Me.LblVoltage.Text = "Volt"
      '
      'LblUsedW
      '
      Me.LblUsedW.AutoSize = True
      Me.LblUsedW.Location = New System.Drawing.Point(82, 21)
      Me.LblUsedW.Name = "LblUsedW"
      Me.LblUsedW.Size = New System.Drawing.Size(18, 13)
      Me.LblUsedW.TabIndex = 31
      Me.LblUsedW.Text = "W"
      '
      'LblUsedPowerVal
      '
      Me.LblUsedPowerVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblUsedPowerVal.Location = New System.Drawing.Point(25, 19)
      Me.LblUsedPowerVal.Name = "LblUsedPowerVal"
      Me.LblUsedPowerVal.Size = New System.Drawing.Size(53, 14)
      Me.LblUsedPowerVal.TabIndex = 30
      Me.LblUsedPowerVal.Text = "0"
      Me.LblUsedPowerVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(82, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(18, 13)
      Me.Label1.TabIndex = 33
      Me.Label1.Text = "W"
      '
      'LblUsedPowerTotalVal
      '
      Me.LblUsedPowerTotalVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblUsedPowerTotalVal.ForeColor = System.Drawing.Color.Black
      Me.LblUsedPowerTotalVal.Location = New System.Drawing.Point(28, 38)
      Me.LblUsedPowerTotalVal.Name = "LblUsedPowerTotalVal"
      Me.LblUsedPowerTotalVal.Size = New System.Drawing.Size(50, 14)
      Me.LblUsedPowerTotalVal.TabIndex = 32
      Me.LblUsedPowerTotalVal.Text = "0"
      Me.LblUsedPowerTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'LblHotWaterValue
      '
      Me.LblHotWaterValue.BackColor = System.Drawing.Color.Red
      Me.LblHotWaterValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.LblHotWaterValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblHotWaterValue.Location = New System.Drawing.Point(0, 9)
      Me.LblHotWaterValue.Name = "LblHotWaterValue"
      Me.LblHotWaterValue.Size = New System.Drawing.Size(8, 8)
      Me.LblHotWaterValue.TabIndex = 34
      '
      'FrmSMAMonitor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(110, 166)
      Me.ControlBox = False
      Me.Controls.Add(Me.LblHotWaterValue)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.LblUsedPowerTotalVal)
      Me.Controls.Add(Me.LblUsedW)
      Me.Controls.Add(Me.LblUsedPowerVal)
      Me.Controls.Add(Me.LblVoltageValue)
      Me.Controls.Add(Me.LblVoltage)
      Me.Controls.Add(Me.LblAmpereValue)
      Me.Controls.Add(Me.LblAmpere)
      Me.Controls.Add(Me.LblTempCelsiusValue)
      Me.Controls.Add(Me.LblPowerW)
      Me.Controls.Add(Me.LblSunPowerVal)
      Me.Controls.Add(Me.LblStatusValue)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.LblTempCelsius)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmSMAMonitor"
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.Text = "SB 3600TL-21"
      Me.TopMost = True
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.CmsMain.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents TmrMain As Timer
   Friend WithEvents LblTempCelsiusValue As Label
   Friend WithEvents LblPowerW As Label
   Friend WithEvents LblSunPowerVal As Label
   Friend WithEvents LblDayYield As Label
   Friend WithEvents LblTotalYieldMWh As Label
   Friend WithEvents LblTotalYieldValue As Label
   Friend WithEvents LblTotalYield As Label
   Friend WithEvents LblDayYieldValue As Label
   Friend WithEvents LblDayYieldkWh As Label
   Friend WithEvents LblStatusValue As Label
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents TmrConnect As Timer
   Friend WithEvents LblTempCelsius As Label
   Friend WithEvents MnuSettings As ToolStripMenuItem
   Friend WithEvents MnuExit As ToolStripMenuItem
   Friend WithEvents LblAmpere As Label
   Friend WithEvents LblAmpereValue As Label
   Friend WithEvents LblVoltageValue As Label
   Friend WithEvents LblVoltage As Label
   Friend WithEvents CmsMain As ContextMenuStrip
   Friend WithEvents LblUsedW As Label
   Friend WithEvents LblUsedPowerVal As Label
   Friend WithEvents Label1 As Label
   Friend WithEvents LblUsedPowerTotalVal As Label
   Friend WithEvents LblHotWaterValue As Label
End Class
