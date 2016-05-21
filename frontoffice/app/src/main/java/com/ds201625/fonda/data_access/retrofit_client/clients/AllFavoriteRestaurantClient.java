package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by jesus on 21/05/16.
 */
public interface AllFavoriteRestaurantClient {

    @GET("findRestaurantFavorites/{id}")
    Call<List<Restaurant>> getAllFavoriteRestaurant(@Path("id") int fk1);

}
