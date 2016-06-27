package com.ds201625.fonda.domains;

import java.util.List;
/**
 * Created by rrodriguez on 5/4/16.
 */
public class Restaurant extends Company {

    private String logo;
    private Coordinate coordinate;
    private RestaurantCategory restaurantCategory;
    private Zone zone;
    private String address;
    private Boolean favorite;

    private List<Table> tables;


    public Restaurant () {
        super();
    }

    public Restaurant (int id) {
        this.setId(id);
    }

    public Restaurant (String name,String address, RestaurantCategory restaurantCategory) {
        //thi.logo = logo;
        this.address = address;
        this.restaurantCategory = restaurantCategory;
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
        return restaurantCategory;
    }

    public void setRestaurantCategory(RestaurantCategory restaurantCategory) {
        this.restaurantCategory = restaurantCategory;
    }

    public List getListTable() {
        return tables;
    }

    public void setListTable(List tables) {
        this.tables = tables;
    }

    public Boolean getFavorite() {
        return favorite;
    }

    public void setFavorite(Boolean favorite) {
        this.favorite = favorite;
    }

    public Coordinate getCoordinate() { return coordinate; }

    public void setCoordinate(Coordinate coordinate) { this.coordinate = coordinate; }

    public Zone getZone() { return zone; }

    public void setZone(Zone zone) { this.zone = zone; }

}
