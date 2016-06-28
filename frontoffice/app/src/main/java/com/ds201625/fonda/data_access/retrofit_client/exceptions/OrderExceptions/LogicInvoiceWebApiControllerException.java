package com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * LogicInvoiceWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class LogicInvoiceWebApiControllerException extends FondaBaseException {

    public LogicInvoiceWebApiControllerException() {
    }

    public LogicInvoiceWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public LogicInvoiceWebApiControllerException
                                            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public LogicInvoiceWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
