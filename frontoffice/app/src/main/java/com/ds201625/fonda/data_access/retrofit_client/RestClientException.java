package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class RestClientException extends FondaBaseException {

    public RestClientException() {
    }

    public RestClientException(String detailMessage) {
        super(detailMessage);
    }

    public RestClientException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public RestClientException(Throwable throwable) {
        super(throwable);
    }
}
