<?php
$utils = new Utils;

$update = new Update;

if (isset($_POST['start_update'])) {

try {
    $settings = [
        ["id", 'int(11)', 'unsigned', 'NOT NULL'],
        ["setting_key", 'varchar(50)', 'NOT NULL'],
        ["setting_value", 'varchar(50)', 'NOT NULL'],
    ];

    $sql = [
        $update->rename_table("admin", "users"),
        $update->drop_table("smtp"),
        $update->drop_table("settings"),
        $update->create_table("settings", $settings),
        $update->insert_value("settings", [
            "id" => 1,
            "setting_key" => 'panel_status',
            "setting_value" => 'on',
        ]),
        $update->insert_value("settings", [
            "id" => 2,
            "setting_key" => 'recaptcha_status',
            "setting_value" => 'off',
        ]),
        $update->insert_value("settings", [
            "id" => 3,
            "setting_key" => 'recaptchapublic',
            "setting_value" => 'UpdateYourCode',
        ]),
        $update->insert_value("settings", [
            "id" => 4,
            "setting_key" => 'recaptchaprivate',
            "setting_value" => 'UpdateYourCode',
        ]),
        $update->insert_value("settings", [
            "id" => 5,
            "setting_key" => 'smtp_status',
            "setting_value" => 'off',
        ]),
        $update->insert_value("settings", [
            "id" => 6,
            "setting_key" => 'smtp_host',
            "setting_value" => 'smtp.localhost.com',
        ]),
        $update->insert_value("settings", [
            "id" => 7,
            "setting_key" => 'smtp_username',
            "setting_value" => 'localhost@gmail.com',
        ]),
        $update->insert_value("settings", [
            "id" => 8,
            "setting_key" => 'smtp_password',
            "setting_value" => base64_encode('password'),
        ]),
        $update->insert_value("settings", [
            "id" => 9,
            "setting_key" => 'smtp_security',
            "setting_value" => 'ssl',
        ]),
        $update->insert_value("settings", [
            "id" => 10,
            "setting_key" => 'smtp_port',
            "setting_value" => '461',
        ]),
        $update->is_primary("settings", "id"),
        $update->is_autoinc("settings", ["id", 'int(11)', 'unsigned', 'NOT NULL']),
    ];

    foreach ($sql as $query) {
        $msg = $update->execute($query);
    }
} catch (Exception $ex) {
echo $ex->getMessage();
}
}

$page = "updatePage";
