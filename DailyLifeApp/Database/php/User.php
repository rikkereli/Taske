
<?php
	//Create connection
    $con = mysqli_connect("localhost", "id2633903_rikkereli", "rikke2526", "id2633903_dailylifedatabase");
	//Get user input
    $username = $_POST["username"];
    $password = $_POST["password"];
    //prepare query to the connected database
    $statement = mysqli_prepare($con, "SELECT * FROM user WHERE username = ? AND password = ?");
	//Bind variables to the questionmarks
    mysqli_stmt_bind_param($statement, "ss", $username, $password);
	//Executes the query 
    mysqli_stmt_execute($statement);
    //See if the login was succesfull
    mysqli_stmt_store_result($statement);
	
    mysqli_stmt_bind_result($statement, $userID, $name, $age, $username, $password);
    
	//Makes an array to put the different data into. Data is seached by keyword
    $response = array();
    $response["success"] = false;  
    
	//Works sort of like a if statement
    while(mysqli_stmt_fetch($statement)){
        $response["success"] = true;  
        $response["name"] = $name;
        $response["age"] = $age;
        $response["username"] = $username;
        $response["password"] = $password;
    }
    
    echo json_encode($response);
?>