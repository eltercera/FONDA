package com.ds201625.fonda.domains;

/**
 * Created by Adri on 06/05/2016.
 */
public class RestaurantCategory {

    private String nameCategory;

    public RestaurantCategory () {
        super();
    }

    public RestaurantCategory (String nameCategory) {
        this.nameCategory = nameCategory;
    }

    public String getNameCategory() {
        return nameCategory;
    }

    public void setNameCategory(String nameCategory) {
        this.nameCategory = nameCategory;
    }

}
