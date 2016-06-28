package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.HistoryVisitsClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicHistoryVisitsWebApiControllerException;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;
import android.util.Log;

/**
 * Created by Jessica on 21/06/2016.
 */

/**
 * Clase que implementa el servicio
 */
public class RetrofitHistoryVisitsService implements HistoryVisitsRestaurantService {

    /**
     * HistoryVisitsCliente que crea el servicio
     */
    private HistoryVisitsClient historyVisitsClient =
            RetrofitService.getInstance().createService(HistoryVisitsClient.class);
    private String TAG = "RetrofitHistoryVisitsService";
    private APIError error;

    /**
     * Constructor de RetrofitHistoryVisitsService
     */
    public RetrofitHistoryVisitsService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     *
     * @return llamada
     */
    @Override
    public List<Invoice> getHistoryVisits(int idProfile) throws LogicHistoryVisitsWebApiControllerException {
        Log.d(TAG, "Se obtiene historial de pago del perfil "+idProfile);
        Call<List<Invoice>> call = historyVisitsClient.getHistoryVisits(idProfile);
        List<Invoice> test = null;
        Response<List<Invoice>> response;
        try {
            response = call.execute();
            if (response.isSuccessful()) {
                test = response.body();
            } else {
                error = ErrorUtils.parseError(response);
                Log.d(TAG, "Se obtiene la excepcion del WS");
                // usar error para disparar exception
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());

                throw new LogicHistoryVisitsWebApiControllerException
                        (error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant1", e);
            throw new LogicHistoryVisitsWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant2", e);
            throw new LogicHistoryVisitsWebApiControllerException(error.exceptionType());
        }
        return test;
    }
}
