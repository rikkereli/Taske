package com.rikkereli.dailylife.Transactions;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Rikke on 08/09/2017.
 */

public class MakeMainTransactionRequest extends StringRequest{

    private static final String TRANSACTION_REQUEST_URL = "http://rikkereli.000webhostapp.com/AddMainTransactions.php";
    private Map<String,String> params;

    public MakeMainTransactionRequest(int userID, float amountOfMoney, String date, String comment, String place, boolean isInsert, Response.Listener<String> listener) {
        super(Method.POST, TRANSACTION_REQUEST_URL, listener, null);

        int isInsertInt = isInsert ? 1 : 0;
        params = new HashMap<>();
        params.put("userID", userID + "");
        params.put("amountOfMoney", amountOfMoney+"");
        params.put("date", date);
        params.put("comment", comment);
        params.put("place", place);
        params.put("isInsert", isInsertInt+ "");
    }

    @Override
    public Map<String, String> getParams() {return params; }
}



















