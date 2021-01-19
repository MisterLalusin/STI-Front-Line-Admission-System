<?php
$searchContent = "";
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
		
		function getCookie(name) {
			var nameEQ = name + \"=\";
			var ca = document.cookie.split(';');
			for(var i=0;i < ca.length;i++) {
			var c = ca[i];
			while (c.charAt(0)==' ') c = c.substring(1,c.length);
			if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
		}
			return null;
		}

		
		function home() {
			window.setTimeout(function(){
				window.location.href = \"/STI Front Line/home.php\";
			}, 1000);
				
		}
		function logout() {
			var result = confirm(\"Log Out?\");
			if (result == true) {
				setCookie('SessionUName',null,7);
				setCookie('SessionUPass',null,7);
				window.setTimeout(function(){
				window.location.href = \"/STI Front Line/index.php\";
				}, 3000);
			}
		}
		
		function profile() {
			setCookie('popuponstart','profile',7);
			location.replace(\"home.php\");
		}
		
		function officers() {
			setCookie('popuponstart','officers',7);
			location.replace(\"home.php\");
		}
		
		function openInNewTab(url) {
			var win = window.open(url, '_blank');
			win.focus();
		}
		function hideIframe() {
			document.getElementById('popupID').setAttribute(\"class\", \"hideitem\"); 
		}
		function startIframe() {
			window.setTimeout(function(){
				document.getElementById('popupID').setAttribute(\"class\", \"itematstart\"); 
			}, 600000);
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

<form name=\"searchForm\" id=\"searchForm\" method=\"post\" style=\"margin:0;\">
<img src=\"images\\stifrontlineLOGO.png\" width=\"69\" style=\"float:inherit;\">
<button onclick=\"home()\"><u>Home</u></button>|<button onclick=\"profile()\"><u>Profile</u></button>|<button onclick=\"officers()\"><u>Officers</u></button>|<button onclick=\"logout()\"><u>Log Out</u></button>
<span id=\"search\"></span><input type=\"text\" name=\"searchContent\" >&nbsp;<input type=\"submit\" id=\"searchData\" class=\"button\" name=\"searchData\" value=\"Search\"></span>
</form>

</div>


</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";

echo "
<div id=\"popupID\">
<img src=\"images\\popupBG.png\" style=\"width:100%;height:100%;position:fixed;top:0;left:0;\">
<iframe id=\"popupIframe\"></iframe>
<img src=\"images\\closeIC.png\" style=\"width:50;height:50;position:fixed;top:0;bottom:500;left:400;right:0;margin:auto;\" onclick=\"hideIframe()\">
</div>
<script type=\"text/javascript\">

setCookie('loadfirstCookie','true',7);

var loadfirstCookie = getCookie(\"loadfirstCookie\");

if (((getCookie(\"popuponstart\"))=='profile')) {
	startIframe();
	var newSrc = 'profile.php';
	document.getElementById(\"popupIframe\").src=newSrc;
}

else if (((getCookie(\"popuponstart\"))=='officers')) {
	startIframe();
	var newSrc = 'officers.php';
	document.getElementById(\"popupIframe\").src=newSrc;
}
else {
	hideIframe();
}

setCookie('popuponstart','null',7);

</script>
";

    $frstWRD = "";
    $scndWRD = "";
    $thrdWRD = "";
    $frthWRD = "";
    $fthWRD = "";

    if(isset($_POST['searchContent'])){
		$searchContent = $_POST['searchContent'];
		
		$input = $searchContent;
		
		$split = explode(' ',$input);
		
		if (str_word_count($searchContent) == 5) {
			$frstWRD = $split[0];
			$scndWRD = $split[1];
			$thrdWRD = $split[2];
			$frthWRD = $split[3];
			$fthWRD = $split[4];
		}
		else if (str_word_count($searchContent) == 4) {
			$frstWRD = $split[0];
			$scndWRD = $split[1];
			$thrdWRD = $split[2];
			$frthWRD = $split[3];
			$fthWRD = "▀*▀*▀*▀";
		}
		else if (str_word_count($searchContent) == 3) {
			$frstWRD = $split[0];
			$scndWRD = $split[1];
			$thrdWRD = $split[2];
			$frthWRD = "▀*▀*▀*▀";
			$fthWRD = "▀*▀*▀*▀";
		}
		else if (str_word_count($searchContent) == 2) {
			$frstWRD = $split[0];
			$scndWRD = $split[1];
			$thrdWRD = "▀*▀*▀*▀";
			$frthWRD = "▀*▀*▀*▀";
			$fthWRD = "▀*▀*▀*▀";
		}
		else if (str_word_count($searchContent) == 1) {
			$frstWRD = $split[0];
			$scndWRD = "▀*▀*▀*▀";
			$thrdWRD = "▀*▀*▀*▀";
			$frthWRD = "▀*▀*▀*▀";
			$fthWRD = "▀*▀*▀*▀";
		}
		else if (str_word_count($searchContent) == 0) {
			$frstWRD = "▀*▀*▀*▀";
			$scndWRD = "▀*▀*▀*▀";
			$thrdWRD = "▀*▀*▀*▀";
			$frthWRD = "▀*▀*▀*▀";
			$fthWRD = "▀*▀*▀*▀";
		}
    }

	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 

	$sql = "SELECT student, course, file FROM tblenrollees WHERE studentid LIKE '%${searchContent}%' OR student LIKE '%${searchContent}%' OR course LIKE '%${searchContent}%' OR student LIKE '%${frstWRD}%' OR student LIKE '%${scndWRD}%' OR student LIKE '%${thrdWRD}%' OR student LIKE '%${frthWRD}%' OR student LIKE '%${fthWRD}%'";
	
	
	$result = $connection->query($sql);
	echo "<div class=\"addpaddingtodata\">";
	if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
		$filename =  $row["file"] ;
        echo "<span class=\"text\">". $row["student"]. " <a href=\"data\\$filename\" target=\"_blank\"></span><small>[view data]</small></a><small><small><br>". $row["course"] ."</small></small><hr style=\"border-color:lightgray; border-width:0.5;\">";
    }
	}
	echo "</div>";
	$connection->close();

	$reload = true;
	
	//Check new data
	$currentEnrollees = null;
	$firstLOAD = true;
	
	if (ob_get_level() == 0) ob_start();
	for ($i = 1; $i!=0; $i++){

	require('connect.php');
	
	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 

	foreach($connection->query('SELECT COUNT(*) FROM tblenrollees') as $row) {
		
		if ($firstLOAD == true) {
			$currentEnrollees = $row['COUNT(*)'];
			$firstLOAD = false;
		}

		if ($row['COUNT(*)'] != $currentEnrollees) {
			$i = -0;
			echo '<script> location.replace("home.php"); </script>';
		}
	}

		$connection->close();


		ob_flush();
		flush();
	
		set_time_limit(0);
	
		sleep(5);
	}	ob_end_flush();
	
	//Check new data

echo "		</div>	
	</body>
</html>"
?>