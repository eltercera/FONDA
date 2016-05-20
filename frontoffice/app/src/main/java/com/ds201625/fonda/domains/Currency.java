package com.ds201625.fonda.domains;

/**
 * Created by Katherina Molina on 10/05/2016.
 */
public class Currency extends NounBaseEntity{

    private String symbol;

    public Currency() {
        super();
    }

    public Currency(String symbol) {
        this.symbol = symbol;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }
}
