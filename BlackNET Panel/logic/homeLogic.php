<?php
$client = new Clients;
$allClients = $client->getClients();

$columns = [
    "Victim ID",
    "IP Address",
    "Computer Name",
    "User Status",
    "Country",
    "OS",
    "Installed Date",
    "Antivirus",
    "Version",
    "Status",
];

$disabled = (empty($allClients)) ? "disabled" : null;

$page = "home";
