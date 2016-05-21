package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by jesus on 21/05/16.
 */
public interface AllRestaurantClient {

    @GET("ListaRestaurant")
    Call<List<Restaurant>> getAllRestaurant();
}
