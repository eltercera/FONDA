package com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by Andreina on 24-06-2016.
 */
public class PostReservationFondaWebApiControllerException  extends FondaBaseException {

    public PostReservationFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public PostReservationFondaWebApiControllerException
            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public PostReservationFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
