package com.ds201625.fonda.domains;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class GenericPerson extends NounBaseEntity {

    private String address;

    private String phoneNumber;

    private String ssn;

    public GenericPerson() {
        super();
    }

    public String getSsn() {
        return ssn;
    }

    public void setSsn(String ssn) {
        this.ssn = ssn;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }
}
