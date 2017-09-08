package com.rikkereli.dailylife.Transactions;

import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.rikkereli.dailylife.Login.RegisterActivity;
import com.rikkereli.dailylife.Login.RegisterRequest;
import com.rikkereli.dailylife.R;

import org.json.JSONException;
import org.json.JSONObject;

public class MakeMainTransactionActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_make_main_transaction);


        //Set all the fields from the design
        final EditText etPrice = (EditText) findViewById(R.id.etPrice);
        final EditText etComment = (EditText) findViewById(R.id.etComment);
        final EditText etPlace = (EditText) findViewById(R.id.etPlace);
        final TextView etDatetime = (TextView) findViewById(R.id.tvDisplayDateAndTime);

        final Button bFinish = (Button) findViewById(R.id.bFinish);

        bFinish.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                    final float price = Float.parseFloat(etPrice.getText().toString());
                    final String comment = etComment.getText().toString();
                    final String place = etPlace.getText().toString();
                    final String dateTime = etDatetime.getText().toString();

                    Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if (success) {
                                Intent intent = new Intent(MakeMainTransactionActivity.this, MakeMainTransactionRequest.class);
                                MakeMainTransactionActivity.this.startActivity(intent);
                            } else {
                                AlertDialog.Builder builder = new AlertDialog.Builder(MakeMainTransactionActivity.this);
                                builder.setMessage("Transaction failed")
                                        .setNegativeButton("Retry", null)
                                        .create()
                                        .show();
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }

                };
                MakeMainTransactionRequest mainTransactionRequest = new MakeMainTransactionRequest(1, price, dateTime, comment, place, false, responseListener);
                RequestQueue queue = Volley.newRequestQueue(MakeMainTransactionActivity.this);
                queue.add(mainTransactionRequest);
            }
        });
    }
}










