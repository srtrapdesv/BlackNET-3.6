<?php
declare (strict_types = 1);

if (is_dir("config")) {

    require_once 'config/config.php';

} else {

    require_once '../config/config.php';

}
/**
 * a class that handles the database and PDO functions
 *
 * @package BlackNET
 * @version 1.0.0
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */

class Database
{
    /**
     * Database Host
     *
     * @var string $host
     */
    private $host = DB_HOST;
    /**
     * Database Username
     *
     * @var string $user
     */

    private $user = DB_USER;
    /**
     * Database Password
     *
     * @var string $pass
     */

    private $pass = DB_PASS;
    /**
     * Database Name
     *
     * @var string $dbname
     */
    private $dbname = DB_NAME;
    /**
     * Database Connection
     *
     * @var object $connection
     */
    private $connection;
    /**
     * Database Connection Error
     *
     * @var string $error
     */
    private $error;
    /**
     * Database PDO Statment
     *
     * @var object $stmt
     */
    private $stmt;
    /**
     * Check if the database is connected
     *
     * @var boolean $dbconnected
     */
    private $dbconnected = false;

    /**
     * Database class construct
     */
    public function __construct()
    {

        // Set PDO Connection
        $dsn = 'mysql:host=' . $this->host . ';dbname=' . $this->dbname;
        $options = array(
            PDO::ATTR_PERSISTENT => true,
            PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
        );

        // Create a new PDO instanace
        try {
            $this->connection = new PDO($dsn, $this->user, $this->pass, $options);
            $this->dbconnected = true;

        } // Catch any errors
         catch (PDOException $e) {
            $this->error = $e->getMessage() . PHP_EOL;
        }
    }

    /**
     * Get the Error Message
     *
     * @return string
     */
    public function getError(): string
    {
        return $this->error;
    }

    /**
     * Check if the class is connected to the database
     *
     * @return boolean
     */
    public function isConnected(): bool
    {
        return $this->dbconnected;
    }

    /**
     * Prepare statement with query
     *
     * @param string $query
     * @return void
     */
    public function query(string $query)
    {
        $this->stmt = $this->connection->prepare($query);
    }

    /**
     * Execute the prepared statement
     *
     * @return boolean
     */
    public function execute(): bool
    {
        return $this->stmt->execute();
    }

    /**
     * Get result set as array of objects
     *
     * @return array
     */
    public function resultset(): array
    {
        $data = $this->stmt->fetchAll(PDO::FETCH_OBJ);
        if (is_array($data)) {
            return $data;
        } else {
            return ["error" => "Data does not exist"];
        }
    }

    /**
     * Get record row count
     *
     * @return integer
     */
    public function rowCount(): int
    {
        $data = $this->stmt->rowCount();
        if (is_int($data)) {
            return $data;
        } else {
            return 404;
        }
    }

    /**
     * Get single record as object
     *
     * @return object
     */
    public function single(): object
    {
        $data = $this->stmt->fetch(PDO::FETCH_OBJ);

        if (is_object($data)) {
            return $data;
        } else {
            return (object) ["error" => "Data does not exist"];
        }
    }

    /**
     * Bind Values to PDO Statment
     *
     * @param string $param
     * @param mixed $value
     * @param int $type
     * @return void
     */
    public function bind(string $param, $value, int $type = null)
    {
        if (is_null($type)) {
            switch (true) {
                case is_int($value):
                    $type = PDO::PARAM_INT;
                    break;
                case is_bool($value):
                    $type = PDO::PARAM_BOOL;
                    break;
                case is_null($value):
                    $type = PDO::PARAM_NULL;
                    break;
                default:
                    $type = PDO::PARAM_STR;
            }
        }
        $this->stmt->bindValue($param, $value, $type);
    }
}
