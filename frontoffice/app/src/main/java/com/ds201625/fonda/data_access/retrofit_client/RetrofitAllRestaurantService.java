package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.AllRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Implementacion de la interfaz AllRestaurantService
 */
public class RetrofitAllRestaurantService implements AllRestaurantService {

    private AllRestaurantClient currentAllRestaurantClient =
            RetrofitService.getInstance().createService(AllRestaurantClient.class);

    public RetrofitAllRestaurantService() {
        super();
    }

    @Override
    public List<Restaurant> getAllRestaurant() throws RestClientException {

        Call<List<Restaurant>> call = currentAllRestaurantClient.getAllRestaurant();
        List<Restaurant> test = null;
        try{
            test =call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }
        return test;

    }
}
