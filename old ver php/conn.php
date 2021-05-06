<?php

try
{
	$dbh = new PDO("mysql:host=localhost;dbname=diplom_users","root" , "");
	
}catch(Exception $e)
{
	die("ERROR ".$e->getMessage());
}


?>