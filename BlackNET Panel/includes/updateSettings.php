<?php
include_once '../session.php';
include_once APP_PATH . '/classes/Settings.php';
include_once APP_PATH . '/classes/Mailer.php';

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $status = null;
    if (isset($_POST['Form1'])) {
        $settings = new Settings;
        if ($_SESSION['csrf'] != $utils->sanitize($_POST['csrf'])) {
            $status = "csrf";
        } else {
            $recaptchaprivate = $utils->sanitize($_POST['recaptchaprivate']);
            $recaptchapublic = $utils->sanitize($_POST['recaptchapublic']);
            $recaptcha_status = isset($_POST['recaptcha_status']) ? "on" : 'off';
            $panel_status = isset($_POST['panel_status']) ? "on" : 'off';

            $settings_array = [
                "panel_status" => $panel_status,
                "recaptcha_status" => $recaptcha_status,
                "recaptchapublic" => $recaptchapublic,
                "recaptchaprivate" => $recaptchaprivate,
            ];

            $settings->updateSettings($settings_array);

            if (isset($_POST['darkmode'])) {
                $_SESSION['darkmode'] = true;
            } else {
                if (isset($_SESSION['darkmode'])) {
                    unset($_SESSION['darkmode']);
                }
            }
            $status = "yes";
        }
    }

    if (isset($_POST['Form2'])) {
        $smtp = new Mailer;
        if ($_SESSION['csrf'] != $utils->sanitize($_POST['csrf'])) {
            $status = "csrf";
        } else {
            $smtp_status = isset($_POST['smtp_status']) ? "on" : 'off';

            $settings_array = [
                "smtp_host" => $utils->sanitize($_POST['smtp_host']),
                "smtp_username" => $utils->sanitize($_POST['smtp_username']),
                "smtp_password" => base64_encode($utils->sanitize($_POST['smtp_password'])),
                "smtp_port" => $utils->sanitize($_POST['smtp_port']),
                "smtp_security" => $utils->sanitize($_POST['smtp_security']),
                "smtp_status" => $smtp_status,
            ];

            $msg = $smtp->setSMTP($settings_array);

            $status = "yes";
        }
    }

    $utils->redirect("../settings.php?msg=" . $utils->sanitize($status));
}
