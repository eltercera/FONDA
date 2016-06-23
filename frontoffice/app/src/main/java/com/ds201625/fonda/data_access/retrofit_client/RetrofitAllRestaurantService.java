package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.AllRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;

/**
 * Implementacion de la interfaz AllRestaurantService
 */
public class RetrofitAllRestaurantService implements AllRestaurantService {
    private String TAG = "RetrofitAllRestaurantService";
    private AllRestaurantClient currentAllRestaurantClient =
            RetrofitService.getInstance().createService(AllRestaurantClient.class);

    public RetrofitAllRestaurantService() {
        super();
    }

    private APIError error;
    /**
     * Método que obtiene todos los restaurantes
     *
     * @return
     * @throws RestClientException
     */
    @Override
    public List<Restaurant> getAllRestaurant() throws GetAllRestaurantsFondaWebApiControllerException {
        Log.d(TAG, "Se obtienen todos los restaurantes");
        Call<List<Restaurant>> call = currentAllRestaurantClient.getAllRestaurant();
        List<Restaurant> test = null;
        Response<List<Restaurant>> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                // use response data and do some fancy stuff :)
                test = response.body();
            } else {
                // parse the response body
               error = ErrorUtils.parseError(response);
                // usar error para disparar exception

                Log.d("Error message", error.message());
                Log.d("Error ExceptionType", error.exceptionType());
                throw  new GetAllRestaurantsFondaWebApiControllerException(error.exceptionType());

            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllRestaurant", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getAllRestaurant", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(error.exceptionType());
        }
        return test;
    }

}
