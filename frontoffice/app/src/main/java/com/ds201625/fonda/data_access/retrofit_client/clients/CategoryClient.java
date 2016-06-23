package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.RestaurantCategory;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Interfaz para los metodos del servicio de CategoryClient
 */
public interface CategoryClient {

    @GET("categoryFilter")
    Call<List<RestaurantCategory>> getCategoryFilter();


}
