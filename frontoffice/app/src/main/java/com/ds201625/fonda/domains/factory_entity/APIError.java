package com.ds201625.fonda.domains.factory_entity;

/**
 * Created by Adri on 6/20/2016.
 */
public class APIError {

    private String exceptionMessage;
    private String message;
    private String exceptionType;
    private String stackTrace;

    public APIError() {
    }

    public String message() {
        return message;
    }
    public String exceptionMessage() {
        return exceptionMessage();
    }

    public String exceptionType() {
        return exceptionMessage();
    }
    public String stackTrace() {
        return  stackTrace();
    }
}
