package com.ds201625.fonda.domains;

import java.util.Date;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Reservation extends BaseEntity {
    private  int number_r;
    private Date reserveDate;
    private Date createDate;
    private int commensalNumber;
    private boolean status;


    public Reservation(int number_r,Date reserveDate, Date createDate, int commensalNumber, boolean status) {
        this.number_r = number_r;
        this.reserveDate = reserveDate;
        this.createDate = createDate;
        this.commensalNumber = commensalNumber;
        this.status = status;

    }

    public int getNumber_r() { return  number_r;}

    public void setNumber_r(int number_r){ this.number_r = number_r;}

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

    public void setStatus(boolean status) {this.status= status; }

    public boolean getStatus(){ return status;}
}
