<?php

$utils = new Utils;

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $username = isset($_POST['email']) ? $utils->sanitize($_POST['email']) : '';
    $resetPassword = new ResetPassword;
    if ($resetPassword->sendEmail($username)) {
        $msg = "Instructions has been send to your email";
    } else {
        $err = "Username does not exist!";
    }
}

$page = "forgetPassword";
