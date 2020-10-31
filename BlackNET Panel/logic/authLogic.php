<?php
$_SESSION['OTP'] = "Waiting";

$page = "authPage";

$utils = new Utils;

$auth = new Auth;

if (!isset($_SESSION['login_user'])) {
    $utils->redirect("index.php");
}

$uniqeid = hash("sha256", $utils->base64_encode_url($utils->sanitize($_SERVER['HTTP_USER_AGENT'])));

if (checkUniqeId($uniqeid) == true) {

    session_regenerate_id();

    $_SESSION['OTP'] = "OK";

    $utils->redirect("index.php");
}

$g = new \Sonata\GoogleAuthenticator\GoogleAuthenticator();

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $code = $utils->sanitize($_POST['AuthCode']);
    $secret = $auth->getSecret($_SESSION['login_user']);
    if ($g->checkCode($secret, $code)) {
        if (isset($_POST['remberme'])) {
            if (!isset($_COOKIE['2fa'])) {
                setcookie('2fa', 'true', time() + 2592000);
                setcookie('device_id', $uniqeid, time() + 2592000);
            }
        }

        session_regenerate_id();

        $_SESSION['OTP'] = "OK";

        $utils->redirect("index.php");
    } else {
        $error = "Verification code is incorrect!!";
    }
}

function checkUniqeId($uniqeid)
{
    if (isset($_COOKIE['2fa'])) {
        if (isset($_COOKIE['device_id'])) {
            if ($_COOKIE['device_id'] == $uniqeid) {
                return true;
            } else {
                return false;
            }
        }
    }
}
