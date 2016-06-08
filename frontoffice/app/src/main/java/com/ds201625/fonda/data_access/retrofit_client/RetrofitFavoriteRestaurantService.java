package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.FavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by jesus on 19/05/16.
 */
public class RetrofitFavoriteRestaurantService implements FavoriteRestaurantService {

    private FavoriteRestaurantClient favoriteRestaurantClient =
            RetrofitService.getInstance().createService(FavoriteRestaurantClient.class);

    @Override
    public Commensal AddFavoriteRestaurant(int fk1, int f2k) {
        // aqui se supone que debo traerme el comensal Logeado

        Call<Commensal> call = favoriteRestaurantClient.addfavoriterestaurant(fk1,f2k);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }

        return rsvCommensal;
    }

    @Override
    public Commensal deleteFavoriteRestaurant(int fk1, int fk2) {
        Call<Commensal> call = favoriteRestaurantClient.removefavoriterestaurant(fk1, fk2);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("ERRORWEBSERV", e.toString());
        }

        return rsvCommensal;
    }

    @Override
    public List<Restaurant> getAllFavoriteRestaurant(int fk1) {
        Call<List<Restaurant>> call = favoriteRestaurantClient.getAllFavoriteRestaurant(fk1);
        List<Restaurant> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }


}

