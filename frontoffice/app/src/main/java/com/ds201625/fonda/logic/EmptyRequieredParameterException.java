package com.ds201625.fonda.logic;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class EmptyRequieredParameterException extends Exception {

    public static EmptyRequieredParameterException generate(String command, int index) {
        String detailMessage = "Parametro " + index + " requerido en commando " + command;
        return new EmptyRequieredParameterException(detailMessage);
    }

    private EmptyRequieredParameterException(String detailMessage) {
        super(detailMessage);
    }
}
