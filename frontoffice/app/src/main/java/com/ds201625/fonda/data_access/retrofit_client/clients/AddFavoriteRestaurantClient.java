package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by jesus on 21/05/16.
 */
public interface AddFavoriteRestaurantClient {

    @GET("addfavorite/{idcommensal}/{idrestaurant}")
    Call<Commensal> addfavoriterestaurant(@Path("idcommensal") int fk1 ,@Path("idrestaurant") int fk2);

}
