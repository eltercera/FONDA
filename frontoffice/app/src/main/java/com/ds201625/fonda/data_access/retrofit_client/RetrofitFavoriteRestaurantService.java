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
 * Implementacion de la interfaz FavoriteRestaurantService
 */
public class RetrofitFavoriteRestaurantService implements FavoriteRestaurantService {

    private FavoriteRestaurantClient favoriteRestaurantClient =
            RetrofitService.getInstance().createService(FavoriteRestaurantClient.class);

    @Override
    public Commensal AddFavoriteRestaurant(int idCommensal, int idRestaurant)  throws RestClientException {
        // aqui se supone que debo traerme el comensal Logeado

        Call<Commensal> call = favoriteRestaurantClient.addfavoriterestaurant(idCommensal,idRestaurant);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }

        return rsvCommensal;
    }

    @Override
    public Commensal deleteFavoriteRestaurant(int idCommensal, int idRestaurant)  throws RestClientException{
        Call<Commensal> call = favoriteRestaurantClient.removefavoriterestaurant(idCommensal, idRestaurant);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("ERRORWEBSERV", e.toString());
        }

        return rsvCommensal;
    }

    @Override
    public List<Restaurant> getAllFavoriteRestaurant(int idCommensal)  throws RestClientException{
        Call<List<Restaurant>> call = favoriteRestaurantClient.getAllFavoriteRestaurant(idCommensal);
        List<Restaurant> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }


}

