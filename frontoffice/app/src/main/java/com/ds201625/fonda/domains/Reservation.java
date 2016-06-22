package com.ds201625.fonda.domains;

import java.util.Date;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Reservation extends BaseEntity {

    private Date reserveDate;
    private Date createDate;
    private int commensalNumber;
    private boolean status;


    public Reservation(Date reserveDate, Date createDate, int commensalNumber, boolean status) {
        this.reserveDate = reserveDate;
        this.createDate = createDate;
        this.commensalNumber = commensalNumber;
        this.status = status;

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

    public void setStatus(boolean status) {this.status= status; }

    public boolean getStatus(){ return status;}
}
