package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.RequireLogedCommensalClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindByEmailUserAccountFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;
import java.io.IOException;
import retrofit2.Call;
import retrofit2.Response;


/**
 * Implementacion de la interfaz RequireLogedCommensalService
 */
public class RetrofitRequireLogedCommensalService implements RequireLogedCommensalService {
    private String TAG = "RetrofitRequireLogedCommensalService";
    private RequireLogedCommensalClient currentLogedCommensal = RetrofitService.getInstance().
            createService(RequireLogedCommensalClient.class);

    public RetrofitRequireLogedCommensalService() {
        super();
    }

    /**
     * Obtiene el comensal logueado
     *
     * @param email
     * @return
     * @throws RestClientException
     */
    @Override
    public Commensal getLogedCommensal(String email) throws RestClientException {
        Log.d(TAG, "Se obtiene el comensal logeado: "+email);
        Call<Commensal> call = currentLogedCommensal.getAllFavoriteRestaurant(email);
        Commensal test = null;
        Response<Commensal> response;
        try {
            response = call.execute();
            if (response.isSuccessful()) {
                test = response.body();
            }else {
                // parse the response body
                APIError error = ErrorUtils.parseError(response);
                // arreglar log
                Log.d("Error message", error.message());
                Log.d("Error ExceptionType", error.exceptionType());
                // usar error para disparar exception
                throw  new FindByEmailUserAccountFondaWebApiControllerException(error.exceptionMessage());

            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en la clase getLogedCommensal", e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getLogedCommensal", e);
        }
        return test;
    }

}