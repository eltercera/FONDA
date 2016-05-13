package com.ds201625.fonda.domains;

import java.security.Timestamp;
import java.util.ArrayList;
import java.util.Date;

/**
 * Created by Katherina Molina on 10/05/2016.
 */
public class Account extends BaseEntity {

    private Table table;
    private ArrayList<DishOrder> listDish;
    private Date date;
    private float tax;
    private float total;
    private float subtotal;

    public Account() {
        super();
    }

    public Account(Table table, ArrayList<DishOrder> listDish, Date date ,float tax,float total,float subtotal) {
        this.table = table;
        this.listDish = listDish;
        this.date = date;
        this.tax = tax;
        this.total = total;
        this.subtotal = subtotal;
    }


    public Account(ArrayList<DishOrder> listDish) {
        this.listDish = listDish;
    }

    public Table getTable() {
        return table;
    }

    public void setTable(Table table) {
        this.table = table;
    }

    public ArrayList<DishOrder> getListDish() {return listDish;}

    public void setListDish(ArrayList<DishOrder> listDish) {
        this.listDish = listDish;
    }

    public void addDish(DishOrder dish)
    {
        listDish.add(dish);
    }

    public Date getDate() {return date;}

    public void setDate(Date date) {
        this.date = date;
    }

    public float getTax() {return tax;}

    public void setTax(Float tax) {
        this.tax = tax;
    }

    public float getTotal() {
        return total;
    }

    public void setTotal(Float total) {
        this.total = total;
    }

    public float getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(Float subtotal) {
        this.subtotal = subtotal;
    }

}
