package com.rikkereli.dailylife.Transactions;

import android.nfc.FormatException;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.rikkereli.dailylife.R;
import com.rikkereli.dailylife.Transactions.RecyclerViewTransactions.GetTransactionsRequest;
import com.rikkereli.dailylife.Transactions.RecyclerViewTransactions.ItemAdapter;
import com.rikkereli.dailylife.Transactions.RecyclerViewTransactions.ListItem;

import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Iterator;
import java.util.List;

public class SeeMainTransactionsActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private RecyclerView.Adapter adapter;


    private List<ListItem> listItems;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_see_transactions);
        getData();

    }

    public void getData() {

        String url = "http://rikkereli.000webhostapp.com/GetTransactions.php";

        Response.Listener<String> responseListener = new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                //region Listener
                try {
                    JSONObject jsonResponse = new JSONObject(response);
                    boolean success = jsonResponse.getBoolean("success");

                    if (success) {

                        Iterator keys = jsonResponse.keys();

                        String list = "";


                        List<String> keyList = new ArrayList<String>();

                        while (keys.hasNext()) {
                            String key = (String) keys.next();
                            if (isInteger(key)) {
                                keyList.add(key);
                            }
                        }
                        JSONArray jsonArray;
                        List<MainTransaction> mainTransactions = new ArrayList<>();
                        //Put the transactions in an array of main transactions
                        for (int i = 0; i < keyList.size(); i++) {
                            try {
                                jsonArray = jsonResponse.getJSONArray(keyList.get(i));
                                int thisID = jsonArray.getInt(0);
                                int userID = jsonArray.getInt(1);
                                float amountOfMoney = (float)jsonArray.getDouble(2);
                                DateTime date = stringToCalendar(jsonArray.getString(3));
                                String comment = jsonArray.getString(4);
                                String place = jsonArray.getString(5);
                                mainTransactions.add(new MainTransaction(thisID, userID, amountOfMoney, date, comment, place));
                            }
                            catch (Exception e) {
                                AlertDialog.Builder builder = new AlertDialog.Builder(SeeMainTransactionsActivity.this);
                                builder.setMessage(e.toString())
                                        .setNegativeButton("Retry", null)
                                        .create()
                                        .show();
                            }
                        }
                        makeRecyclerView(mainTransactions);
                    } else {
                        AlertDialog.Builder builder = new AlertDialog.Builder(SeeMainTransactionsActivity.this);
                        builder.setMessage("transaction find failed")
                                .setNegativeButton("Retry", null)
                                .create()
                                .show();
                    }
                } catch (JSONException e) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(SeeMainTransactionsActivity.this);
                    builder.setMessage("Exception" + e.toString())
                            .setNegativeButton("Error", null)
                            .create()
                            .show();
                }
                //endregion
            }

        };


        GetTransactionsRequest transactionRequest = new GetTransactionsRequest(responseListener);
        RequestQueue queue = Volley.newRequestQueue(SeeMainTransactionsActivity.this);

        queue.add(transactionRequest);

        queue.start();
    }

    public void makeRecyclerView(List<MainTransaction> mainTransactions) {

        recyclerView = (RecyclerView) findViewById(R.id.rvTransactions);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        listItems = new ArrayList<>();

        for (int i = 0; i < mainTransactions.size(); i++) {
            MainTransaction currentMainTransaction = mainTransactions.get(i);
            DateTimeFormatter dateTimeFormatter = DateTimeFormat.forPattern("yyyy-MM-dd HH:mm:ss");
            String dateTimeString = dateTimeFormatter.print(currentMainTransaction.getDateTime());
            ListItem listItem = new ListItem(
                    "Amount of money  " + currentMainTransaction.getAmountOfMoney() + "kr",
                    "Place " + currentMainTransaction.getPlace(),
                    "Date " + dateTimeString
            );
            listItems.add(listItem);
        }

        adapter = new ItemAdapter(listItems, this);

        recyclerView.setAdapter(adapter);
    }

    //region tools
    /**
     * Not written by me https://stackoverflow.com/questions/5439529/determine-if-a-string-is-an-integer-in-java
     *
     * @param s
     * @param radix
     * @return
     */
    public static boolean isInteger(String s, int radix) {
        if (s.isEmpty()) return false;
        for (int i = 0; i < s.length(); i++) {
            if (i == 0 && s.charAt(i) == '-') {
                if (s.length() == 1) return false;
                else continue;
            }
            if (Character.digit(s.charAt(i), radix) < 0) return false;
        }
        return true;
    }
    public static boolean isInteger(String s) {
        return isInteger(s, 10);
    }

    public DateTime stringToCalendar(String dateTime){

        try {
            String[] splitDatetime = dateTime.split("\\W");

            if(splitDatetime.length != 6) {
                throw new FormatException("Argument has to be 6 long when separeted, was " + splitDatetime.length + " long");
            }
            else {
                //Parse the entrances of the array to integer and make new gregorian calender
                int year = Integer.parseInt(splitDatetime[0]);
                int month = Integer.parseInt(splitDatetime[1]);
                int dayOfMonth = Integer.parseInt(splitDatetime[2]);
                int hour = Integer.parseInt(splitDatetime[3]);
                int minute = Integer.parseInt(splitDatetime[4]);
                int second = Integer.parseInt(splitDatetime[5]);
                return new DateTime(year, month, dayOfMonth, hour, minute, second);
            }

        }
        catch(Exception e) {
            return null;
        }
    }
    //endregion
}