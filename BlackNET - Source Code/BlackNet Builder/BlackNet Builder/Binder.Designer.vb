<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Binder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Binder))
        Me.FormSkin1 = New BlackNet_Builder.FormSkin()
        Me.CloseForm = New BlackNet_Builder.FlatButton()
        Me.DroperName = New BlackNet_Builder.FlatTextBox()
        Me.DroperPath = New BlackNet_Builder.FlatComboBox()
        Me.FlatButton2 = New BlackNet_Builder.FlatButton()
        Me.BinderFile = New BlackNet_Builder.FlatTextBox()
        Me.FlatButton1 = New BlackNet_Builder.FlatButton()
        Me.FlatLabel3 = New BlackNet_Builder.FlatLabel()
        Me.FlatLabel2 = New BlackNet_Builder.FlatLabel()
        Me.FlatLabel1 = New BlackNet_Builder.FlatLabel()
        Me.FormSkin1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormSkin1
        '
        Me.FormSkin1.AllowDrop = True
        Me.FormSkin1.BackColor = System.Drawing.Color.White
        Me.FormSkin1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.FormSkin1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.FormSkin1.Controls.Add(Me.CloseForm)
        Me.FormSkin1.Controls.Add(Me.DroperName)
        Me.FormSkin1.Controls.Add(Me.DroperPath)
        Me.FormSkin1.Controls.Add(Me.FlatButton2)
        Me.FormSkin1.Controls.Add(Me.BinderFile)
        Me.FormSkin1.Controls.Add(Me.FlatButton1)
        Me.FormSkin1.Controls.Add(Me.FlatLabel3)
        Me.FormSkin1.Controls.Add(Me.FlatLabel2)
        Me.FormSkin1.Controls.Add(Me.FlatLabel1)
        Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormSkin1.FlatColor = System.Drawing.Color.DarkOrange
        Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormSkin1.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FormSkin1.HeaderMaximize = False
        Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
        Me.FormSkin1.Name = "FormSkin1"
        Me.FormSkin1.Size = New System.Drawing.Size(399, 221)
        Me.FormSkin1.TabIndex = 0
        Me.FormSkin1.Text = "Binder Settings"
        '
        'CloseForm
        '
        Me.CloseForm.BackColor = System.Drawing.Color.Transparent
        Me.CloseForm.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.CloseForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.CloseForm.Location = New System.Drawing.Point(382, 0)
        Me.CloseForm.Name = "CloseForm"
        Me.CloseForm.Rounded = False
        Me.CloseForm.Size = New System.Drawing.Size(18, 18)
        Me.CloseForm.TabIndex = 26
        Me.CloseForm.Text = "r"
        Me.CloseForm.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'DroperName
        '
        Me.DroperName.BackColor = System.Drawing.Color.Transparent
        Me.DroperName.Location = New System.Drawing.Point(58, 134)
        Me.DroperName.MaxLength = 32767
        Me.DroperName.Multiline = False
        Me.DroperName.Name = "DroperName"
        Me.DroperName.ReadOnly = False
        Me.DroperName.Size = New System.Drawing.Size(248, 29)
        Me.DroperName.TabIndex = 24
        Me.DroperName.Text = "svshost.exe"
        Me.DroperName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.DroperName.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DroperName.UseSystemPasswordChar = False
        '
        'DroperPath
        '
        Me.DroperPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DroperPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DroperPath.DisplayMember = "T"
        Me.DroperPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.DroperPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DroperPath.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.DroperPath.ForeColor = System.Drawing.Color.White
        Me.DroperPath.FormattingEnabled = True
        Me.DroperPath.HoverColor = System.Drawing.Color.Orange
        Me.DroperPath.ItemHeight = 18
        Me.DroperPath.Items.AddRange(New Object() {"Temp ", "AppData", "UserProfile", "ProgramData", "WinDir"})
        Me.DroperPath.Location = New System.Drawing.Point(58, 104)
        Me.DroperPath.Name = "DroperPath"
        Me.DroperPath.Size = New System.Drawing.Size(248, 24)
        Me.DroperPath.TabIndex = 20
        Me.DroperPath.Tag = ""
        '
        'FlatButton2
        '
        Me.FlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.FlatButton2.BaseColor = System.Drawing.Color.Orange
        Me.FlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlatButton2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FlatButton2.Location = New System.Drawing.Point(312, 70)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.Rounded = False
        Me.FlatButton2.Size = New System.Drawing.Size(75, 29)
        Me.FlatButton2.TabIndex = 7
        Me.FlatButton2.Text = ". . . . "
        Me.FlatButton2.TextColor = System.Drawing.Color.Black
        '
        'BinderFile
        '
        Me.BinderFile.BackColor = System.Drawing.Color.Transparent
        Me.BinderFile.Location = New System.Drawing.Point(58, 70)
        Me.BinderFile.MaxLength = 32767
        Me.BinderFile.Multiline = False
        Me.BinderFile.Name = "BinderFile"
        Me.BinderFile.ReadOnly = False
        Me.BinderFile.Size = New System.Drawing.Size(248, 29)
        Me.BinderFile.TabIndex = 6
        Me.BinderFile.Text = "Select or Drag and Drop a file"
        Me.BinderFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.BinderFile.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BinderFile.UseSystemPasswordChar = False
        '
        'FlatButton1
        '
        Me.FlatButton1.BackColor = System.Drawing.Color.Transparent
        Me.FlatButton1.BaseColor = System.Drawing.Color.Orange
        Me.FlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlatButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FlatButton1.Location = New System.Drawing.Point(12, 171)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Rounded = False
        Me.FlatButton1.Size = New System.Drawing.Size(375, 40)
        Me.FlatButton1.TabIndex = 4
        Me.FlatButton1.Text = "Save Settings"
        Me.FlatButton1.TextColor = System.Drawing.Color.Black
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel3.ForeColor = System.Drawing.Color.White
        Me.FlatLabel3.Location = New System.Drawing.Point(1, 142)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Size = New System.Drawing.Size(62, 13)
        Me.FlatLabel3.TabIndex = 2
        Me.FlatLabel3.Text = "File name: "
        '
        'FlatLabel2
        '
        Me.FlatLabel2.AutoSize = True
        Me.FlatLabel2.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel2.ForeColor = System.Drawing.Color.White
        Me.FlatLabel2.Location = New System.Drawing.Point(9, 109)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Size = New System.Drawing.Size(53, 13)
        Me.FlatLabel2.TabIndex = 1
        Me.FlatLabel2.Text = "Drop to: "
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.White
        Me.FlatLabel1.Location = New System.Drawing.Point(6, 76)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(57, 13)
        Me.FlatLabel1.TabIndex = 0
        Me.FlatLabel1.Text = "File Path: "
        '
        'Binder
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 221)
        Me.Controls.Add(Me.FormSkin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Binder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Binder"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.FormSkin1.ResumeLayout(False)
        Me.FormSkin1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormSkin1 As BlackNet_Builder.FormSkin
    Friend WithEvents FlatButton1 As BlackNet_Builder.FlatButton
    Friend WithEvents FlatLabel3 As BlackNet_Builder.FlatLabel
    Friend WithEvents FlatLabel2 As BlackNet_Builder.FlatLabel
    Friend WithEvents FlatLabel1 As BlackNet_Builder.FlatLabel
    Friend WithEvents BinderFile As BlackNet_Builder.FlatTextBox
    Friend WithEvents FlatButton2 As BlackNet_Builder.FlatButton
    Friend WithEvents DroperPath As BlackNet_Builder.FlatComboBox
    Friend WithEvents DroperName As BlackNet_Builder.FlatTextBox
    Friend WithEvents CloseForm As BlackNet_Builder.FlatButton
End Class
