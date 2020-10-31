<?php
$vicID = isset($_GET['vicid']) ? $utils->sanitize($_GET['vicid']) : '';
$blacklist = array('..', '.', "index.php", ".htaccess");

$files = [];

if (file_exists("upload/$vicID")) {
    try {
        $user_files = scandir("upload/$vicID");
        foreach ($user_files as $file) {
            if (!in_array($file, $blacklist)) {
                $files[] = $file;
            }
        }
    } catch (Exception $e) {
        echo $e->getMessage();
    }
}

$disabled = (empty($files)) ? "disabled" : null;

$page = "viewUploadsPage";

function formatBytes($bytes, $precision = 2)
{
    $units = array('B', 'KB', 'MB', 'GB', 'TB');
    $bytes = max($bytes, 0);
    $pow = floor(($bytes ? log($bytes) : 0) / log(1024));
    $pow = min($pow, count($units) - 1);
    $bytes /= pow(1024, $pow);
    return round($bytes, $precision) . ' ' . $units[$pow];
}
