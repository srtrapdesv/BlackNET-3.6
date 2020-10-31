<?php
include_once 'classes/Utils.php';
include_once 'classes/blackupload/Upload.php';

$utils = new Utils;

if (isset($_GET['id'])) {
    $folder = "upload/" . $utils->sanitize($utils->base64_decode_url($_GET['id']));
}

$upload = new BlackUpload\Upload($_FILES['file'], ["folder_name" => $folder, "folder_path" => realpath($folder)], "classes/blackupload/");

$upload->enableProtection();

try {
    if (
        $upload->checkForbidden() &&
        $upload->checkExtension() &&
        $upload->checkMime()
    ) {
        $upload->upload();
    }
} catch (Throwable $th) {
}
