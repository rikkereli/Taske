package com.rikkereli.dailylife.RecyclerViewTransactions;

/**
 * Created by Rikke on 29/08/2017.
 */

public class ListItem {

    private String head;
    private String desc;

    public ListItem(String head, String desc) {
        this.head = head;
        this.desc = desc;
    }

    public String getHead() {
        return head;
    }

    public String getDesc() {
        return desc;
    }
}
