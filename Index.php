<?php
//api для новостной программы
// получаем все значения

$id = $_GET["id"];
$login = $_GET["login"];
$pass = $_GET["pass"];

$familiya = $_GET["familiya"];
$imya = $_GET["imya"];
$otchestvo = $_GET["otchestvo"];

$dolzhnost = $_GET["dolzhnost"];
$role = $_GET["role"];

//создаем соединение

$lochost = "localhost";
$root1 = "root";
$root2 = "root";
$bdName = "diplom_users";
$conn = new MySqli($lochost, $root1, $root2, $bdName);

if($conn->connect_error){
	die("нет соединения"."<br>".$conn->connect_error);
}
//добавление в бд
$sql= "INSERT INTO `users`(`id`,`login`,`pass`,`familiya`,`imya`,`otchestvo`,`dolzhnost`,`role`) VALUES ('$id','$login','$pass','$familiya','$imya','$otchestvo','$dolzhnost','$role')";

if($conn->query($sql) === TRUE){
	echo "Добавлена запись в таблицу";
}else {
	echo "Ошибка".$sql."<br>".$conn->connect_error;
}

$conn->close();

?>
