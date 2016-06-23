package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by Hp on 22/06/2016.
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
