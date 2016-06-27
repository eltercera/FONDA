package com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by Andreina on 24-06-2016.
 */
public class GetReservationFondaWebApiControllerException extends FondaBaseException {

    public GetReservationFondaWebApiControllerException() {
    }

    public GetReservationFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public GetReservationFondaWebApiControllerException
            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public GetReservationFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
