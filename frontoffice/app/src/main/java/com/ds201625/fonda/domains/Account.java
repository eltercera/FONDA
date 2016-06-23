package com.ds201625.fonda.domains;

import java.util.List;

/**
 * Created by Katherina Molina on 10/05/2016.
 */

/*
 Clase quee representa la cuenta del restaurant
 */
public class Account extends BaseEntity {

    /**
     *Table que define la mesa asociada a la cuenta
     */
    private Table table;

    /**
     *List<DishOrder> que define la lista de los platos ordenados
     */
    private List<DishOrder> listDish;

    /**
     *Commensal que define el comensal asociado a la cuenta
     */
    private Commensal commensal;

    /**
     Contructor de la clase cuenta
     */
    public Account() {
        super();
    }

    public Account(Table table, List<DishOrder> listDish) {
        this.table = table;
        this.listDish = listDish;
    }

    public Account(List<DishOrder> listDish) {
        this.listDish = listDish;
    }

    /**
     * Metodo que obtiene la nesa de la cuenta
     * @return table
     */
    public Table getTable() {
        return table;
    }

    /**
     * Metodo que asigna la nesa de la cuenta
     * @param table
     */
    public void setTable(Table table) {
        this.table = table;
    }

    /**
     * Metodo que obtiene la lista de platos de la cuenta
     * @return listDish
     */
    public List<DishOrder> getListDish() {return listDish;}

    /**
     * Metodo que asigna la lista de platos de la cuenta
     * @param listDish
     */
    public void setListDish(List<DishOrder> listDish) {
        this.listDish = listDish;
    }

    /**
     * Metodo que agrega un plato a la lista de platos de la cuenta
     * @param dish
     */
    public void addDish(DishOrder dish)
    {
        listDish.add(dish);
    }

    /**
     * Metodo que obtiene el comensal asociado a la cuenta
     * @return commensal
     */
    public Commensal getCommensal() {
        return commensal;
    }

    /**
     * Metodo que asigna el comensal a la cuenta
     * @param commensal
     */
    public void setCommensal(Commensal commensal) {
        this.commensal = commensal;
    }


}
