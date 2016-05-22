package com.ds201625.fonda.domains;

/**
 * Created by Katherina Molina on 10/05/2016.
 */

/*
 Clase quee representa el pedido del cliente
 */
public class DishOrder extends BaseEntity {

    /**
     * Dish que define el dish asociado a la cuenta
     */
    private Dish dish;

    /**
     * Integer que define la cantidad de platos
     */
    private int count;

    /**
     Contructor de la clase PlatoOrdenado
     */
    public DishOrder() {
        super();
    }

    public DishOrder(Dish dish, int count) {
        this.dish = dish;
        this.count = count;
    }


    /**
     * Metodo que obtiene el plato de la orden
     * @return dish
     */
    public Dish getDish() {
        return dish;
    }

    /**
     * Metodo que asigna el plato a la orden
     * @param dish
     */
    public void setDish(Dish dish) {
        this.dish = dish;
    }

    /**
     * Metodo que obtiene la cantidad del plato de la orden
     * @return count
     */
    public int getCount() {
        return count;
    }

    /**
     * Metodo que asigna la cantidad del plato a la orden
     * @param count
     */
    public void setCount(int count) {
        this.count = count;
    }
}
