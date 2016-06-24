package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * FindFavoriteRestaurantFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class FindFavoriteRestaurantFondaWebApiControllerException extends FondaBaseException {

    public FindFavoriteRestaurantFondaWebApiControllerException() {
    }

    public FindFavoriteRestaurantFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public FindFavoriteRestaurantFondaWebApiControllerException
                                            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public FindFavoriteRestaurantFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
