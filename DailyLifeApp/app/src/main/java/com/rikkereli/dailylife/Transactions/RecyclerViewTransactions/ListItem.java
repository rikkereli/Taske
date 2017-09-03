package com.rikkereli.dailylife.Transactions.RecyclerViewTransactions;

/**
 * Created by Rikke on 29/08/2017.
 */

public class ListItem {

    private String head;
    private String desc;
    private String info;

    public ListItem(String head, String desc, String info) {
        this.head = head;
        this.desc = desc;
        this.info = info;
    }

    public String getHead() {
        return head;
    }

    public String getDesc() {
        return desc;
    }

    public String getInfo() { return info;}
}
