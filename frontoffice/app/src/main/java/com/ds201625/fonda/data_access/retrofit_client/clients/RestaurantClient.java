package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Zone;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

/**
 * Interfaz para los metodos del servicio de FilterByZoneClient
 */
public interface RestaurantClient {

    @GET("restaurantscategories")
    Call<List<RestaurantCategory>> getCategories(@Query("q") String q, @Query("max") int max, @Query("page") int page);

    @GET("zones")
    Call<List<Zone>> getZones(@Query("q") String q, @Query("max") int max, @Query("page") int page);

    @GET("restaurants")
    Call<List<Restaurant>> getRestaurants(@Query("q") String q, @Query("max") int max, @Query("page") int page, @Query("zone") int zone, @Query("category") int category);

    @POST("commensal/restaurants/{id}")
    Call<Void> postCommensalRestaurants(@Path("id") int id);

    @DELETE("commensal/restaurants/{id}")
    Call<Void> deleteCommensalRestaurants(@Path("id") int id);

}