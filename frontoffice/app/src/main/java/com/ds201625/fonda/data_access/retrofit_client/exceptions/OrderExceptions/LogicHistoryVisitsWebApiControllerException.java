package com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * LogicHistoryVisitsWebApiControllerException
 * clase de excepcion de tipo web api controller
 */
public class LogicHistoryVisitsWebApiControllerException extends FondaBaseException {

    public LogicHistoryVisitsWebApiControllerException() {
    }

    public LogicHistoryVisitsWebApiControllerException(String detailMessage) {
        super(detailMessage);
    }

    public LogicHistoryVisitsWebApiControllerException
                                            (String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public LogicHistoryVisitsWebApiControllerException(Throwable throwable) {
        super(throwable);
    }

}
