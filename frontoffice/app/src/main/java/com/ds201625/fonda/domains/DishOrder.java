package com.ds201625.fonda.domains;

/**
 * Created by Katherina Molina on 10/05/2016.
 */
public class DishOrder extends BaseEntity {

    private Dish dish;
    private int count;

    public DishOrder() {
        super();
    }

    public DishOrder(Dish dish, int count) {
        this.dish = dish;
        this.count = count;
    }

    public Dish getDish() {
        return dish;
    }

    public void setDish(Dish dish) {
        this.dish = dish;
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }
}
