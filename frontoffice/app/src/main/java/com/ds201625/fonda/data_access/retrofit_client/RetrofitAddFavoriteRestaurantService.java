package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.AddFavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.AddFavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by jesus on 19/05/16.
 */
public class RetrofitAddFavoriteRestaurantService implements AddFavoriteRestaurantService {

    private AddFavoriteRestaurantClient addFavoriteRestaurantClient =
            RetrofitService.getInstance().createService(AddFavoriteRestaurantClient.class);


    @Override
    public Commensal AddFavoriteRestaurant(int fk1, int f2k) {
        // aqui se supone que debo traerme el comensal Logeado

        Call<Commensal> call = addFavoriteRestaurantClient.addfavoriterestaurant(fk1,f2k);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }

        return rsvCommensal;
    }


}

