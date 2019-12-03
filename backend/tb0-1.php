<?php 
/*
 * 11-28-19 Log in.
*/

session_start();
include_once("connectdb.php");
include_once("API.php");

// Check connection
if ($mysqli->connect_error) {
    ExitProgram(405, returnMessage(10,405));
}

if (isset($_POST['email'])) $email = trim($_POST['email']);
else ExitProgram(900, returnMessage(0,900));

if (isset($_POST['password'])) $password = trim($_POST['password']);
else ExitProgram(900, returnMessage(1,900));

$query  = "select * ";
$query .= "from Users ";
$query .= "where email = ?";

$data = ['', $email];
$stmt = ExecutePS($query, $data);

$result = $stmt->get_result();

if ($mysqli->affected_rows === 0){
    ExitProgram(401, returnMessage(11,401));
}

$accessRow = $result->fetch_assoc();


if ($password == $accessRow['password']){
    $_SESSION['username'] = $accessRow['username'];
    ExitProgram(200, returnMessage(0,200));
}
ExitProgram(402, returnMessage(0,402))

?>