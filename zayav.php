<?php
//api для новостной программы
// получаем все значения заявки

$nazvanie_zayavki = $_GET["nazv"];
$comm_zayavki = $_GET["comm"];
$date_zayavki = $_GET["date"];

$location_zayavki = $_GET["locat"];
$category_zayavki = $_GET["cat"];
$status_zayavki = $_GET["status"];

$space = "2";
$space1 = "-";

//создаем соединение
$lochost = "localhost";
$root1 = "root";
$root2 = "root";
$bdName = "diplom_users";
$conn = new MySqli($lochost, $root1, $root2, $bdName);
if($conn->connect_error)
{
	die("нет соединения"."<br>".$conn->connect_error);
}

if( $nazvanie_zayavki != NULL)
{
	$sql= "INSERT INTO `zayavki`(`id_z`,`name`,`comment`,`date`,`location`,`category`,`status`,`p_journalist`,`p_montazher`,`p_vipmen`,`p_semgr1`,`p_semgr2`) VALUES (NULL,'$nazvanie_zayavki','$comm_zayavki','$date_zayavki','$location_zayavki','$category_zayavki','$status_zayavki','$space1','$space1','$space1','$space1','$space1')";

}
//добавление в бд заявку
//$sql= "INSERT INTO `zayavki`(`id_z`,`name`,`comment`,`date`,`location`,`category`,`status`,`p_journalist`,`p_montazher`,`p_vipmen`,`p_semgr1`,`p_semgr2`) VALUES (NULL,'$nazvanie_zayavki','$comm_zayavki','$date_zayavki','$location_zayavki','$category_zayavki','$status_zayavki','$space1','$space1','$space1','$space1','$space1')";

if($conn->query($sql) === TRUE AND $nazvanie_zayavki != NULL){
	echo "Добавлена запись в таблицу";
}else {
	echo "Ошибка - - - - -  ".$sql."<br>".$conn->connect_error;
}

$conn->close();

?>
