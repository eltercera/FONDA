package com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by jessi_ds930h9 on 23/6/2016.
 */
public class GetTokenFondaWebApiControllerException extends FondaBaseException {
    public GetTokenFondaWebApiControllerException() {
    }

    public GetTokenFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public GetTokenFondaWebApiControllerException
            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public GetTokenFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
