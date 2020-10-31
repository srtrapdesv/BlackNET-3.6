<?php
declare (strict_types = 1);

include_once APP_PATH . '/vendor/phpmailer/phpmailer/src/PHPMailer.php';
include_once APP_PATH . '/vendor/phpmailer/phpmailer/src/SMTP.php';
include_once APP_PATH . '/vendor/phpmailer/phpmailer/src/Exception.php';

use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\PHPMailer;

/**
 * Simple Class that handles emails created using PHPMailer and PHP mail();
 *
 * @package BlackNET
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @version 1.0.0
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */
class Mailer
{
    /**
     * Database Connection
     *
     * @var Database $db
     */
    private $db;

    /**
     * Mailer class construct
     */
    public function __construct()
    {
        $this->db = new Database;
    }

    /**
     * Get SMTP data to use with PHPMailer
     *
     * @return array
     */
    public function getSMTP(): array
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
     * Update SMTP Data
     *
     * @param array $smtp_data
     * @return boolean
     */
    public function setSMTP(array $smtp_data): bool
    {
        try {
            $status = [];
            foreach ($smtp_data as $setting_key => $setting_value) {
                $this->db->query("UPDATE settings SET setting_value = :value WHERE setting_key = :key");

                $this->db->bind(":key", $setting_key, PDO::PARAM_STR);
                $this->db->bind(":value", $setting_value, PDO::PARAM_STR);

                $this->db->execute();
            }

            return true;
        } catch (Exception $e) {
            return false;
        }

    }

    /**
     * check if SMTP is enabled then use PHPMailer to send a premade messgae if not this function will use mail() to send messages
     *
     * @param string $email
     * @param string $subject
     * @param string $body
     * @return boolean
     */
    public function sendmail(string $email, string $subject, string $body): bool
    {
        $smtpdata = $this->getSMTP();
        $mail = new PHPMailer(true);
        try {
            if ($smtpdata['smtp_status'] == "on") {
                // PHPMailer settings
                $mail->isSMTP();
                $mail->Host = $smtpdata['smtp_security'] . "://" . $smtpdata['smtp_host'] . ":" . $smtpdata['smtp_port'];
                $mail->SMTPAuth = true;
                $mail->Username = $smtpdata['smtp_username'];
                $mail->Password = base64_decode($smtpdata['smtp_password']);

                $mail->setFrom($smtpdata['smtp_username'], 'BlackNET');
                $mail->addAddress($email);

                $mail->isHTML(true);
                $mail->Subject = $subject;
                $mail->Body = $body;

                if ($mail->send()) {
                    return true;
                } else {
                    return false;
                }
            } else {
                // Headers to enable HTML in mail();
                $from = ADMIN_EMAIL;
                $headers = 'MIME-Version: 1.0' . "\r\n";
                $headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";

                // Create email headers
                $headers .= 'From: ' . $from . "\r\n" .
                'Reply-To: ' . $from . "\r\n" .
                'X-Mailer: PHP/' . phpversion();
                if (mail($email, $subject, $body, $headers)) {
                    return true;
                } else {
                    return false;
                }
            }
        } catch (Exception $e) {
            return false;
        }
    }
}
