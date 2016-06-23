package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by Hp on 22/06/2016.
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
