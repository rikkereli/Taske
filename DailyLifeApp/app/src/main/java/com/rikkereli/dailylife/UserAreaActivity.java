package com.rikkereli.dailylife;

import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.android.volley.Response;

import org.json.JSONException;
import org.json.JSONObject;

public class UserAreaActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);

        //Set link between this class and the activity_register
        setContentView(R.layout.activity_user_area);

        final Button bBudget = (Button) findViewById(R.id.bBudget);

        bBudget.setOnClickListener(new View.OnClickListener() {

            public void onClick(View view) {
                Intent intent = new Intent(UserAreaActivity.this, BudgetMenuActivity.class);
                UserAreaActivity.this.startActivity(intent);
            }
        });


    }
}
