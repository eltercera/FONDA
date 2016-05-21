package com.ds201625.fonda.data_access.local_storage;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class LocalStorageException extends FondaBaseException {

    public LocalStorageException() {
    }

    public LocalStorageException(String detailMessage) {
        super(detailMessage);
    }

    public LocalStorageException(String detailMessage, Throwable throwable) {
        super(detailMessage, throwable);
    }

    public LocalStorageException(Throwable throwable) {
        super(throwable);
    }
}
