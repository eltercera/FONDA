package com.ds201625.fonda.logic;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class InvalidParameterTypeException extends Exception{

    public static InvalidParameterTypeException generate(String spec, String pasa) {
        String detailMessage = "Esperado " + spec + " pero se encontro  " + pasa;
        return new InvalidParameterTypeException(detailMessage);
    }

    private InvalidParameterTypeException(String detailMessage) {
        super(detailMessage);
    }
}
