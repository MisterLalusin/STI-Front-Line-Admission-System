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
		function editprofileClick()
		{
			location.replace(\"editprofile.php\");
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
	<tt>Profile</tt>
</center>

</div>

<hr style=\"border-color:lightgray; border-width:0.5;\">

</div>";


if ($connection->connect_error) {
    die("Connection failed: " . $connection->connect_error);
} 
$sql = "SELECT username, password, fullname, age, address, contactnumber, userlevel FROM tblofficers WHERE username='$username'";
$result = $connection->query($sql);
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        echo "
		
<img style=\"height:30; position:relative; left:340; top:15;\" src=\"images\\editIC.png\" onclick=\"editprofileClick()\">
		
<br>
<center><img src=\"images\accountIC.png\" width=\"169\"></center>
<br>
		
<table>
	<tr>
		<td align=\"right\" width=\"40%\"><tt><big>Full Name </big></tt><td>
		<td align=\"center\" width=\"5%\"><tt><big>:</big></tt><td>
		<td width=\"55%\"><tt><big>". $row["fullname"]."</big></tt><td>
	</tr>
	<tr>
		<td align=\"right\" width=\"40%\"><tt><big>Age <td>
		<td align=\"center\" width=\"5%\"><tt><big>:</big></tt><td>
		<td width=\"55%\"><tt><big>". $row["age"]."</big></tt><td>
	</tr>
	<tr>
		<td align=\"right\" width=\"40%\"><tt><big>Address <td>
		<td align=\"center\" width=\"5%\"><tt><big>:</big></tt><td>
		<td width=\"55%\"><tt><big>". $row["address"]."</big></tt><td>
	</tr>
	<tr>
		<td align=\"right\" width=\"40%\"><tt><big>Contat Number </big></tt><td>
		<td align=\"center\" width=\"5%\"><tt><big>:</big></tt><td>
		<td width=\"55%\"><tt><big>". $row["contactnumber"]."</big></tt><td>
	</tr>
	<tr>
		<td align=\"right\" width=\"40%\"><tt><big>Username </big></tt><td>
		<td align=\"center\" width=\"5%\"><tt><big>:</big></tt><td>
		<td width=\"55%\"><tt><big>". $row["username"]."</big></tt><td>
	</tr>
</table>

";
    }
}
$connection->close();

echo "


		</div>
	</body>
</html>"
?>