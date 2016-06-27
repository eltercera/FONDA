package com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions;

import com.ds201625.fonda.domains.FondaBaseException;

/**
 * Created by rrodriguez on 6/24/16.
 */
public class UnknownServerErrorException extends FondaBaseException{

    public static UnknownServerErrorException generate(int code, String message) {
        String detailMessage = "ERROR DESCONOCIDO DEL SERRVIDOR\n" +
                "HTTP_CODE: " + code + "\n" +
                "MESSAGE: " + message;
        return new UnknownServerErrorException(detailMessage);
    }

    private  UnknownServerErrorException(String detailMessage) {
        super(detailMessage);
    }

}
