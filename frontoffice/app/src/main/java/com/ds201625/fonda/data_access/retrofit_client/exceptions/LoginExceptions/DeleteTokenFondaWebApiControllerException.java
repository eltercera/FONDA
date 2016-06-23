package com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by jessi_ds930h9 on 23/6/2016.
 */
public class DeleteTokenFondaWebApiControllerException extends FondaBaseException {
    public DeleteTokenFondaWebApiControllerException() {
    }

    public DeleteTokenFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public DeleteTokenFondaWebApiControllerException
            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public DeleteTokenFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }
}
