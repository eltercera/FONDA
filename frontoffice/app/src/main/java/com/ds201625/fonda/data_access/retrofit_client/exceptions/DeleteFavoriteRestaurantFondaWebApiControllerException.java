package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * DeleteFavoriteRestaurantFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class DeleteFavoriteRestaurantFondaWebApiControllerException extends FondaBaseException {

    public DeleteFavoriteRestaurantFondaWebApiControllerException() {
    }

    public DeleteFavoriteRestaurantFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public DeleteFavoriteRestaurantFondaWebApiControllerException
                                                    (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public DeleteFavoriteRestaurantFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
