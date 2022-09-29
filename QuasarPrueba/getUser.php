<?php
include "dbConnection.php";

$email = $_POST['email'];


$sql = "SELECT users.Nombre FROM registro.users WHERE users.email = '$email'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
{
  while($row = $result->fetch(PDO::FETCH_ASSOC)) {
    $data = array('done' => true, 'message' => $row["Nombre"]);
    echo json_encode( $data );
  }
  exit();
}

 ?>
