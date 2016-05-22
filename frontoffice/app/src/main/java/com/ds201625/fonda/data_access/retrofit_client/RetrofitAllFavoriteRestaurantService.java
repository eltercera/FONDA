package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.AllFavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by jesus on 21/05/16.
 */
public class RetrofitAllFavoriteRestaurantService implements AllFavoriteRestaurantService {

    private AllFavoriteRestaurantClient currentAllFavoriteRestaurantClient =
            RetrofitService.getInstance().createService(AllFavoriteRestaurantClient.class);

    public RetrofitAllFavoriteRestaurantService() {
        super();
    }

    @Override
    public List<Restaurant> getAllFavoriteRestaurant(int fk1) {

        Call<List<Restaurant>> call = currentAllFavoriteRestaurantClient.getAllFavoriteRestaurant(fk1);
        List<Restaurant> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }
}