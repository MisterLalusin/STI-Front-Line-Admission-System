<?php  
require('connect.php');

if (isset($_POST['uname']) and isset($_POST['upass'])){
	
$username = $_POST['uname'];
$password = $_POST['upass'];

$query = "SELECT * FROM `tblofficers` WHERE username='$username' and Password='$password'";
 
$result = mysqli_query($connection, $query) or die(mysqli_error($connection));
$count = mysqli_num_rows($result);

	if ($count == 1){
		echo "
	<html>
	<head>
		<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"images\stifrontlineIC.png\" />
		<title>STI Front Line</title>
		<!--CSS Below-->
		<link rel=\"stylesheet\" type=\"text/css\" href=\"css/default.css\">
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

		var username = \"$username\";
		var password = \"$password\";
		
		setCookie('SessionUName',username,7);
		setCookie('SessionUPass',password,7);
		
		window.setTimeout(function(){
			window.location.href = \"/STI Front Line/home.php\";
		}, 1000);

		</script>
		<!--JS Above-->
		
	</head>
	<body>
		<center>
		<div class=\"display\">

				<hr style=\"border-color:black; border-width:0.5px;\">

				<img src=\"images\\indexdisplay.png\" width=\"169\" style=\"float:inherit;\">
				
				<br><br><br>

				<h2><tt>Logged Successfully!</tt></h2>
				
			
		</div>
		</center>
	</body>
</html>";
	}
	else{echo "
	<html>
	<head>
		<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\"images\stifrontlineIC.png\" />
		<title>STI Front Line</title>
		<!--CSS Below-->
		<link rel=\"stylesheet\" type=\"text/css\" href=\"css/default.css\">
		<!--CSS Above-->
		
		<!--JS Below-->
		<script type='text/javascript'>
				
		window.setTimeout(function(){
			window.location.href = \"/STI Front Line/index.php\";
		}, 1000);

		</script>
		<!--JS Above-->
		
	</head>
	<body>
		<center>
		<div class=\"display\">

				<hr style=\"border-color:black; border-width:0.5px;\">

				<img src=\"images\\indexdisplay.png\" width=\"169\" style=\"float:inherit;\">
				
				<br><br><br>

				<h2><tt>Log In Failed!</tt></h2>

		</div>
		</center>
	</body>
</html>";
		}
	}
?>