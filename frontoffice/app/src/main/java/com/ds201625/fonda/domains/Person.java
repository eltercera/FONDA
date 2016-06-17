package com.ds201625.fonda.domains;

import java.util.Date;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class Person extends GenericPerson {

    private String lastName;

    private String gender;

    private Date birthDate;

    public Person() {
        super();
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public Date getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(Date birthDate) {
        this.birthDate = birthDate;
    }
}
