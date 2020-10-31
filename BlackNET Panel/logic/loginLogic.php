<?php
$utils = new Utils;
$settings = new Settings;
$auth = new Auth;

$lockout_time = 10;

/** Check if user is already log in */

if (isset($_SESSION)) {
    if (isset($_SESSION['login_user'])) {
        $utils->redirect("index.php");
    }
}

$getSettings = $settings->getSettings();

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $username = $utils->sanitize($_POST['username']);
    $password = $utils->sanitize($_POST['password']);

    $loginstatus = $auth->newLogin($username, $password);

    if ($loginstatus == 200) {

        if (isset($_POST['recaptcha_response'])) {
            $response = $auth->recaptchaResponse($getSettings['recaptchaprivate'], $_POST['recaptcha_response']);
            if (!$response) {
                $error = "Robot verification failed, please try again.";
            }
        }

        if (!isset($error)) {
            session_regenerate_id();
            $_SESSION['login_user'] = $username;
            if ($auth->isTwoFAEnabled($username) == "on") {
                $utils->redirect("auth.php");
            } else {
                $_SESSION['OTP'] = "OK";
                $utils->redirect("index.php");
            }
        }
    } elseif ($loginstatus == 401) {
        $error = "Username or Password is incorrect.";
    } elseif ($loginstatus == 403) {
        $error = "This account has been locked because of too many failed logins.\nIf this is the case, please try again in $lockout_time minutes.";
    } else {
        $error = "Unexpected error occurred !";
    }
}

$page = "loginPage";
