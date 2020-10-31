<?php
declare (strict_types = 1);

/**
 * Class to Handle User Auth
 *
 * @package BlackNET
 * @version 1.0.0
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */
class Auth
{

    /**
     * Database Connection
     *
     * @var Database $db
     */
    private $db;

    /**
     * User Class
     *
     * @var User $user
     */
    private $user;

    /**
     * Auth class construct
     */
    public function __construct()
    {
        $this->db = new Database;
        $this->user = new User;
    }

    /**
     * function to update 2fa secret if needed
     *
     * @param string $username
     * @param string $secret
     * @return boolean
     */
    public function updateSecret(string $username, string $secret): bool
    {
        $this->db->query("UPDATE users SET secret = :secret WHERE username = :username");

        $this->db->bind(":secret", $secret, PDO::PARAM_STR);
        $this->db->bind(":username", $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return true;
        }
    }

    /**
     * check login information with brute force protection
     *
     * @param string $username
     * @param string $password
     * @return integer
     */
    public function newLogin(string $username, string $password): int
    {
        $total_failed_login = 5;
        $lockout_time = 10;
        $account_locked = false;
        $this->db->query('SELECT failed_login, last_login FROM users WHERE username = (:user) LIMIT 1;');
        $this->db->bind(':user', $username, PDO::PARAM_STR);

        $this->db->execute();

        $row = $this->db->single();

        if (($this->db->rowCount() == 1) && ($row->failed_login >= $total_failed_login)) {
            $last_login = strtotime($row->last_login);
            $timeout = $last_login + ($lockout_time * 60);
            $timenow = time();

            if ($timenow < $timeout) {
                $account_locked = true;
                return 403;
            }

        }

        $this->db->query('SELECT * FROM users WHERE username = (:user) LIMIT 1;');

        $this->db->bind(':user', $username);

        $this->db->execute();

        $row = $this->db->single();

        if (($this->db->rowCount() == 1) && (password_verify($password, $row->password)) && ($account_locked == false)) {
            $last_login = $row->last_login;

            $this->db->query('UPDATE users SET failed_login = "0" WHERE username = (:user) LIMIT 1;');

            $this->db->bind(':user', $username, PDO::PARAM_STR);

            $this->db->execute();

            return 200;
        } else {
            sleep(rand(2, 4));

            $this->db->query('UPDATE users SET failed_login = (failed_login + 1) WHERE username = (:user) LIMIT 1;');

            $this->db->bind(':user', $username, PDO::PARAM_STR);

            $this->db->execute();

            return 401;
        }

        $this->db->query('UPDATE users SET last_login = now() WHERE username = (:user) LIMIT 1;');

        $this->db->bind(':user', $username, PDO::PARAM_STR);

        $this->db->execute();
    }

    /**
     * Google reCaptcha API to validate reCaptcha v3 response
     *
     * @param string $privatekey
     * @param object $recaptcha_response_field
     * @return boolean
     */
    public function recaptchaResponse(string $privatekey, $recaptcha_response_field): bool
    {
        $recaptcha_url = 'https://www.google.com/recaptcha/api/siteverify';
        $recaptcha_secret = $privatekey;
        $recaptcha_response = $recaptcha_response_field;

        $recaptcha = file_get_contents($recaptcha_url . '?secret=' . $recaptcha_secret . '&response=' . $recaptcha_response);
        $recaptcha = json_decode($recaptcha);

        if ($recaptcha->score >= 0.5) {
            return true;
        } else {
            return false;
        }

    }

    /**
     * check if 2fa is enbaled
     *
     * @param string $username
     * @return string
     */
    public function isTwoFAEnabled(string $username): string
    {
        $data = $this->user->getUserData($username);
        return $data->s2fa;
    }

    /**
     * Function to get a user data
     *
     * @param string $username
     * @return object
     */
    public function getUserData(string $username): object
    {
        $data = $this->user->getUserData($username);
        return $data;
    }

    /**
     * Return the user 2fa secret
     *
     * @param string $username
     * @return string
     */
    public function getSecret(string $username): string
    {
        $data = $this->user->getUserData($username);
        return $data->secret;
    }
}
