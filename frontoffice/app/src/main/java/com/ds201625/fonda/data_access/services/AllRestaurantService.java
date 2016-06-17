package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.entities.Restaurant;

import java.util.List;


/**
 * Interfaz para el servicio de Restaurantes
 */
public interface AllRestaurantService {

    List<Restaurant> getAllRestaurant() throws RestClientException;

}
