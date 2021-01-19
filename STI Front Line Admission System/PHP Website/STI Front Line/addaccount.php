<?php
echo "
<html>
	<head>
		<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"images\stifrontlineIC.png\" />
		<title>STI Front Line</title>
		<!--CSS Below-->
		<link rel=\"stylesheet\" type=\"text/css\" href=\"css/popup.css\">
		<!--CSS Above-->
		<!--JS Below-->
		<script type='text/javascript'>
		</script>
		<!--JS Above-->
	</head>
	<body>
		<div class=\"content\">
";

/*Validation Below*/
require('connect.php');
$username = $_COOKIE["SessionUName"];
$password = $_COOKIE["SessionUPass"];

$query = "SELECT * FROM `tblofficers` WHERE username='$username' and Password='$password'";
 
$result = mysqli_query($connection, $query) or die(mysqli_error($connection));
$count = mysqli_num_rows($result);

if ($count == 1){
}
else{
	header( 'Location: index.php' ) ;
}
/*Validation Above*/

echo "
<div class=\"grayline\">

<hr style=\"border-color:lightgray; border-width:0.5;\">

<div class=\"graycontent\">

<div class=\"sitebutton\">

</div>

<center>
	<tt>Add Account</tt>
</center>

</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";


	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 
		
if(isset($_POST['type'])){
require_once("connect.php");
$addfullname = $_POST['addfullname'];
$addage = $_POST['addage'];
$addaddress = $_POST['addaddress'];
$addcontactnumber = $_POST['addcontactnumber'];
$addusername = $_POST['addusername'];
$addpassword = $_POST['addpassword'];
$userlevel = 'Admin';
$chkuname = $addusername . '' . '▀';
$query="insert into tblOfficers (username,password,fullname,age,address,contactnumber,userlevel)values('$addusername','$addpassword','$addfullname','$addage','$addaddress','$addcontactnumber','$userlevel')";

if (strlen($addcontactnumber)!=11) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>Invalid contact number.</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("addaccount.php"); </script>';
	ob_end_flush();
}
else if (strpos($chkuname, '@sti.edu▀') == false) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>A valid username must end with @sti.edu</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("addaccount.php"); </script>';
	ob_end_flush();
}
else if (strlen($addusername)<9) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>A valid username must end with @sti.edu</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("addaccount.php"); </script>';
	ob_end_flush();
}
else if (strlen($addpassword)<8) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>Password must be atleat 8 characters.</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("addaccount.php"); </script>';
	ob_end_flush();
}

else {

if ($connection->query($query) === TRUE) {
    echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\successIC.png\"><br>
	<p>$addfullname was added as admin.</p>
	</center>
	";
} 
else {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>Username maybe used by an existing user.</p>
	</center>
	";
}

}

}
else {

echo "
<tt>
Fullname: <br>
<form action=\"$_SERVER[PHP_SELF]\" method=\"post\" enctype=\"multipart/form-data\">
<input type=\"text\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addfullname\" required><br>
Age: <br>
<input type=\"number\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addage\" required><br>
Address: <br>
<input type=\"text\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addaddress\" required><br>
Contact Number: <br>
<input type=\"number\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addcontactnumber\" required><br>
User Name: <br>
<input type=\"text\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addusername\" required><br>
Password: <br>
<input type=\"password\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"addpassword\" required><br>
<input type=\"submit\" class=\"btn btn-primary\" style=\"width:20%;margin-top:5;margin-bottom:5;float:right;-webkit-border-radius:0px; border-radius: 5px;font-size:16;\" value=\"Submit\" name=\"type\" value=\"Insert\">
</form>
</tt>
";

}
	
	echo "</div>";
	$connection->close();


echo "		</div>
		
	</body>
</html>"
?>