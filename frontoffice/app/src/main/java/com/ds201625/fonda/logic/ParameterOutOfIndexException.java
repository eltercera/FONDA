package com.ds201625.fonda.logic;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class ParameterOutOfIndexException extends Exception{

    public static ParameterOutOfIndexException generate(String command, int index) {
        String detailMessage = "Parametro " + index + " fuera de indice en comando " + command;
        return new ParameterOutOfIndexException(detailMessage);
    }

    private ParameterOutOfIndexException(String detailMessage) {
        super(detailMessage);
    }
}
