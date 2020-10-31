<?php
$utils = new Utils;
$user = new User;
$page = "resetQuestionPage";
$key = isset($_GET['key']) ? $utils->sanitize($_GET['key']) : null;
$updatePassword = new ResetPassword;
if ($updatePassword->isExist($key) == true) {
    $data = $updatePassword->getUserAssignToToken($key);
    $userQuestion = $user->getQuestionByUser($data->username);
    if ($_SERVER['REQUEST_METHOD'] == "POST") {
        if ($utils->sanitize($_POST['answer']) == $userQuestion->answer) {
            $utils->redirect("reset.php?key=$key&answered=true");
        } else {
            $msg = "Answer is incorrect !";
        }
    }
} else {
    $utils->redirect("expire.php");
}
