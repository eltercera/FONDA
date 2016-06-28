package com.ds201625.fonda.domains;

/**
 * Created by Hp on 22/05/2016.
 */

/**
 * Class that represents the payment with credit card
 */
public class Email {

    private String email;


    /**
     * Constructors of the class
     */
    public Email(){
        super();
    }

    public Email(String email) {
        this.email = email;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
