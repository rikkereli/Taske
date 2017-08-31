package com.rikkereli.dailylife;
/*
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.TextView;

public class UserAreaActivityMainMenu extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_area);

        Intent intent = getIntent();
        String name = intent.getStringExtra("name");
        String username = intent.getStringExtra("username");

        final TextView etAge = (TextView) findViewById(R.id.etAge);

        final TextView welcomeMessage = (TextView) findViewById(R.id.tvWelcomeMessage);

        final TextView etUsername = (TextView) findViewById(R.id.etUsername);

        int age = intent.getIntExtra("age", -1);
        //-1 is the default value. Indicates if it was not passed


        String message = name + " welcome to your user area";
        welcomeMessage.setText(message);
        etUsername.setText(username);
        //Empty string converts the int to string, so it can be displayed
        etAge.setText(age + "");
    }
*/