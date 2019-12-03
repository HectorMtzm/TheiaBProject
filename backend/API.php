<?php 

//Generate the message to send
function returnMessage(string $entity, int $code, string $customMessage = ""):string
{
	$errorCodes = array(
		//Success
    200 => "Successful login",
    201 => "$entity has been created.", 
    202 => "$entity retrieved successfully",
    203 => "",
    204 => "success custom",
    205 => "success custom",
    206 => "success custom",

		//Failed
    400 => "$entity already exists",
    401 => "$entity doesn't exists",
    402 => "Password didn't match",
    403 => "Error creating user",
    404 => "",
    405 => "Couldn't connect to the database",
    406 => "failed custom",
    407 => "failed custom",

		//Error server
		900 => "Server error can not process request - $entity"
	);

	if($code === 204 || $code === 205 || $code === 206 || $code === 406 || $code === 407){
    $errorCodes[$code] = $customMessage;
  }

	return $errorCodes[$code];
}

//Encodes the json and sends it
function ExitProgram(int $code, string $message, array $objectSend = null)
{
  //Asks the server to kill a MySQL thread
  if(isset($GLOBALS['mysqli']) && isset($GLOBALS['thread_id']))
    $GLOBALS['mysqli']->kill($GLOBALS['thread_id']);

  $success = substr((string)$code, 0,1) === "2" ? 1 : 0;
  echo json_encode(array('success' => $success, 'responseCode' => $code, 'message' => $message, 'data' => $objectSend));
  exit;
}

//encodes the user data and sends it
function ReturnUserAndExit(string $firstname, string $lastname, string $username, string $email, string $emergencycontact, string $phonenumber)
{
  //Asks the server to kill a MySQL thread
  if(isset($GLOBALS['mysqli']) && isset($GLOBALS['thread_id']))
    $GLOBALS['mysqli']->kill($GLOBALS['thread_id']);

  echo json_encode(array('firstname' => $firstname, 'lastname' => $lastname, 'username' => $username, 
  'email' => $email, 'emergencycontact' => $emergencycontact, 'phonenumber' => $phonenumber));
  exit;
}

//Check the connection to the database
function CheckConnectMysqli(mysqli $co_mysqli)
{
  if ($co_mysqli->connect_errno)
    ExitProgram(900, returnMessage($co_mysqli->connect_error,900));

  return $co_mysqli->thread_id;
}

//Set the value of the autocommit function
function SetAutoCommit(mysqli $co_mysqli, bool $booleanValue)
{
  $co_mysqli->autocommit($booleanValue);
}

//Commits the current transaction
function CommitTransactions(mysqli $co_mysqli)
{
  $co_mysqli->commit();
}

//Rolls back current transaction
function RollbackTransactions(mysqli $co_mysqli)
{
  $co_mysqli->rollback();
}

//Frees the memory associated with a result and Closes a prepared statement
function ReleaseResultCloseConnect()
{
  if(isset($GLOBALS['result'])) @$GLOBALS['result']->free();
  if(isset($GLOBALS['stmt'])) @$GLOBALS['stmt']->close();
}

//Validate the entered email
function ValidateEmail(string $email): bool
{
  if(filter_var($email, FILTER_VALIDATE_EMAIL))
    return true;
  else
    return false;
}

//Check the type of the variables and form the array by reference
function FormArrayPS(array $dataQuery): array
{
  $dataByReference = array();

  foreach ($dataQuery as $key => $value) {

    if($key !== 0){
      if(gettype($value) === "string" || gettype($value) === "NULL")
        $dataQuery[0] .= "s";
      elseif(gettype($value) === "double")
        $dataQuery[0] .= "d";
      elseif(gettype($value) === "integer" || gettype($value) === "boolean")
        $dataQuery[0] .= "i";
      else
        return array();
    }
    if(gettype($value) === "boolean"){
      $valueInt = intval($dataQuery[$key]);
      $dataByReference[$key] = &$valueInt;
    }
    else
      $dataByReference[$key] = &$dataQuery[$key];
  }
  return $dataByReference;
}

//Prepares and executes the prepared statement
function ExecutePS(string $query, array $dataQuery): mysqli_stmt
{
  if (!($stmt = $GLOBALS['mysqli']->prepare($query)))
    ExitProgram(406, returnMessage("",406,"Prepare Failed"),array('Errno'=>$GLOBALS['mysqli']->errno,'Error'=>$GLOBALS['mysqli']->error));

  $dataQueryF = FormArrayPS($dataQuery);

  if(empty($dataQueryF))
    ExitProgram(406, returnMessage("",406, "Array Error"));
    
  call_user_func_array(array($stmt,'bind_param'), $dataQueryF);
  
  $stmt->execute();
  
  return $stmt;
}

//send error message to user
function sendErrorMessageStripeToUser($e, string $customError = "")
{
  $body = $e->getJsonBody();
  $err  = $body['error'];
  $error = 'Stripe Error: ' . $err['message'] . " ". $customError;
  ExitProgram(406, returnMessage("",406,$error));                          
}


function json_decodePM($postArray): array{
  if(is_array($postArray))
    return $postArray;
  elseif (is_string($postArray)) {
    return json_decode($postArray,true);
  }
}


function ReadArrayFiles(&$file_post) {

  $file_ary = array();
  $file_count = count($file_post['name']);
  $file_keys = array_keys($file_post);

  for ($i=0; $i<$file_count; $i++) {
    foreach ($file_keys as $key) {
      $file_ary[$i][$key] = $file_post[$key][$i];
    }
  }

  return $file_ary;
}

?>