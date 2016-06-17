package com.ds201625.fonda.domains.entities;

/**
 * Created by Katherina Molina on 10/05/2016.
 */

/*
 Clase quee representa la moneda de la factura
 */
public class Currency extends NounBaseEntity {

    /**
     * String que define el simbolo de la moneda
     */
    private String symbol;

    /**
     Contructor de la clase moneda
     */
    public Currency() {
        super();
    }

    public Currency(String symbol) {
        this.symbol = symbol;
    }

    /**
     * Metodo que obtiene el simbolo de la moneda
     * @return symbol
     */
    public String getSymbol() {
        return symbol;
    }

    /**
     * Metodo que asigna en simbolo de la moneda
     * @param symbol
     */
    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }
}
