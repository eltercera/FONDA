package com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * LogicPaymentWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class LogicPaymentWebApiControllerException extends FondaBaseException {

    public LogicPaymentWebApiControllerException() {
    }

    public LogicPaymentWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public LogicPaymentWebApiControllerException
                                            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public LogicPaymentWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
