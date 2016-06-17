package com.ds201625.fonda.domains.entities;

import com.ds201625.fonda.domains.BaseEntity;

import java.util.Date;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Reservation extends BaseEntity {
    private Date reserveDate;
    private Date createDate;
    private int commensalNumber;
    private Restaurant restaurant;
    private Commensal user;

    public Reservation(Date reserveDate, Date createDate, int commensalNumber, Restaurant restaurant, Commensal user) {
        this.reserveDate = reserveDate;
        this.createDate = createDate;
        this.commensalNumber = commensalNumber;
        this.restaurant = restaurant;
        this.user = user;
    }

    public Date getReserveDate() {
        return reserveDate;
    }

    public void setReserveDate(Date reserveDate) {
        this.reserveDate = reserveDate;
    }

    public Date getCreateDate() {
        return createDate;
    }

    public void setCreateDate(Date createDate) {
        this.createDate = createDate;
    }

    public int getCommensalNumber() {
        return commensalNumber;
    }

    public void setCommensalNumber(int commensalNumber) {
        this.commensalNumber = commensalNumber;
    }

    public Restaurant getRestaurant() {
        return restaurant;
    }

    public void setRestaurant(Restaurant restaurant) {
        this.restaurant = restaurant;
    }

    public Commensal getUser() {
        return user;
    }

    public void setUser(Commensal user) {
        this.user = user;
    }
}
