package com.ds201625.fonda.domains.entities;

import com.ds201625.fonda.domains.BaseEntity;

import java.util.Date;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class Token extends BaseEntity {

    private String strToken;

    private Date created;

    private Date expiration;

    public Token() {
        super();
    }

    public String getStrToken() {
        return strToken;
    }

    public void setStrToken(String strToken) {
        this.strToken = strToken;
    }

    public Date getCreated() {
        return created;
    }

    public void setCreated(Date created) {
        this.created = created;
    }

    public Date getExpiration() {
        return expiration;
    }

    public void setExpiration(Date expiration) {
        this.expiration = expiration;
    }
}
