package com.ds201625.fonda.domains;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class FondaBaseException extends Exception {

    public FondaBaseException() {
    }

    public FondaBaseException(String detailMessage) {
        super(detailMessage);
    }

    public FondaBaseException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public FondaBaseException(Throwable throwable) {
        super(throwable);
    }
}
