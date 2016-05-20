package com.ds201625.fonda.domains;

import java.util.List;
/**
 * Created by rrodriguez on 5/4/16.
 */
public class Restaurant extends Company {

    private String logo;
    private String address;
    private RestaurantCategory category;
    private List<Table> tables;

    public Restaurant () {
        super();
    }

    public Restaurant (String name,String address, RestaurantCategory category) {
        //thi.logo = logo;
        this.address = address;
        this.category = category;
        this.category = category;
        this.setName(name);
    }

    public String getLogo() {
        return logo;
    }

    public void setLogo(String logo) {
        this.logo = logo;
    }

    public String getAddress() {return address;}

    public void setAddress(String address) {
        this.address = address;
    }

    public RestaurantCategory getRestaurantCategory() {
        return category;
    }

    public void setRestaurantCategory(RestaurantCategory category) {
        this.category = category;
    }

    public List getListTable() {
        return tables;
    }

    public void setListTable(List tables) {
        this.tables = tables;
    }
}
