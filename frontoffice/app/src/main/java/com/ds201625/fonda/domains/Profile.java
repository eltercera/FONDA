package com.ds201625.fonda.domains;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Profile extends BaseEntity {

    private String profileName;

    private Person person;

    public Profile() {
        super();
    }

    public Profile(Integer profileId, String profileName) {this.setId(profileId);this.profileName = profileName;}

    public String getProfileName() {
        return profileName;
    }

    public void setProfileName(String profileName) {
        this.profileName = profileName;
    }

    public Person getPerson() {
        return person;
    }

    public void setPerson(Person person) {
        this.person = person;
    }
}
