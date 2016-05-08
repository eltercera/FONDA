package com.ds201625.fonda.domains;

/**
 * Clase Dominio de Perfil.
 * OJO: No es la Definitiva, es usada para las pruebas de interfaces.
 */
public class Profile extends BaseEntity {

    private String profileName;

    private String names;

    private String ssn;

    private String phone;

    private String cellPhone;

    private String address;

    public Profile(String profileName) {
        this.profileName = profileName;
    }

    public Profile(Integer profileId) {this.setId(profileId);}

    public String getProfileName() {
        return profileName;
    }

    public void setProfileName(String profileName) {
        this.profileName = profileName;
    }

    public String getNames() {
        return names;
    }

    public void setNames(String names) {
        this.names = names;
    }

    public String getSsn() {
        return ssn;
    }

    public void setSsn(String ssn) {
        this.ssn = ssn;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getCellPhone() {
        return cellPhone;
    }

    public void setCellPhone(String cellPhone) {
        this.cellPhone = cellPhone;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }
}
