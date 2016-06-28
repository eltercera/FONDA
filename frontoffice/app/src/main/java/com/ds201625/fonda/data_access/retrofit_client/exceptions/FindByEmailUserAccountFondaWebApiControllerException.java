package com.ds201625.fonda.data_access.retrofit_client.exceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * FindByEmailUserAccountFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class FindByEmailUserAccountFondaWebApiControllerException extends FondaBaseException {

    public FindByEmailUserAccountFondaWebApiControllerException() {
    }

    public FindByEmailUserAccountFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public FindByEmailUserAccountFondaWebApiControllerException
                                                (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public FindByEmailUserAccountFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
