<?php

header("Content-Type: text/html; charset=utf-8");
// регистрация

include "conn.php";

if (isset($_POST['id']) && isset($_POST['login']) && isset($_POST['pass']) && isset($_POST['familiya']) && isset($_POST['imya']) && isset($_POST['otchestvo']) && isset($_POST['dolzhnost']) && isset($_POST['role'])){
	
	$req=$dbh->prepare("INSERT INTO users(id,login,pass,familiya,imya,otchestvo,dolzhnost,role) VALUES (:id,:login,:pass,:familiya,:imya,:otchestvo,:dolzhnost,:role)");
	$req->execute(array(
		'id'=>$_POST['id'],
		'login'=>$_POST['login'],
		'pass'=>$_POST['pass'],
		'familiya'=>$_POST['familiya'],
		'imya'=>$_POST['imya'],
		'otchestvo'=>$_POST['otchestvo'],
		'dolzhnost'=>$_POST['dolzhnost'],
		'role'=>$_POST['role']
	))
}
?>