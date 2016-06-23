package com.ds201625.fonda.logic.ExceptionHandler;
;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.domains.factory_entity.APIError;

import java.io.IOException;
import java.lang.annotation.Annotation;

import okhttp3.ResponseBody;
import retrofit2.Converter;
import retrofit2.Response;


/**
 * Created by Adri on 6/20/2016.
 */
public class ErrorUtils {
    /*public static APIError parseError(Response<?> response) {
        Converter<ResponseBody, APIError> converter =
                RetrofitService.getInstance().retrofit()
                        .responseBodyConverter(APIError.class, new Annotation[0]);
        APIError error;

        try {
            error = converter.convert(response.errorBody());
        } catch (IOException e) {
            return new APIError();
        }

        return error;
    }*/
}
