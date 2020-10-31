<?php
$clients = new Clients;
$logs = $clients->getLogs();

$disabled = (empty($logs)) ? "disabled" : "";

$page = "view_logs";
