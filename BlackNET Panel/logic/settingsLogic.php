<?php
$smtp = new Mailer();
$getSMTP = $smtp->getSMTP();

$settings = new Settings;
$getSettings = $settings->getSettings();

$smtp_types = ["None", "SSL", "TLS"];

$page = "network_settings";
