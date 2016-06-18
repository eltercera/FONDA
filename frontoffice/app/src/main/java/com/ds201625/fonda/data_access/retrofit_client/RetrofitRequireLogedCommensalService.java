package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.RequireLogedCommensalClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;

import java.io.IOException;

import retrofit2.Call;


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

    @Override
    public Commensal getLogedCommensal(String email) throws RestClientException{
        Log.d(TAG, "Se obtiene el comensal logeado: "+email);
        Call<Commensal> call = currentLogedCommensal.getAllFavoriteRestaurant(email);
        Commensal test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en la clase getLogedCommensal", e);
        }
        return test;
    }
}
