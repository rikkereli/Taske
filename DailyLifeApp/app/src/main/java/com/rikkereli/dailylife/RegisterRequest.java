package com.rikkereli.dailylife;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Rikke on 21/08/2017.
 */

public class RegisterRequest extends StringRequest{

    private static  final String REGISTER_REQUEST_URL = "http://rikkereli.000webhostapp.com/Register.php";
    private Map<String, String> params;

    public RegisterRequest(String name, String username, int age, String password, Response.Listener<String> listener){

        super(Method.POST, REGISTER_REQUEST_URL, listener, null);
        params = new HashMap<>();
        params.put("name", name);
        params.put("password", password);
        params.put("age", age + "");
        params.put("username", username);
    }

    @Override
    public Map<String, String> getParams() {
        return params;
    }
}
