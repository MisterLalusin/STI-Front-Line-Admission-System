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
		function addofficerClick()
		{
			location.replace(\"addaccount.php\");
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
	<tt>Officers</tt>
</center>

</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";


	if ($connection->connect_error) {
		die("Connection failed: " . $connection->connect_error);
	} 

	$sql = "SELECT fullname, username FROM tblofficers";
	
	
	$result = $connection->query($sql);
	echo "<div class=\"addpaddingtodata\">";
	if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        echo "
		<img style=\"width:40; position:fixed; bottom:10; right:10; margin:auto;\" src=\"images\\addIC.png\" onclick=\"addofficerClick()\">
		
		<span class=\"text\">". $row["fullname"]. " </span><small></small><small><small><br>". $row["username"] ."</small></small><hr style=\"border-color:lightgray; border-width:0.5;\">";
    }
	}
	echo "</div>";
	$connection->close();


echo "		</div>
		
	</body>
</html>"
?>