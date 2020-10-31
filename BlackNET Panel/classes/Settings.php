<?php
declare (strict_types = 1);

/**
 * A class that handles Network Settings
 *
 * @package BlackNET
 * @version 1.0.0
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */

class Settings
{

    /**
     * Database Connection
     *
     * @var Database $db
     */
    private $db;

    /**
     * Settings class construct
     */
    public function __construct()
    {
        $this->db = new Database;
    }

    /**
     * Get the network settings
     *
     * @return array
     */
    public function getSettings(): array
    {
        $this->db->query("SELECT setting_key,setting_value FROM settings");

        if ($this->db->execute()) {
            $settings = $this->db->resultset();
            $settings_array = array();
            foreach ($settings as $setting) {
                $settings_array[$setting->setting_key] = $setting->setting_value;
            }
            return $settings_array;
        }
    }

    /**
     * Update the network settings
     *
     * @param array $settings_array
     * @return boolean
     */
    public function updateSettings(array $settings_array): bool
    {
        try {
            foreach ($settings_array as $setting_key => $setting_value) {
                $this->db->query("UPDATE settings SET setting_value = :value WHERE setting_key = :key");

                $this->db->bind(":key", $setting_key, PDO::PARAM_STR);
                $this->db->bind(":value", $setting_value, PDO::PARAM_STR);

                $this->db->execute();
            }

            return true;
        } catch (Exception $th) {
            return false;
        }
    }
}
