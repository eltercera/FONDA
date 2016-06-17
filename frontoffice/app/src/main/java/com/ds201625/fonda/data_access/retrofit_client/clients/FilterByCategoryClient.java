package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Interfaz para los metodos del servicio de FilterByZoneClient
 */
public interface FilterByCategoryClient {

    @GET("category/{id}")
    Call<List<Restaurant>> getRestaurantCategoryFilter();


}
