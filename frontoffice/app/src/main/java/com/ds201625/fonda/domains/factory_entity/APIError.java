package com.ds201625.fonda.domains.factory_entity;

/**
 * Created by Adri on 6/20/2016.
 */

/**
 * Dominio de la clase APIError
 */
public class APIError {

    private String exceptionMessage;
    private String message;
    private String exceptionType;
    private String stackTrace;

    /**
     * Constructor ApiError
     */
    public APIError() {
    }

    /**
     * Get del mensaje de la excepcion
     * @return message
     */
    public String message() {
        return message;
    }

    /**
     * get del exceptionMessage
     * @return exceptionMessage
     */
    public String exceptionMessage() {
        return exceptionMessage;
    }

    /**
     * get del tipo de exception
     * @return exceptionType
     */
    public String exceptionType() {
        return exceptionType;
    }

    /**
     * get del stackTrace de la exception
     * @return stackTrace
     */
    public String stackTrace() {
        return  stackTrace;
    }
}