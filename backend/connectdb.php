<?php
/*
 * 11-29-19 Connects to MYSQL database
*/

$host_db = "theiab.cz4x4lrzgbkp.us-east-2.rds.amazonaws.com";
$user_db = "admin";
$pass_db = "262626aA";
$db_name = "theiab";

$mysqli = new mysqli($host_db, $user_db, $pass_db, $db_name);

?>