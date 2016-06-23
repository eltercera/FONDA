package com.ds201625.fonda.domains;

/**
 * Created by Adri on 06/05/2016.
 */
public class Table {

    private Integer number;
    private Integer capacity;

    public Table () {
        super();
    }

    public Table(Integer number, Integer capacity) {
        this.number = number;
        this.capacity = capacity;
    }


    public Integer getNumber() {
        return number;
    }

    public void setNumber(Integer number) {this.number = number;}

    public Integer getCapacity() {return capacity;}

    public void setCapacity(Integer capacity) {
        this.capacity = capacity;
    }
}
