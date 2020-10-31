<?php
session_start();

include_once 'classes/Utils.php';

$utils = new Utils;

if (session_destroy()) {
    $utils->redirect("login.php");
}
