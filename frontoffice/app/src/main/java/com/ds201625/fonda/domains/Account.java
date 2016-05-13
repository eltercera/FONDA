package com.ds201625.fonda.domains;

import java.util.ArrayList;

/**
 * Created by Katherina Molina on 10/05/2016.
 */
public class Account extends BaseEntity {

    private Table table;
    private ArrayList<DishOrder> listDish;

    public Account() {
        super();
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

}
