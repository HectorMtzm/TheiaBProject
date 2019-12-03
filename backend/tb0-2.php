<?php
/*
 * 11-28-19 Register.
*/

include_once("connectdb.php");
include_once("API.php");

if ($mysqli->connect_error) {
    ExitProgram(405, returnMessage(10,405));
}

SetAutoCommit($mysqli, FALSE);

if (isset($_POST['firstname'])) $firstname = trim($_POST['firstname']);
else ExitProgram(900, returnMessage(0,900));

if (isset($_POST['lastname'])) $lastname = $_POST['lastname'];
else ExitProgram(900, returnMessage(1,900));

if (isset($_POST['phonenumber'])) $phonenumber = $_POST['phonenumber'];
else ExitProgram(900, returnMessage(2,900));

if (isset($_POST['email'])) $email = $_POST['email'];
else ExitProgram(900, returnMessage(3,900));

if (isset($_POST['username'])) $username = $_POST['username'];
else ExitProgram(900, returnMessage(4,900));

if (isset($_POST['password'])) $password = $_POST['password'];
else ExitProgram(900, returnMessage(5,900));

if (isset($_POST['emergencycontact'])) $emergencycontact = $_POST['emergencycontact'];
else ExitProgram(900, returnMessage(6,900));

$query = "Select * ";
$query .= "From Users ";
$query .= "Where email = ?";

$data = ['', $email];
$stmt = ExecutePS($query, $data);

$result = $stmt->get_result();

if ($mysqli->affected_rows != 0){
    ExitProgram(400, returnMessage($email,400));
}

ReleaseResultCloseConnect();

$query = "INSERT INTO Users SET ";
$query .= "firstname = ?, ";
$query .= "lastname = ?, ";
$query .= "username = ?, ";
$query .= "password = ?, ";
$query .= "email = ?, ";
$query .= "emergencycontact = ?, ";
$query .= "phonenumber = ?";

$data = ['', $firstname, $lastname, $username, $password, $email, $emergencycontact, $phonenumber];

$stmt = ExecutePS($query, $data);

if ($mysqli->affected_rows === 0 || $mysqli->affected_rows === -1){
    $dataError = array('error' => $mysqli->error);
    ExitProgram(403, returnMessage("Nothing changed",403));
    RollbackTransactions($mysqli);
}
else{
    CommitTransactions($mysqli);
    ExitProgram(201, returnMessage("User",201));
}

?>