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
		function setCookie(name,value,days) {
		var expires = \"\";
		if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days*24*60*60*1000));
        expires = \"; expires=\" + date.toUTCString();
		}
		document.cookie = name + \"=\" + (value || \"\")  + expires + \"; path=/\";
		}
		function updatepassword()
		{
			location.replace(\"updatepassword.php\");
		}
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
	<tt>Update Password</tt>
</center>

</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";


	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 
		
if(isset($_POST['type'])){
require_once("connect.php");
$currentpassword = $_POST['currentpassword'];
$newpassword = $_POST['newpassword'];
$confirmpassword = $_POST['confirmpassword'];
$query="UPDATE tblOfficers SET password=". $newpassword ." WHERE username='". $username. "'";

if ($password != $currentpassword) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>Incorect password.</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("updatepassword.php"); </script>';
	ob_end_flush();
}

else if (strlen($newpassword)<8) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>Password must be atleast 8 characters.</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("updatepassword.php"); </script>';
	ob_end_flush();
}

else if ($newpassword != $confirmpassword) {
	echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\failedIC.png\"><br>
	<p>New password doesn't match.</p>
	</center>
	";
	if (ob_get_level() == 0) ob_start();
		for ($i = 0; $i<2; $i++){  
			ob_flush();
			flush();
			sleep(2);
	}
	echo '<script> alert("Informations are cleared for security."); </script>';
	echo '<script> location.replace("updatepassword.php"); </script>';
	ob_end_flush();
}

else {

if ($connection->query($query) === TRUE) {
    echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\successIC.png\"><br>
	<p>Password updated.</p>
	</center>
	";
	echo "<script type=\"text/javascript\">setCookie('SessionUPass',". $newpassword .",7)</script>";

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
<form action=\"$_SERVER[PHP_SELF]\" method=\"post\" enctype=\"multipart/form-data\">
Current Password: <br>
<input type=\"password\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"currentpassword\" required><br>
New Password: <br>
<input type=\"password\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"newpassword\" required><br>
Confirm Password: <br>
<input type=\"password\" style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"confirmpassword\" required><br>
<input type=\"submit\" class=\"btn btn-primary\" style=\"width:40%;margin-top:5;margin-bottom:5;float:right;-webkit-border-radius:0px; border-radius: 5px;font-size:16;\" value=\"Update Password\" name=\"type\" value=\"Insert\">
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