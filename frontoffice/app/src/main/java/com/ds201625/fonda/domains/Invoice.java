package com.ds201625.fonda.domains;

import java.util.Date;

/**
 * Created by Adri on 06/05/2016.
 */
public class Invoice extends BaseEntity{

    private float tip;
    private Date date;
    private float tax;
    private float total;
    private Restaurant restaurant;
    private Profile profile;
  //  private InvoiceStatus status;

    public Invoice() {
        super();
    }

    public Invoice(float tip, float tax, float total, Restaurant restaurant, Date date,
                   Profile profile) {
        this.tip = tip;
        this.tax = tax;
        this.total = total;
        this.restaurant = restaurant;
        this.date = date;
        this.profile= profile;
    }

    public float getTip() {
        return tip;
    }

    public void setTip(Float tip) {
        this.tip = tip;
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

    public Date getDate() {return date;}

    public void setDate(Date date) {
        this.date = date;
    }

    public Restaurant getRestaurant() {
        return restaurant;
    }

    public void setRestaurant(Restaurant restaurant) {this.restaurant = restaurant;}

    public Profile getProfile() {
        return profile;
    }

    public void setProfile(Profile profile) {this.profile = profile;}

}

