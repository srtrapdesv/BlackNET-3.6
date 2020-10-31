<?php
declare (strict_types = 1);

/**
 * A class that handles Reset Password Requsts
 *
 * @package BlackNET
 * @version 1.0.0
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */

class ResetPassword
{
    /**
     * Database Connection
     *
     * @var $db
     */
    private $db;

    /**
     * User Class
     *
     * @var User $user
     */
    private $user;

    /**
     * ResetPassword class construct
     */
    public function __construct()
    {
        $this->db = new Database;
        $this->user = new User;
    }

    /**
     * generate a secure sha1 token
     *
     * @return string
     */
    public function generateToken(): string
    {
        return sha1(base64_encode(uniqid()));
    }

    /**
     * send an email to the user with the password link
     *
     * @param string $username
     * @return boolean
     */
    public function sendEmail(string $username): bool
    {
        $sendmail = new Mailer;
        try {
            if ($this->user->checkUser($username) != true) {
                return false;
            } else {
                $token = $this->generateToken();
                $rows = $this->user->getUserData($username);
                $email = $rows->email;

                $this->db->query("INSERT INTO confirm_code (username,token) VALUES (:username,:token)");

                $this->db->bind(":username", $rows->username, PDO::PARAM_STR);
                $this->db->bind(":token", $token, PDO::PARAM_STR);

                if ($this->db->execute()) {
                    $actual_link = (isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] == 'on' ? "https" : "http") . "://" . $this->getDir();
                    $sendmail->sendmail($email, "Reset password instructions", "
			Hello $rows->username
			<br /><br />
			You recently made a request to reset your BlackNET account password. Please click the link below to continue.
			<br /><br />
			<a href='" . $actual_link . "reset.php?key=$token'>Update my password.</a>
			<br /><br />
			This link will expire in 24 hours
			<br /><br />
			If you did not make this request, please ignore this email.");
                }
                return true;
            }
        } catch (Exception $e) {
        }
    }

    /**
     * Update the user password
     *
     * @param string $key
     * @param string $username
     * @param string $password
     * @return boolean
     */
    public function updatePassword(string $key, string $username, string $password): bool
    {
        if (strlen($password) >= 8) {
            $this->db->query("UPDATE users SET password = :password WHERE username = :username");

            $this->db->bind(":password", password_hash($password, PASSWORD_BCRYPT), PDO::PARAM_STR);
            $this->db->bind(":username", $username, PDO::PARAM_STR);

            if ($this->db->execute()) {
                $this->deleteToken($key);
                return true;
            }
        } else {
            return false;
        }
    }

    /**
     * Get the username using the sha1 token
     *
     * @param string $token
     * @return object
     */
    public function getUserAssignToToken(string $token): object
    {
        $this->db->query("SELECT username FROM confirm_code WHERE token = :token limit 1");

        $this->db->bind(":token", $token, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return $this->db->single();
        }
    }

    /**
     * Delete the token from the system
     *
     * @param string $token
     * @return boolean
     */
    public function deleteToken(string $token): bool
    {
        try {
            $this->db->query("DELETE FROM confirm_code WHERE token = :token");

            $this->db->bind(":token", $token, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            return false;
        }
    }

    /**
     * Check if the token exist or not
     *
     * @param string $token
     * @return boolean
     */
    public function isExist(string $token): bool
    {
        try {

            $this->db->query("SELECT * FROM confirm_code WHERE token = :token");

            $this->db->bind(":token", $token, PDO::PARAM_STR);

            if ($this->db->execute()) {
                if ($this->db->rowCount()) {
                    if ($this->isExpired($token) != false) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Check if the token is expired or not
     *
     * @param string $key
     * @return boolean
     */
    public function isExpired(string $key): bool
    {
        try {

            $this->db->query("SELECT * FROM confirm_code WHERE token = :token");

            $this->db->bind(":token", $key, PDO::PARAM_STR);

            if ($this->db->execute()) {
                $data = $this->db->single();

                $diff = time() - strtotime($data->created_at);

                if (round($diff / 3600) >= 24) {
                    $this->deleteToken($key);
                    return false;
                } else {
                    return true;
                }
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    private function getDir()
    {
        $url = $_SERVER['REQUEST_URI'];
        $parts = explode('/', $url);
        $dir = $_SERVER['SERVER_NAME'];
        for ($i = 0; $i < count($parts) - 1; $i++) {
            $dir .= $parts[$i] . "/";
        }
        return $dir;
    }
}
