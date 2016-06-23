package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by Hp on 22/06/2016.
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
