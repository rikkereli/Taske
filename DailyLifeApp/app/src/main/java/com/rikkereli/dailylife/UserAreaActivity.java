package com.rikkereli.dailylife;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.TextView;

public class UserAreaActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_area);

        final EditText etUsername = (EditText) findViewById(R.id.etUsername);
        final EditText etAge = (EditText) findViewById(R.id.etAge);
        final TextView welcomeMessage = (TextView) findViewById(R.id.tvWelcomeMessage);

        Intent intent = getIntent();
        String name = intent.getStringExtra("name");
        String username = intent.getStringExtra("username");
        //-1 is the default value. Indicates if it was not passed
        int age = intent.getIntExtra("age", -1);

        String message = name + "welcome to your user area";
        welcomeMessage.setText(message);
        etUsername.setText(username);
        //Empty string converts the int to string, so it can be displayed
        etAge.setText(age + "");

    }
}
