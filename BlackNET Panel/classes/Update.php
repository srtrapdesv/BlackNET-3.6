<?php
declare (strict_types = 1);

/**
 * Class that Handles Update and Installation System
 *
 * @package BlackNET
 * @author Black.Hacker <farisksa79@protonmail.com>
 * @version 1.0.0
 * @license MIT
 * @link https://github.com/FarisCode511/BlackNET
 */

class Update
{
    /**
     * Database Connection
     *
     * @var $db
     */
    private $db;

    /**
     * Update class construct
     */
    public function __construct()
    {
        $this->db = new Database;
    }

    /**
     * Create a new table in database
     *
     * @param string $table_name
     * @param array $arrays
     * @return string
     */
    public function create_table(string $table_name, array $arrays): string
    {
        $table_syntex = sprintf("CREATE TABLE IF NOT EXISTS %s ( ", $table_name);
        if (!(empty($arrays))) {
            $column = "";
            foreach ($arrays as $array) {
                foreach ($array as $value) {
                    $column = $column . $value . " ";
                }
                $column = $column . " " . ",";
            }
        }

        $final = $table_syntex . rtrim($column, ",") . ") DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci " . ";";
        return $final;
    }

    /**
     * Modify a column to be primary
     *
     * @param string $table_name
     * @param string $column_name
     * @return string
     */
    public function is_primary(string $table_name, string $column_name): string
    {
        return sprintf("ALTER TABLE %s ADD PRIMARY KEY (%s);", $table_name, $column_name);
    }

    /**
     * Modify a column to be auto increment
     *
     * @param string $table_name
     * @param array $column_array
     * @return string
     */
    public function is_autoinc(string $table_name, array $column_array): string
    {
        return sprintf("ALTER TABLE %s MODIFY %s AUTO_INCREMENT;", $table_name, implode(" ", $column_array));
    }

    /**
     * Create a new column in a table in the database
     *
     * @param string $table_name
     * @param array $array
     * @param string $after
     * @return string
     */
    public function create_column(string $table_name, array $array, string $after): string
    {
        $column_syntex = "ALTER TABLE  $table_name ADD ";
        if (!(empty($array))) {
            $column = "";
            foreach ($array as $value) {
                $column = $column . $value . " ";
            }
        }
        $final = $column_syntex . $column . " AFTER  $after;";
        return $final;
    }

    /**
     * Update a column value in a table
     *
     * @param string $table_name
     * @param string $column_name
     * @param string $value
     * @return string
     */
    public function update_value(string $table_name, string $column_name, string $value): string
    {
        $sql = "UPDATE " . $table_name . " SET " . $column_name . " = '" . $value . "'";
        return $sql;
    }

    /**
     * Rename a table in a database
     *
     * @param string $oldTable
     * @param string $newTable
     * @return string
     */
    public function rename_table(string $oldTable, string $newTable): string
    {
        return sprintf("ALTER TABLE %s RENAME TO %s;", $oldTable, $newTable);
    }

    /**
     * Insert a value in column when needed
     *
     * @param string $table_name
     * @param array $columns_array
     * @return string
     */
    public function insert_value(string $table_name, array $columns_array): string
    {
        $sql = sprintf("INSERT INTO %s (%s) values (%s)", $table_name, implode(", ", array_keys($columns_array)), "'" . implode("', '", array_values($columns_array)) . "'");
        return $sql;
    }

    /**
     * Check if a table exist in a database
     *
     * @param string $table_name
     * @return string
     */
    public function table_exist(string $table_name): string
    {
        return "SHOW TABLES LIKE " . $table_name;
    }

    /**
     * Check if column exist in table in the database
     *
     * @param string $table_name
     * @param string $column_name
     * @return string
     */
    public function column_exist(string $table_name, string $column_name): string
    {
        return "SHOW COLUMNS FROM $table_name LIKE $column_name";
    }

    /**
     * Drop and remove a table when needed
     *
     * @param string $table_name
     * @return string
     */
    public function drop_table(string $table_name): string
    {
        return "DROP TABLE " . $table_name . ";";
    }

    /**
     * Drop and remove a column when needed
     *
     * @param string $table_name
     * @param string $column_name
     * @return string
     */
    public function drop_column(string $table_name, string $column_name): string
    {
        return "ALTER TABLE " . $table_name . " DROP COLUMN " . $column_name . ";";
    }

    /**
     * Execute SQL Querey
     *
     * @param string $sql
     * @return boolean
     */
    public function execute(string $sql): bool
    {
        try {
            $this->db->query($sql);
            $status = $this->db->execute();
            if (strpos($sql, "SHOW") != false) {
                if ($this->db->rowCount()) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return $status;
            }
        } catch (Exception $e) {
            return false;
        }
    }
}
