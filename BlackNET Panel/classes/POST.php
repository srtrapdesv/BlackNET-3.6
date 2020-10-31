<?php
declare (strict_types = 1);

/**
 * Class to handles POST Request
 *
 * @package BlackNET
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @version 1.0.0
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */
class POST
{

    /**
     * Folder name that we want to write in it
     *
     * @var string $folder_name
     */
    private $folder_name;

    /**
     * The file name that we want to write inside it
     *
     * @var string $file_name
     */
    private $file_name;

    /**
     * The data we want to put inside $file_name
     *
     * @var string
     */
    private $data;

    /**
     * the file permissions status
     *
     * @var string $status
     */
    private $status;

    /**
     * A Method to prepare class properties
     *
     * @param string $folder_name
     * @param string $file_name
     * @param string $data
     * @param string $status
     * @return void
     */
    public function prepare(string $folder_name, string $file_name, string $data, string $status = "w")
    {
        $this->folder_name = $folder_name;
        $this->file_name = $file_name;
        $this->data = $data;
        $this->status = $status;
    }

    /**
     * A Method to sanitize and filter data
     *
     * @param string $data
     * @return string
     */
    public function sanitize(string $data): string
    {
        $data = trim($data);
        $data = htmlspecialchars($data, ENT_QUOTES, 'UTF-8');
        $data = filter_var($data, FILTER_SANITIZE_STRING);
        return $data;
    }

    /**
     * A Method to write pepared data to a file
     *
     * @return boolean
     */
    public function write(): bool
    {
        try {
            $data = isset($this->data) ? $this->data : "This is incorrect";
            if ($this->folder_name == "www") {
                $myfile = fopen($this->file_name, $this->status);
            } else {
                if (!file_exists($this->folder_name) && !is_dir($this->folder_name)) {
                    mkdir($this->folder_name);
                }
                $myfile = fopen($this->folder_name . "/" . $this->file_name, $this->status);
            }
            fwrite($myfile, "\n" . $data . "\n");
            fclose($myfile);

            return true;
        } catch (Exception $th) {
            return false;
        }
    }
}
