package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.CurrentOrderClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicCurrentOrderFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;

/**
 * Created by Jessica on 20/06/2016.
 */

/**
 * Clase que implementa el servicio
 */
public class RetrofitCurrentOrderService implements CurrentOrderService {

    /**
     * CurrentOrderClient que crea el servicio
     */
    private CurrentOrderClient currentOrderClient =
            RetrofitService.getInstance().createService(CurrentOrderClient.class);
    private String TAG = "RetrofitHistoryVisitsService";
    private APIError error;

    /**
     * Constructor de RetrofitCurrentOrderService
     */
    public RetrofitCurrentOrderService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<DishOrder> getListDishOrder(int idRestaurante, int idOrden) throws LogicCurrentOrderFondaWebApiControllerException {
        Call<List<DishOrder>> call = currentOrderClient.getListDishOrder(idRestaurante, idOrden);
        List<DishOrder> test = null;
        Response<List<DishOrder>> response;
        try {
            response = call.execute();
            if (response.isSuccessful()) {
                test = response.body();
            } else {
                error = ErrorUtils.parseError(response);
                Log.d(TAG, "Se obtiene la excepcion del WS");
                // usar error para disparar exception
                Log.e(TAG, "error message " + error.message());
                Log.e(TAG, "error message " + error.exceptionType());

                throw new LogicCurrentOrderFondaWebApiControllerException
                        (error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant1", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant2", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(error.exceptionType());
        }
        return test;
    }
}
