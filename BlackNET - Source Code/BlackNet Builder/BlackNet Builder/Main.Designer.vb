<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.FormSkin1 = New BlackNet_Builder.FormSkin()
        Me.ExecutionDelayTime = New BlackNet_Builder.FlatTextBox()
        Me.DelayExecution = New BlackNet_Builder.FlatCheckBox()
        Me.DataSplitter = New BlackNet_Builder.FlatTextBox()
        Me.FlatLabel4 = New BlackNet_Builder.FlatLabel()
        Me.DebugMode = New BlackNet_Builder.FlatCheckBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.BypassVM = New BlackNet_Builder.FlatCheckBox()
        Me.EnableBinder = New BlackNet_Builder.FlatCheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SchTask = New BlackNet_Builder.FlatCheckBox()
        Me.Startup = New BlackNet_Builder.FlatCheckBox()
        Me.CheckForUpdate = New BlackNet_Builder.FlatButton()
        Me.MinimizeApp = New BlackNet_Builder.FlatMini()
        Me.CheckPanel = New BlackNet_Builder.FlatButton()
        Me.Watchdog = New BlackNet_Builder.FlatCheckBox()
        Me.FileName = New BlackNet_Builder.FlatTextBox()
        Me.FlatLabel5 = New BlackNet_Builder.FlatLabel()
        Me.InstallPath = New BlackNet_Builder.FlatComboBox()
        Me.StealthMode = New BlackNet_Builder.FlatCheckBox()
        Me.EnableAES = New BlackNet_Builder.FlatCheckBox()
        Me.FileIcon = New System.Windows.Forms.PictureBox()
        Me.ChangeIcon = New BlackNet_Builder.FlatCheckBox()
        Me.USBSpread = New BlackNet_Builder.FlatCheckBox()
        Me.ElevateUAC = New BlackNet_Builder.FlatCheckBox()
        Me.AntiDebugging = New BlackNet_Builder.FlatCheckBox()
        Me.CloseApp = New BlackNet_Builder.FlatClose()
        Me.MUTEX = New BlackNet_Builder.FlatTextBox()
        Me.VictimID = New BlackNet_Builder.FlatTextBox()
        Me.PanelURL = New BlackNet_Builder.FlatTextBox()
        Me.FlatLabel3 = New BlackNet_Builder.FlatLabel()
        Me.FlatLabel2 = New BlackNet_Builder.FlatLabel()
        Me.FlatLabel1 = New BlackNet_Builder.FlatLabel()
        Me.CompileAgent = New BlackNet_Builder.FlatButton()
        Me.FlatLabel6 = New BlackNet_Builder.FlatLabel()
        Me.UpdateStatus = New BlackNet_Builder.FlatStatusBar()
        Me.FlatLabel7 = New BlackNet_Builder.FlatLabel()
        Me.FormSkin1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormSkin1
        '
        Me.FormSkin1.BackColor = System.Drawing.Color.White
        Me.FormSkin1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.FormSkin1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.FormSkin1.Controls.Add(Me.ExecutionDelayTime)
        Me.FormSkin1.Controls.Add(Me.DelayExecution)
        Me.FormSkin1.Controls.Add(Me.DataSplitter)
        Me.FormSkin1.Controls.Add(Me.FlatLabel4)
        Me.FormSkin1.Controls.Add(Me.DebugMode)
        Me.FormSkin1.Controls.Add(Me.PictureBox3)
        Me.FormSkin1.Controls.Add(Me.BypassVM)
        Me.FormSkin1.Controls.Add(Me.EnableBinder)
        Me.FormSkin1.Controls.Add(Me.PictureBox2)
        Me.FormSkin1.Controls.Add(Me.SchTask)
        Me.FormSkin1.Controls.Add(Me.Startup)
        Me.FormSkin1.Controls.Add(Me.CheckForUpdate)
        Me.FormSkin1.Controls.Add(Me.MinimizeApp)
        Me.FormSkin1.Controls.Add(Me.CheckPanel)
        Me.FormSkin1.Controls.Add(Me.Watchdog)
        Me.FormSkin1.Controls.Add(Me.FileName)
        Me.FormSkin1.Controls.Add(Me.FlatLabel5)
        Me.FormSkin1.Controls.Add(Me.InstallPath)
        Me.FormSkin1.Controls.Add(Me.StealthMode)
        Me.FormSkin1.Controls.Add(Me.EnableAES)
        Me.FormSkin1.Controls.Add(Me.FileIcon)
        Me.FormSkin1.Controls.Add(Me.ChangeIcon)
        Me.FormSkin1.Controls.Add(Me.USBSpread)
        Me.FormSkin1.Controls.Add(Me.ElevateUAC)
        Me.FormSkin1.Controls.Add(Me.AntiDebugging)
        Me.FormSkin1.Controls.Add(Me.CloseApp)
        Me.FormSkin1.Controls.Add(Me.MUTEX)
        Me.FormSkin1.Controls.Add(Me.VictimID)
        Me.FormSkin1.Controls.Add(Me.PanelURL)
        Me.FormSkin1.Controls.Add(Me.FlatLabel3)
        Me.FormSkin1.Controls.Add(Me.FlatLabel2)
        Me.FormSkin1.Controls.Add(Me.FlatLabel1)
        Me.FormSkin1.Controls.Add(Me.CompileAgent)
        Me.FormSkin1.Controls.Add(Me.FlatLabel6)
        Me.FormSkin1.Controls.Add(Me.UpdateStatus)
        Me.FormSkin1.Controls.Add(Me.FlatLabel7)
        Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormSkin1.FlatColor = System.Drawing.Color.DarkOrange
        Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormSkin1.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FormSkin1.HeaderMaximize = False
        Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
        Me.FormSkin1.Name = "FormSkin1"
        Me.FormSkin1.Size = New System.Drawing.Size(287, 756)
        Me.FormSkin1.TabIndex = 0
        Me.FormSkin1.Text = " BlackNET Builder"
        '
        'ExecutionDelayTime
        '
        Me.ExecutionDelayTime.BackColor = System.Drawing.Color.Transparent
        Me.ExecutionDelayTime.Enabled = False
        Me.ExecutionDelayTime.Location = New System.Drawing.Point(69, 305)
        Me.ExecutionDelayTime.MaxLength = 32767
        Me.ExecutionDelayTime.Multiline = False
        Me.ExecutionDelayTime.Name = "ExecutionDelayTime"
        Me.ExecutionDelayTime.ReadOnly = False
        Me.ExecutionDelayTime.Size = New System.Drawing.Size(206, 29)
        Me.ExecutionDelayTime.TabIndex = 44
        Me.ExecutionDelayTime.Text = "1000"
        Me.ExecutionDelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.ExecutionDelayTime.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ExecutionDelayTime.UseSystemPasswordChar = False
        '
        'DelayExecution
        '
        Me.DelayExecution.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.DelayExecution.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.DelayExecution.BorderColor = System.Drawing.Color.Orange
        Me.DelayExecution.Checked = False
        Me.DelayExecution.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DelayExecution.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DelayExecution.Location = New System.Drawing.Point(5, 398)
        Me.DelayExecution.Name = "DelayExecution"
        Me.DelayExecution.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.DelayExecution.Size = New System.Drawing.Size(121, 22)
        Me.DelayExecution.TabIndex = 41
        Me.DelayExecution.Text = "Delay Execution"
        '
        'DataSplitter
        '
        Me.DataSplitter.BackColor = System.Drawing.Color.Transparent
        Me.DataSplitter.Location = New System.Drawing.Point(69, 205)
        Me.DataSplitter.MaxLength = 32767
        Me.DataSplitter.Multiline = False
        Me.DataSplitter.Name = "DataSplitter"
        Me.DataSplitter.ReadOnly = False
        Me.DataSplitter.Size = New System.Drawing.Size(206, 29)
        Me.DataSplitter.TabIndex = 40
        Me.DataSplitter.Text = "|BN|"
        Me.DataSplitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DataSplitter.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataSplitter.UseSystemPasswordChar = False
        '
        'FlatLabel4
        '
        Me.FlatLabel4.AutoSize = True
        Me.FlatLabel4.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel4.ForeColor = System.Drawing.Color.White
        Me.FlatLabel4.Location = New System.Drawing.Point(22, 212)
        Me.FlatLabel4.Name = "FlatLabel4"
        Me.FlatLabel4.Size = New System.Drawing.Size(50, 13)
        Me.FlatLabel4.TabIndex = 39
        Me.FlatLabel4.Text = "Splitter: "
        '
        'DebugMode
        '
        Me.DebugMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.DebugMode.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.DebugMode.BorderColor = System.Drawing.Color.Orange
        Me.DebugMode.Checked = False
        Me.DebugMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DebugMode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DebugMode.Location = New System.Drawing.Point(5, 676)
        Me.DebugMode.Name = "DebugMode"
        Me.DebugMode.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.DebugMode.Size = New System.Drawing.Size(112, 22)
        Me.DebugMode.TabIndex = 38
        Me.DebugMode.Text = "Debug Mode"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(100, 593)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 37
        Me.PictureBox3.TabStop = False
        '
        'BypassVM
        '
        Me.BypassVM.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BypassVM.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BypassVM.BorderColor = System.Drawing.Color.Orange
        Me.BypassVM.Checked = False
        Me.BypassVM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BypassVM.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.BypassVM.Location = New System.Drawing.Point(5, 565)
        Me.BypassVM.Name = "BypassVM"
        Me.BypassVM.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.BypassVM.Size = New System.Drawing.Size(112, 22)
        Me.BypassVM.TabIndex = 36
        Me.BypassVM.Text = "Bypass VM"
        '
        'EnableBinder
        '
        Me.EnableBinder.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.EnableBinder.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.EnableBinder.BorderColor = System.Drawing.Color.Orange
        Me.EnableBinder.Checked = False
        Me.EnableBinder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EnableBinder.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.EnableBinder.Location = New System.Drawing.Point(5, 426)
        Me.EnableBinder.Name = "EnableBinder"
        Me.EnableBinder.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.EnableBinder.Size = New System.Drawing.Size(113, 22)
        Me.EnableBinder.TabIndex = 35
        Me.EnableBinder.Text = "Enable Binder"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(169, 346)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'SchTask
        '
        Me.SchTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.SchTask.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.SchTask.BorderColor = System.Drawing.Color.Orange
        Me.SchTask.Checked = False
        Me.SchTask.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SchTask.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SchTask.Location = New System.Drawing.Point(5, 343)
        Me.SchTask.Name = "SchTask"
        Me.SchTask.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.SchTask.Size = New System.Drawing.Size(166, 22)
        Me.SchTask.TabIndex = 32
        Me.SchTask.Text = "Add to Scheduled tasks"
        '
        'Startup
        '
        Me.Startup.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Startup.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Startup.BorderColor = System.Drawing.Color.Orange
        Me.Startup.Checked = False
        Me.Startup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Startup.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Startup.Location = New System.Drawing.Point(5, 371)
        Me.Startup.Name = "Startup"
        Me.Startup.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.Startup.Size = New System.Drawing.Size(112, 22)
        Me.Startup.TabIndex = 31
        Me.Startup.Text = "Add to Startup"
        '
        'CheckForUpdate
        '
        Me.CheckForUpdate.BackColor = System.Drawing.Color.Transparent
        Me.CheckForUpdate.BaseColor = System.Drawing.Color.Orange
        Me.CheckForUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckForUpdate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CheckForUpdate.Location = New System.Drawing.Point(175, 0)
        Me.CheckForUpdate.Name = "CheckForUpdate"
        Me.CheckForUpdate.Rounded = False
        Me.CheckForUpdate.Size = New System.Drawing.Size(64, 18)
        Me.CheckForUpdate.TabIndex = 29
        Me.CheckForUpdate.Text = "Update"
        Me.CheckForUpdate.TextColor = System.Drawing.Color.Black
        '
        'MinimizeApp
        '
        Me.MinimizeApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinimizeApp.BackColor = System.Drawing.Color.White
        Me.MinimizeApp.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.MinimizeApp.Font = New System.Drawing.Font("Marlett", 12.0!)
        Me.MinimizeApp.Location = New System.Drawing.Point(245, 0)
        Me.MinimizeApp.Name = "MinimizeApp"
        Me.MinimizeApp.Size = New System.Drawing.Size(18, 18)
        Me.MinimizeApp.TabIndex = 26
        Me.MinimizeApp.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'CheckPanel
        '
        Me.CheckPanel.BackColor = System.Drawing.Color.Transparent
        Me.CheckPanel.BaseColor = System.Drawing.Color.Orange
        Me.CheckPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckPanel.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CheckPanel.Location = New System.Drawing.Point(69, 97)
        Me.CheckPanel.Name = "CheckPanel"
        Me.CheckPanel.Rounded = False
        Me.CheckPanel.Size = New System.Drawing.Size(206, 32)
        Me.CheckPanel.TabIndex = 25
        Me.CheckPanel.Text = "Check Panel"
        Me.CheckPanel.TextColor = System.Drawing.Color.Black
        '
        'Watchdog
        '
        Me.Watchdog.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Watchdog.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Watchdog.BorderColor = System.Drawing.Color.Orange
        Me.Watchdog.Checked = False
        Me.Watchdog.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Watchdog.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Watchdog.Location = New System.Drawing.Point(5, 454)
        Me.Watchdog.Name = "Watchdog"
        Me.Watchdog.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.Watchdog.Size = New System.Drawing.Size(139, 22)
        Me.Watchdog.TabIndex = 24
        Me.Watchdog.Text = "Enable Watchdog"
        '
        'FileName
        '
        Me.FileName.BackColor = System.Drawing.Color.Transparent
        Me.FileName.Enabled = False
        Me.FileName.Location = New System.Drawing.Point(69, 270)
        Me.FileName.MaxLength = 32767
        Me.FileName.Multiline = False
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = False
        Me.FileName.Size = New System.Drawing.Size(206, 29)
        Me.FileName.TabIndex = 22
        Me.FileName.Text = "WindowsUpdate.exe"
        Me.FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.FileName.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FileName.UseSystemPasswordChar = False
        '
        'FlatLabel5
        '
        Me.FlatLabel5.AutoSize = True
        Me.FlatLabel5.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel5.ForeColor = System.Drawing.Color.White
        Me.FlatLabel5.Location = New System.Drawing.Point(7, 277)
        Me.FlatLabel5.Name = "FlatLabel5"
        Me.FlatLabel5.Size = New System.Drawing.Size(66, 13)
        Me.FlatLabel5.TabIndex = 20
        Me.FlatLabel5.Text = "File Name : "
        '
        'InstallPath
        '
        Me.InstallPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.InstallPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InstallPath.DisplayMember = "T"
        Me.InstallPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.InstallPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InstallPath.Enabled = False
        Me.InstallPath.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.InstallPath.ForeColor = System.Drawing.Color.White
        Me.InstallPath.FormattingEnabled = True
        Me.InstallPath.HoverColor = System.Drawing.Color.Orange
        Me.InstallPath.ItemHeight = 18
        Me.InstallPath.Items.AddRange(New Object() {"Temp ", "AppData", "UserProfile", "ProgramData", "WinDir"})
        Me.InstallPath.Location = New System.Drawing.Point(69, 240)
        Me.InstallPath.Name = "InstallPath"
        Me.InstallPath.Size = New System.Drawing.Size(206, 24)
        Me.InstallPath.TabIndex = 19
        Me.InstallPath.Tag = ""
        '
        'StealthMode
        '
        Me.StealthMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.StealthMode.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.StealthMode.BorderColor = System.Drawing.Color.Orange
        Me.StealthMode.Checked = False
        Me.StealthMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StealthMode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StealthMode.Location = New System.Drawing.Point(5, 509)
        Me.StealthMode.Name = "StealthMode"
        Me.StealthMode.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.StealthMode.Size = New System.Drawing.Size(112, 22)
        Me.StealthMode.TabIndex = 18
        Me.StealthMode.Text = "Stealth Mode"
        '
        'EnableAES
        '
        Me.EnableAES.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.EnableAES.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.EnableAES.BorderColor = System.Drawing.Color.Orange
        Me.EnableAES.Checked = False
        Me.EnableAES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EnableAES.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.EnableAES.Location = New System.Drawing.Point(5, 482)
        Me.EnableAES.Name = "EnableAES"
        Me.EnableAES.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.EnableAES.Size = New System.Drawing.Size(147, 22)
        Me.EnableAES.TabIndex = 14
        Me.EnableAES.Text = "AES-256 Encryption"
        '
        'FileIcon
        '
        Me.FileIcon.BackColor = System.Drawing.Color.Transparent
        Me.FileIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileIcon.Location = New System.Drawing.Point(112, 631)
        Me.FileIcon.Name = "FileIcon"
        Me.FileIcon.Size = New System.Drawing.Size(40, 40)
        Me.FileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FileIcon.TabIndex = 13
        Me.FileIcon.TabStop = False
        '
        'ChangeIcon
        '
        Me.ChangeIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ChangeIcon.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ChangeIcon.BorderColor = System.Drawing.Color.Orange
        Me.ChangeIcon.Checked = False
        Me.ChangeIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChangeIcon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ChangeIcon.Location = New System.Drawing.Point(5, 648)
        Me.ChangeIcon.Name = "ChangeIcon"
        Me.ChangeIcon.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.ChangeIcon.Size = New System.Drawing.Size(112, 22)
        Me.ChangeIcon.TabIndex = 12
        Me.ChangeIcon.Text = "Change Icon"
        '
        'USBSpread
        '
        Me.USBSpread.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.USBSpread.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.USBSpread.BorderColor = System.Drawing.Color.Orange
        Me.USBSpread.Checked = False
        Me.USBSpread.Cursor = System.Windows.Forms.Cursors.Hand
        Me.USBSpread.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.USBSpread.Location = New System.Drawing.Point(5, 621)
        Me.USBSpread.Name = "USBSpread"
        Me.USBSpread.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.USBSpread.Size = New System.Drawing.Size(112, 22)
        Me.USBSpread.TabIndex = 11
        Me.USBSpread.Text = "USB Spread"
        '
        'ElevateUAC
        '
        Me.ElevateUAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ElevateUAC.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ElevateUAC.BorderColor = System.Drawing.Color.Orange
        Me.ElevateUAC.Checked = False
        Me.ElevateUAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ElevateUAC.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ElevateUAC.Location = New System.Drawing.Point(5, 593)
        Me.ElevateUAC.Name = "ElevateUAC"
        Me.ElevateUAC.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.ElevateUAC.Size = New System.Drawing.Size(112, 22)
        Me.ElevateUAC.TabIndex = 10
        Me.ElevateUAC.Text = "Elevate UAC"
        '
        'AntiDebugging
        '
        Me.AntiDebugging.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.AntiDebugging.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AntiDebugging.BorderColor = System.Drawing.Color.Orange
        Me.AntiDebugging.Checked = False
        Me.AntiDebugging.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AntiDebugging.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.AntiDebugging.Location = New System.Drawing.Point(5, 537)
        Me.AntiDebugging.Name = "AntiDebugging"
        Me.AntiDebugging.Options = BlackNet_Builder.FlatCheckBox._Options.Style1
        Me.AntiDebugging.Size = New System.Drawing.Size(128, 22)
        Me.AntiDebugging.TabIndex = 9
        Me.AntiDebugging.Text = "Anti-Debugging"
        '
        'CloseApp
        '
        Me.CloseApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseApp.BackColor = System.Drawing.Color.White
        Me.CloseApp.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.CloseApp.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.CloseApp.Location = New System.Drawing.Point(269, 0)
        Me.CloseApp.Name = "CloseApp"
        Me.CloseApp.Size = New System.Drawing.Size(18, 18)
        Me.CloseApp.TabIndex = 8
        Me.CloseApp.Text = "FlatClose1"
        Me.CloseApp.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'MUTEX
        '
        Me.MUTEX.BackColor = System.Drawing.Color.Transparent
        Me.MUTEX.Location = New System.Drawing.Point(69, 170)
        Me.MUTEX.MaxLength = 32767
        Me.MUTEX.Multiline = False
        Me.MUTEX.Name = "MUTEX"
        Me.MUTEX.ReadOnly = False
        Me.MUTEX.Size = New System.Drawing.Size(206, 29)
        Me.MUTEX.TabIndex = 6
        Me.MUTEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.MUTEX.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MUTEX.UseSystemPasswordChar = False
        '
        'VictimID
        '
        Me.VictimID.BackColor = System.Drawing.Color.Transparent
        Me.VictimID.Location = New System.Drawing.Point(69, 135)
        Me.VictimID.MaxLength = 32767
        Me.VictimID.Multiline = False
        Me.VictimID.Name = "VictimID"
        Me.VictimID.ReadOnly = False
        Me.VictimID.Size = New System.Drawing.Size(206, 29)
        Me.VictimID.TabIndex = 5
        Me.VictimID.Text = "HacKed"
        Me.VictimID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.VictimID.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.VictimID.UseSystemPasswordChar = False
        '
        'PanelURL
        '
        Me.PanelURL.BackColor = System.Drawing.Color.Transparent
        Me.PanelURL.Location = New System.Drawing.Point(69, 62)
        Me.PanelURL.MaxLength = 32767
        Me.PanelURL.Multiline = False
        Me.PanelURL.Name = "PanelURL"
        Me.PanelURL.ReadOnly = False
        Me.PanelURL.Size = New System.Drawing.Size(206, 29)
        Me.PanelURL.TabIndex = 4
        Me.PanelURL.Text = "http://localhost/blacknet"
        Me.PanelURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.PanelURL.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelURL.UseSystemPasswordChar = False
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel3.ForeColor = System.Drawing.Color.White
        Me.FlatLabel3.Location = New System.Drawing.Point(20, 177)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Size = New System.Drawing.Size(52, 13)
        Me.FlatLabel3.TabIndex = 3
        Me.FlatLabel3.Text = "MUTEX : "
        '
        'FlatLabel2
        '
        Me.FlatLabel2.AutoSize = True
        Me.FlatLabel2.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel2.ForeColor = System.Drawing.Color.White
        Me.FlatLabel2.Location = New System.Drawing.Point(10, 142)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Size = New System.Drawing.Size(61, 13)
        Me.FlatLabel2.TabIndex = 2
        Me.FlatLabel2.Text = "Victim ID : "
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.White
        Me.FlatLabel1.Location = New System.Drawing.Point(17, 69)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(53, 13)
        Me.FlatLabel1.TabIndex = 1
        Me.FlatLabel1.Text = "BN URL : "
        '
        'CompileAgent
        '
        Me.CompileAgent.BackColor = System.Drawing.Color.Transparent
        Me.CompileAgent.BaseColor = System.Drawing.Color.Orange
        Me.CompileAgent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CompileAgent.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CompileAgent.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CompileAgent.Location = New System.Drawing.Point(0, 701)
        Me.CompileAgent.Name = "CompileAgent"
        Me.CompileAgent.Rounded = False
        Me.CompileAgent.Size = New System.Drawing.Size(287, 32)
        Me.CompileAgent.TabIndex = 0
        Me.CompileAgent.Text = "Compile Client"
        Me.CompileAgent.TextColor = System.Drawing.Color.Black
        '
        'FlatLabel6
        '
        Me.FlatLabel6.AutoSize = True
        Me.FlatLabel6.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel6.ForeColor = System.Drawing.Color.White
        Me.FlatLabel6.Location = New System.Drawing.Point(33, 245)
        Me.FlatLabel6.Name = "FlatLabel6"
        Me.FlatLabel6.Size = New System.Drawing.Size(39, 13)
        Me.FlatLabel6.TabIndex = 21
        Me.FlatLabel6.Text = "Path : "
        '
        'UpdateStatus
        '
        Me.UpdateStatus.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.UpdateStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UpdateStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.UpdateStatus.ForeColor = System.Drawing.Color.White
        Me.UpdateStatus.Location = New System.Drawing.Point(0, 733)
        Me.UpdateStatus.Name = "UpdateStatus"
        Me.UpdateStatus.RectColor = System.Drawing.Color.Orange
        Me.UpdateStatus.ShowTimeDate = False
        Me.UpdateStatus.Size = New System.Drawing.Size(287, 23)
        Me.UpdateStatus.TabIndex = 27
        Me.UpdateStatus.Text = "Version:"
        Me.UpdateStatus.TextColor = System.Drawing.Color.White
        '
        'FlatLabel7
        '
        Me.FlatLabel7.AutoSize = True
        Me.FlatLabel7.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel7.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel7.ForeColor = System.Drawing.Color.White
        Me.FlatLabel7.Location = New System.Drawing.Point(5, 313)
        Me.FlatLabel7.Name = "FlatLabel7"
        Me.FlatLabel7.Size = New System.Drawing.Size(68, 13)
        Me.FlatLabel7.TabIndex = 43
        Me.FlatLabel7.Text = "Sleep Time: "
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(287, 756)
        Me.Controls.Add(Me.FormSkin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BlackNET Builder"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.FormSkin1.ResumeLayout(False)
        Me.FormSkin1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormSkin1 As BlackNet_Builder.FormSkin
    Friend WithEvents MUTEX As BlackNet_Builder.FlatTextBox
    Friend WithEvents VictimID As BlackNet_Builder.FlatTextBox
    Friend WithEvents PanelURL As BlackNet_Builder.FlatTextBox
    Friend WithEvents FlatLabel3 As BlackNet_Builder.FlatLabel
    Friend WithEvents FlatLabel2 As BlackNet_Builder.FlatLabel
    Friend WithEvents FlatLabel1 As BlackNet_Builder.FlatLabel
    Friend WithEvents CompileAgent As BlackNet_Builder.FlatButton
    Friend WithEvents CloseApp As BlackNet_Builder.FlatClose
    Friend WithEvents ElevateUAC As BlackNet_Builder.FlatCheckBox
    Friend WithEvents AntiDebugging As BlackNet_Builder.FlatCheckBox
    Friend WithEvents FileIcon As System.Windows.Forms.PictureBox
    Friend WithEvents ChangeIcon As BlackNet_Builder.FlatCheckBox
    Friend WithEvents USBSpread As BlackNet_Builder.FlatCheckBox
    Friend WithEvents EnableAES As BlackNet_Builder.FlatCheckBox
    Friend WithEvents StealthMode As BlackNet_Builder.FlatCheckBox
    Friend WithEvents FileName As BlackNet_Builder.FlatTextBox
    Friend WithEvents FlatLabel5 As BlackNet_Builder.FlatLabel
    Friend WithEvents InstallPath As BlackNet_Builder.FlatComboBox
    Friend WithEvents FlatLabel6 As BlackNet_Builder.FlatLabel
    Friend WithEvents Watchdog As BlackNet_Builder.FlatCheckBox
    Friend WithEvents CheckPanel As FlatButton
    Friend WithEvents MinimizeApp As FlatMini
    Friend WithEvents UpdateStatus As FlatStatusBar
    Friend WithEvents CheckForUpdate As BlackNet_Builder.FlatButton
    Friend WithEvents Startup As BlackNet_Builder.FlatCheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents SchTask As BlackNet_Builder.FlatCheckBox
    Friend WithEvents EnableBinder As BlackNet_Builder.FlatCheckBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents BypassVM As BlackNet_Builder.FlatCheckBox
    Friend WithEvents FlatCheckBox14 As BlackNet_Builder.FlatCheckBox
    Friend WithEvents DebugMode As BlackNet_Builder.FlatCheckBox
    Friend WithEvents DataSplitter As BlackNet_Builder.FlatTextBox
    Friend WithEvents FlatLabel4 As BlackNet_Builder.FlatLabel
    Friend WithEvents DelayExecution As BlackNet_Builder.FlatCheckBox
    Friend WithEvents FlatLabel7 As BlackNet_Builder.FlatLabel
    Friend WithEvents ExecutionDelayTime As BlackNet_Builder.FlatTextBox
End Class
