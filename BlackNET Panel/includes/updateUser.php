<?php
include_once '../session.php';

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    if ($_SESSION['csrf'] != $utils->sanitize($_POST['csrf'])) {
        $utils->redirect("../updateUser.php?msg=csrf");
    } else {
        $user_array = [];

        $id = (int) $_POST['id'];
        $user_array['username'] = $utils->sanitize($_POST['Username']);
        $user_array['email'] = $utils->sanitize($_POST['Email']);
        $user_array['question'] = $utils->sanitize($_POST['questions']);
        $user_array['answer'] = $utils->sanitize($_POST['answer']);
        $user_array['sqenable'] = isset($_POST['sqenable']) ? "on" : "off";

        if ($_POST['Password'] || $_POST['Password'] != "") {
            $password = $utils->sanitize($_POST['Password']);
            $user_array['password'] = password_hash($password, PASSWORD_BCRYPT);
        }

        if ($user->updateUser($id, $user_array)) {
            $_SESSION['login_user'] = $user_array['username'];

            $utils->redirect("../updateUser.php?msg=yes");
        } else {
            $utils->redirect("../updateUser.php?msg=error");
        }
    }
}
