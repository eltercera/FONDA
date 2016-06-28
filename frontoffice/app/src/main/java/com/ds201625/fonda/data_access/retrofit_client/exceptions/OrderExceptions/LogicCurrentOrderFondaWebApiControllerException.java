package com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * LogicCurrentOrderFondaWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class LogicCurrentOrderFondaWebApiControllerException extends FondaBaseException {

    public LogicCurrentOrderFondaWebApiControllerException() {
    }

    public LogicCurrentOrderFondaWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public LogicCurrentOrderFondaWebApiControllerException
                                            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public LogicCurrentOrderFondaWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
