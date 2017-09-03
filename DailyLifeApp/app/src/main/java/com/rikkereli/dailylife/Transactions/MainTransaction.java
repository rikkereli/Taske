package com.rikkereli.dailylife.Transactions;

import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.time.*;
import org.joda.time.DateTime;

/**
 * Created by Rikke on 02/09/2017.
 */

/**
 * The format of a transaction from the server
 */
public class MainTransaction {

    private int iD;
    private int userId;
    private float amountOfMoney;
    private DateTime dateTime ;
    private String comment;
    private String place;

    public MainTransaction(int iD, int userId, float amountOfMoney, DateTime dateTime, String comment, String place) {
        this.iD = iD;
        this.userId = userId;
        this.amountOfMoney = amountOfMoney;
        this.dateTime = dateTime;
        this.comment = comment;
        this.place = place;
    }

    public int getiD() {
        return iD;
    }

    public int getUserId() {
        return userId;
    }

    public float getAmountOfMoney() {
        return amountOfMoney;
    }

    public DateTime getDateTime() {
        return dateTime;
    }

    public String getComment() {
        return comment;
    }

    public String getPlace() { return place; }

    public String toString() {
        return "ID: " + iD + ", user ID: " + userId + ", amountOfMoney: " + amountOfMoney + ", date and time: " + dateTime.toString() + ", comment: " + comment + ".";
    }

    public DateTime GetDateTimeString() {
        return dateTime;
    }
}
