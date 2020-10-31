<?php
declare (strict_types = 1);

/**
 * A class that has some utilities functions
 *
 * @package BlackNET
 * @version 1.0.0
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */

class Utils
{

    /**
     * Sanitize value
     *
     * @param string $value
     * @return string
     */
    public function sanitize(string $value): string
    {
        $data = trim($value);
        $data = htmlspecialchars($data, ENT_QUOTES, "UTF-8");
        $data = filter_var($data, FILTER_SANITIZE_STRING);
        $data = stripslashes($data);
        return $data;
    }

    /**
     * Show custom alert when needed
     *
     * @param string $message
     * @param string $style
     * @param string $icon
     * @return void
     */
    public function show_alert(string $message, string $style = "primary", string $icon = null)
    {
        if ($icon != null) {
            $icon = '<span class="fa fa-' . $this->sanitize($icon) . '"></span>';
        } else {
            $icon = "";
        }
        echo '<div class="alert alert-' . $this->sanitize($style) . '">' . $icon . " " . $this->sanitize($message) . '</div>';
        return;
    }

    /**
     * Show dismissible alerts when needed
     *
     * @param string $message
     * @param string $style
     * @param string $icon
     * @return void
     */
    public function show_dismissible_alert(string $message, string $style = "primary", string $icon = null)
    {
        if ($icon != null) {
            $icon = '<span class="fa fa-' . $this->sanitize($icon) . '"></span>';
        } else {
            $icon = "";
        }
        echo '<div class="alert alert-' . $this->sanitize($style) . ' alert-dismissible fade show"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>' . $icon . " " . $message . '</div>';
        return;
    }

    /**
     * Redirect a user a page when needed
     *
     * @param string $url
     * @return void
     */
    public function redirect(string $url)
    {
        header('Location: ' . $url);
        exit;
    }

    /**
     * Show a hidden input when needed like CRSF value
     *
     * @param string $name
     * @param string $value
     * @return void
     */
    public function show_input(string $name, string $value)
    {
        echo '<input type="text" value="' . $this->sanitize($value) . '" name="' . $this->sanitize($name) . '" id="' . $name . '" hidden />';
        return;
    }

    /**
     * Check if a link is active or not in navbar
     *
     * @param $page
     * @param string $page_name
     * @return string
     */
    public function link_active($page, string $page_name): string
    {
        return (isset($page) && $page == $page_name) ? "active" : "";
    }

    /**
     * Encode string using Base64_URL_Safe Method
     *
     * @param string $string
     * @return string
     */
    public function base64_encode_url(string $string): string
    {
        return str_replace(['+', '/', '='], ['-', '_', ''], base64_encode($string));
    }

    /**
     * Decode string using Base64_URL_Safe Method
     *
     * @param string $string
     * @return string
     */
    public function base64_decode_url(string $string): string
    {
        return base64_decode(str_replace(['-', '_'], ['+', '/'], $string));
    }
}
