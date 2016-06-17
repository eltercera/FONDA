package com.ds201625.fonda.domains.entities;

/**
 * Created by Adri on 06/05/2016.
 */
public class RestaurantCategory extends NounBaseEntity {

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
