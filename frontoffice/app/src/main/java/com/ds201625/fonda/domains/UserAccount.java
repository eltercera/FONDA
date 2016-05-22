package com.ds201625.fonda.domains;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class UserAccount extends BaseEntity {

    private String email;

    private String password;

    public UserAccount() {
        super();
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}