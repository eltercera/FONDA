package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class InvalidDataRetrofitException extends FondaBaseException {

    public InvalidDataRetrofitException() {
    }

    public InvalidDataRetrofitException(String detailMessage) {
        super(detailMessage);
    }

    public InvalidDataRetrofitException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public InvalidDataRetrofitException(Throwable throwable) {
        super(throwable);
    }
}
