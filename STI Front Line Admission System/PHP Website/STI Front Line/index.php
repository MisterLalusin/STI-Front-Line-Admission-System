<?php
require('connect.php');

if(!isset($_COOKIE['SessionUName']) || !isset($_COOKIE['SessionUPass'])) {
    setcookie('SessionUName', null);
    setcookie('SessionUPass', null);
    $_COOKIE['SessionUName'] = null;
    $_COOKIE['SessionUPass'] = null;
}

$username = $_COOKIE["SessionUName"];
$password = $_COOKIE["SessionUPass"];

$query = "SELECT * FROM `tblofficers` WHERE username='$username' and Password='$password'";
 
$result = mysqli_query($connection, $query) or die(mysqli_error($connection));
$count = mysqli_num_rows($result);

if ($count == 1){
	header( 'Location: home.php' ) ;
}
else{
	echo "<html>
	<head>
		<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"images\stifrontlineIC.png\" />
		<title>STI Front Line</title>
		<!--CSS Below-->
		<link rel=\"stylesheet\" type=\"text/css\" href=\"css/default.css\">
		<!--CSS Above-->
		<!--JS Below-->
		<!--JS Above-->
	</head>
	<body>
		<center>
		<div class=\"login\">

				<hr style=\"border-color:black; border-width:0.5px;\">

				<img src=\"images\\indexdisplay.png\" width=\"169\" style=\"float:inherit;\">
				
				<form id=\"login-form\" method=\"post\" action=\"redirect.php\" >

				<input style=\"margin:2; width:300; height:50; font-size:20; padding-left:10; padding-right:10 -webkit-border-radius:5px; border-radius: 5px; \" type=\"text\" placeholder=\"Enter Username\" name=\"uname\" required>
				 
				<br><br>

				<input style=\"margin:2; width:300; height:50; font-size:20; padding-left:10; padding-right:10 -webkit-border-radius:5px; border-radius: 5px; \" type=\"password\" placeholder=\"Enter Password\" name=\"upass\" required>
				
				<br><br>
				
				<input style=\"margin:2; width:300; height:50; font-size:20; padding-left:10; padding-right:10 background:#ccc; -webkit-border-radius:5px; border-radius: 5px;  \" type=\"submit\" value=\"Login\">
				
				</form>
			
		</div>
		</center>
	</body>
</html>";
}
?>