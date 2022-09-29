<?php
include "dbConnection.php";

$userName = $_POST['userName'];
$email = $_POST['email'];
$pass = hash("sha256", $_POST['pass']);
$data = "";

$sql = "SELECT users.Nombre From registro.users WHERE users.Nombre = '$userName'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
{
  $data = array('done' => false, 'message' => " Error nombre de usuario ya existe");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}
else
{
  $sql = "SELECT users.email From registro.users WHERE users.email = '$email'";
  $result = $pdo->query($sql);

  if($result->rowCount() > 0)
  {
    $data = array('done' => false, 'message' => " Error email ya existe");
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();
  }
  else
  {
    $sql = "INSERT INTO registro.users SET users.Nombre = '$userName', users.email = '$email',  users.password = '$pass'";
    $result = $pdo->query($sql);

    $data = array('done' => false, 'message' => " Usuario creado");
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();
  }

}

 ?>
