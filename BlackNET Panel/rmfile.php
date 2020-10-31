<?php
include_once 'session.php';
try {
    if ($_SERVER['REQUEST_METHOD'] == "POST") {
        $files = $_POST['file'];
        if ($_SESSION['csrf'] == $utils->sanitize($_POST['csrf'])) {
            foreach ($files as $file) {
                if (strpos($file, "../")) {
                    $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_POST['vicid']) . "&msg=error");
                }
                $filename = $utils->sanitize($file);
                $real_path = realpath("upload" . "/" . trim($_POST['vicid']) . "/" . $filename);
                if (file_exists($real_path)) {
                    @unlink($real_path);
                    $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_POST['vicid']) . "&msg=yes");
                } else {
                    $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_POST['vicid']) . "&msg=error");
                }
            }
        } else {
            $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_POST['vicid']) . "&msg=csrf");
        }
    } else {
        $file = $utils->sanitize($_GET['fname']);
        if (strpos($file, "../")) {
            $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_GET['vicid']) . "&msg=error");
        }
        $filename = $utils->sanitize(stripcslashes($file));
        $real_path = realpath("upload" . "/" . $utils->sanitize($_GET['vicid']) . "/" . $filename);
        if ($_SESSION['csrf'] == $utils->sanitize($_GET['csrf'])) {
            if (file_exists($real_path)) {
                @unlink($real_path);
                $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_GET['vicid']) . "&msg=yes");
            } else {
                $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_GET['vicid']) . "&msg=error");
            }
        } else {
            $utils->redirect("viewuploads.php?vicid=" . $utils->sanitize($_GET['vicid']) . "&msg=csrf");
        }
    }
} catch (Exception $e) {
}
