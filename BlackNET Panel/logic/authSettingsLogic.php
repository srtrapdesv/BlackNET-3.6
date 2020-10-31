<?php
$g = new \Sonata\GoogleAuthenticator\GoogleAuthenticator();
if ($data->s2fa == "off") {
    if (!isset($_SESSION['secret'])) {
        $_SESSION['secret'] = $g->generateSecret();
    }

    $qrcode = \Sonata\GoogleAuthenticator\GoogleQrUrl::generate(
        $_SESSION['login_user'],
        $_SESSION['secret'],
        'BlackNET'
    );
}

$page = "update_user";
