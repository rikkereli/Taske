package com.rikkereli.dailylife.Transactions.RecyclerViewTransactions;


import android.os.AsyncTask;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.support.annotation.Nullable;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.AppCompatActivity;

import com.android.volley.toolbox.StringRequest;
import com.android.volley.Request;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.Response;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.io.*;
/**
 * Created by Rikke on 01/09/2017.
 */

public class GetTransactionsRequest extends StringRequest {


        private static  final String REGISTER_REQUEST_URL = "http://rikkereli.000webhostapp.com/GetTransactions.php";
        private Map<String, String> params;

        public GetTransactionsRequest(Response.Listener<String> listener){

            super(Method.POST, REGISTER_REQUEST_URL, listener, null);


        }

        @Override
        public Map<String, String> getParams() {
            return params;
        }
    }

