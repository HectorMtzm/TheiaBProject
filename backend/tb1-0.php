<?php 
/*
 * 12-02-19 get user data.
*/

include_once("connectdb.php");
include_once("API.php");

// Check connection
if ($mysqli->connect_error) {
    ExitProgram(405, returnMessage(10,405));
}

if (isset($_POST['email'])) $email = trim($_POST['email']);
else ExitProgram(900, returnMessage(0,900));

$query  = "select * ";
$query .= "from Users ";
$query .= "where email = ?";

$data = ['', $email];
$stmt = ExecutePS($query, $data);

$result = $stmt->get_result();

if ($mysqli->affected_rows === 0){
    ExitProgram(401, returnMessage($email,401));
}

$accessRow = $result->fetch_assoc();

ReturnUserAndExit($accessRow["firstname"], $accessRow["lastname"], $accessRow["username"], $accessRow["email"], $accessRow["emergencycontact"], $accessRow["phonenumber"]);

?>