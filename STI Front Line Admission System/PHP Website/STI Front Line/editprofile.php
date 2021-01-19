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
	<tt>Edit Profile</tt>
</center>

</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";


	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 
		
if(isset($_POST['type'])){
require_once("connect.php");
$updateage = $_POST['updateage'];
$updateaddress = $_POST['updateaddress'];
$updatecontactnumber = $_POST['updatecontactnumber'];
$query="UPDATE tblOfficers SET age=". $updateage .",address='". $updateaddress ."',contactnumber='". $updatecontactnumber ."' WHERE username='". $username. "'";

if (strlen($updatecontactnumber)!=11) {
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
	echo '<script> alert("Informations are reset to default."); </script>';
	echo '<script> location.replace("editprofile.php"); </script>';
	ob_end_flush();
}

else {

if ($connection->query($query) === TRUE) {
    echo "
	<center><br><br><br><br><br>
	<img width=\"200\" src=\"images\\successIC.png\"><br>
	<p>Your informations were updated.</p>
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
	
$sql = "SELECT username, password, fullname, age, address, contactnumber, userlevel FROM tblofficers WHERE username='$username'";
$result = $connection->query($sql);
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
		echo "
<tt>
<form action=\"$_SERVER[PHP_SELF]\" method=\"post\" enctype=\"multipart/form-data\">
Age: <br>
<input type=\"number\" value=\"";

echo $row["age"];

echo "\"style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"updateage\" required><br>
Address: <br>
<input type=\"text\" value=\"";

echo $row["address"];

echo "\"style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"updateaddress\" required><br>
Contact Number: <br>
<input type=\"number\" value=\"";

echo $row["contactnumber"];

echo "\"style=\"width:100%;margin-top:5;margin-bottom:5;-webkit-border-radius:5px; border-radius: 5px;font-size:16;\" name=\"updatecontactnumber\" required><br>
<input type=\"submit\" class=\"btn btn-primary\" style=\"width:20%;margin-top:5;margin-bottom:5;float:right;-webkit-border-radius:0px; border-radius: 5px;font-size:16;\" value=\"Submit\" name=\"type\" value=\"Insert\">
<input type=\"button\" style=\"width:40%;margin-top:5;margin-bottom:5;float:right;-webkit-border-radius:0px; border-radius: 5px;font-size:16;margin-right:2;\" name=\"type\" value=\"Update Password\" onclick=\"updatepassword()\">
</form>
</tt>
";
	}
}
	



}
	
	echo "</div>";
	$connection->close();


echo "		</div>
		
	</body>
</html>"
?>