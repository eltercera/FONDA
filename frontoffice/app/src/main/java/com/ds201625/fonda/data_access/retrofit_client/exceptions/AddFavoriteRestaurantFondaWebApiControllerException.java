package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Clase AddFavoriteRestaurantFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class AddFavoriteRestaurantFondaWebApiControllerException extends FondaBaseException {

    public AddFavoriteRestaurantFondaWebApiControllerException() {
    }

    public AddFavoriteRestaurantFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public AddFavoriteRestaurantFondaWebApiControllerException
                                             (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public AddFavoriteRestaurantFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
