package com.ds201625.fonda.domains;

/**
 * Created by gbsoj on 6/25/2016.
 */
public class Coordinate extends BaseEntity {

    private Double longitude;
    private Double latitude;

    public Double getLongitude() {
        return longitude;
    }

    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }

    public Double getLatitude() {
        return latitude;
    }

    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }
}
