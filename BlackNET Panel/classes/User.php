<?php
declare (strict_types = 1);

/**
 *  A Class to Handle User Data
 *
 * @package BlackNET
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @version 1.0.0
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */
class User
{
    /**
     * Database Connection
     *
     * @var $db
     */
    private $db;

    /**
     * User class construct
     */
    public function __construct()
    {
        $this->db = new Database;
    }

    /**
     * Function to get a user data
     *
     * @param string $username
     * @return object
     */
    public function getUserData(string $username): object
    {
        $find_by = "username";

        if (filter_var($username, FILTER_VALIDATE_EMAIL)) {
            $find_by = "email";
        }

        $this->db->query(sprintf("SELECT * FROM users WHERE %s = %s", $find_by, ":" . $find_by));

        $this->db->bind(":" . $find_by, $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return $this->db->single();
        }
    }

    /**
     * Function to know how many users
     *
     * @return integer
     */
    public function numUsers(): int
    {
        $this->db->query("SELECT * FROM users");

        if ($this->db->execute()) {
            return $this->db->rowCount();
        }
    }

    /**
     * Function to check if a user exist in the database
     *
     * @param string $username
     * @return boolean
     */
    public function checkUser(string $username): bool
    {
        $find_by = "username";

        if (filter_var($username, FILTER_VALIDATE_EMAIL)) {
            $find_by = "email";
        }

        $this->db->query(sprintf("SELECT * FROM users WHERE %s = %s", $find_by, ":" . $find_by));

        $this->db->bind(":" . $find_by, $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            if ($this->db->rowCount()) {
                return true;
            } else {
                return false;
            }

        }

    }

    /**
     * Update user information when needed
     *
     * @param integer $id
     * @param array $user_array
     * @return boolean
     */
    public function updateUser(int $id, array $user_array): bool
    {

        $array_keys = array_keys($user_array);

        $query = "UPDATE users SET ";

        foreach ($array_keys as $key) {
            $query .= $key . "=" . ":" . $key . ",";
        }

        $query = rtrim($query, ",");

        $query .= " WHERE id = :id";

        $this->db->query($query);

        foreach ($user_array as $key => $value) {
            $this->db->bind(":" . $key, $value, PDO::PARAM_STR);
        }

        $this->db->bind(":id", $id, PDO::PARAM_INT);

        if ($this->db->execute()) {
            return true;
        }
    }

    /**
     * Enable 2 factor auth for a user
     *
     * @param string $username
     * @param string $secret
     * @return boolean
     */
    public function enables2fa(string $username, string $secret): bool
    {

        $this->db->query("UPDATE users SET s2fa = :auth, secret = :secret WHERE username = :username");

        $this->db->bind(":auth", "on", PDO::PARAM_STR);
        $this->db->bind(":secret", $secret, PDO::PARAM_STR);
        $this->db->bind(":username", $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return true;
        }
    }

    /**
     * Disable 2 factor auth for a user
     *
     * @param string $username
     * @return boolean
     */
    public function disable2fa(string $username): bool
    {
        $this->db->query("UPDATE users SET s2fa = :auth, secret = :secret WHERE username = :username");

        $this->db->bind(":auth", "off", PDO::PARAM_STR);
        $this->db->bind(":secret", "null", PDO::PARAM_STR);
        $this->db->bind(":username", $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return true;
        }
    }

    /**
     * Get a user security question
     *
     * @param string $username
     * @return object
     */
    public function getQuestionByUser(string $username): object
    {
        $this->db->query("SELECT question,answer,sqenable FROM users WHERE username = :user");

        $this->db->bind(":user", $username, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return $this->db->single();
        }
    }

    /**
     * check if securiry question enabled
     *
     * @param string $username
     * @return boolean
     */
    public function isQuestionEnabled(string $username): bool
    {
        try {
            $this->db->query("SELECT sqenable FROM users WHERE username = :user");

            $this->db->bind(":user", $username, PDO::PARAM_STR);

            if ($this->db->execute()) {
                $data = $this->db->single();
                if ($data->sqenable == "off") {
                    return false;
                } else {
                    return true;
                }
            }

        } catch (Exception $th) {
            //throw $th;
        }
    }
}
