package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by jesus on 21/05/16.
 */
public interface FavoriteRestaurantClient {

    @GET("addfavorite/{idcommensal}/{idrestaurant}")
    Call<Commensal> addfavoriterestaurant(@Path("idcommensal") int fk1 ,@Path("idrestaurant") int fk2);

    @GET("findRestaurantFavorites/{id}")
    Call<List<Restaurant>> getAllFavoriteRestaurant(@Path("id") int fk1);

    @GET("deletefavorite/{idcommensal}/{idrestaurant}")
    Call<Commensal> removefavoriterestaurant(@Path("idcommensal") int fk1, @Path("idrestaurant") int fk2);
}
