package com.ds201625.fonda.logic.ExceptionHandler;

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

/**
 * clase ErrorUtils que convierte la respuesta arrojada por el servidor.
 *Retorna la conversion del error
 */
public class ErrorUtils {
    public static APIError parseError(Response<?> response) {
        Converter<ResponseBody, APIError> converter =
                RetrofitService.getInstance().retrofit()
                        .responseBodyConverter(APIError.class, new Annotation[0]);
        APIError error = null;

        try {
            error = converter.convert(response.errorBody());
        } catch (IOException e) {
             System.out.print("Se ha generado error en la Clase ErrorUtils");
                e.printStackTrace();
        }
        catch (Exception e) {
            System.out.print("Se ha generado error en la Clase ErrorUtils");
            e.printStackTrace();
        }
        return error;
    }
}