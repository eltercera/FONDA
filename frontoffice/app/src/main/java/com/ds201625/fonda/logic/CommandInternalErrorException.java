package com.ds201625.fonda.logic;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class CommandInternalErrorException extends Exception {

    public static CommandInternalErrorException generate(String command,Throwable throwable) {
        String detailMessage = "Error interno al ejecutar commando " + command;
        return  new CommandInternalErrorException(detailMessage,throwable);
    }

    private CommandInternalErrorException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }
}
