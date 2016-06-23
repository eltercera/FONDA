package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Interfaz para ser implementada por retrofit
 * Define los recursos de /api/restaurantes(s) del
 * servicio web REST
 */
public interface AllRestaurantClient {

    /**
     * Get /api/ListaRestaurant
     * Obtiene la lista de los restaurantes.
     * @return
     */
    @GET("ListaRestaurant")
    Call<List<Restaurant>> getAllRestaurant();
}
