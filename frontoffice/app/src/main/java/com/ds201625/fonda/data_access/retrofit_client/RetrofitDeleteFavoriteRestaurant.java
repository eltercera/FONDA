package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.RemoveFavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.DeleteFavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by jesus on 21/05/16.
 */
public class RetrofitDeleteFavoriteRestaurant implements DeleteFavoriteRestaurantService {
    private RemoveFavoriteRestaurantClient removeFavoriteRestaurant =
            RetrofitService.getInstance().createService(RemoveFavoriteRestaurantClient.class);


    @Override
    public Commensal deleteFavoriteRestaurant(int fk1, int f2k) {

        Call<Commensal> call = removeFavoriteRestaurant.removefavoriterestaurant(fk1, f2k);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("ERRORWEBSERV", e.toString());
        }

        return rsvCommensal;


    }

}


/*
*
*
    @Override
    public Commensal deleteFavoriteRestaurant(int fk1, int f2k) {

        Call<Commensal> call = deleteFavoriteRestaurant.deleteFavoriteRestaurant(fk1,f2k);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("ERRORWEBSERV", e.toString());
        }

        return rsvCommensal;


    }*/