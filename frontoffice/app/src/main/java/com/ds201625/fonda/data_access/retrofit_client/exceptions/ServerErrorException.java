package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class ServerErrorException extends FondaBaseException {

    public ServerErrorException() {
    }

    public ServerErrorException(String detailMessage) {
        super(detailMessage);
    }

    public ServerErrorException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public ServerErrorException(Throwable throwable) {
        super(throwable);
    }

}
