<?php
$utils = new Utils;
$user = new User;
$page = "resetPasswordPage";
$key = $utils->sanitize($_GET['key']);

$updatePassword = new ResetPassword;
if ($updatePassword->isExist($key) == true) {
    $data = $updatePassword->getUserAssignToToken($key);
    $question = $user->isQuestionEnabled($data->username);
    $answered = isset($_GET['answered']) ? $utils->sanitize($_GET['answered']) : "false";
    if ($question != false) {
        if ($answered != "true") {
            $utils->redirect("question.php?username=$data->username&key=$key");
        }
    }
    if ($_SERVER['REQUEST_METHOD'] == "POST") {
        $Password = $utils->sanitize($_POST['password']);
        $confirmPassword = $utils->sanitize($_POST['confirmPassword']);
        if ($Password == $confirmPassword) {
            if ($updatePassword->updatePassword($key, $data->username, $_POST['password'])) {
                $msg = "Password Has Been Updated";
            } else {
                $err = "Please enter more then 8 characters";
            }
        } else {
            $err = "Password confirm is incorrect";
        }
    }
} else {
    $utils->redirect("expire.php");
}
session_destroy();
