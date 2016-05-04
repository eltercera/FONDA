package com.ds201625.fonda.domains;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Profile extends BaseEntity {

    private String profileName;

    private GenericPerson person;

    public Profile() {
        super();
    }

    public String getProfileName() {
        return profileName;
    }

    public void setProfileName(String profileName) {
        this.profileName = profileName;
    }

    public GenericPerson getPerson() {
        return person;
    }

    public void setPerson(GenericPerson person) {
        this.person = person;
    }
}
