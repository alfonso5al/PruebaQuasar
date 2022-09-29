<?php
include "dbConnection.php";
$email = $_POST['email'];
$pass = hash("sha256", $_POST['pass']);
$data = "";

$sql = "SELECT users.email From registro.users WHERE users.email = '$email' AND users.password = '$pass'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
{
  $data = array('done' => true, 'message' => " Bienvenido ");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}
else {
  $data = array('done' => false, 'message' => " Correo o contraseña incorrectos");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();

}
 ?>
