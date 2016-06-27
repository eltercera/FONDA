package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * GetAllRestaurantsFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class GetAllRestaurantsFondaWebApiControllerException extends FondaBaseException {

    public GetAllRestaurantsFondaWebApiControllerException() {
    }

    public GetAllRestaurantsFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public GetAllRestaurantsFondaWebApiControllerException
                                                 (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public GetAllRestaurantsFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
