package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;


/**
 * Interfaz para el servicio de Restaurantes
 */
public interface AllRestaurantService {

    /**
     * Método que obtiene todos los restaurantes
     * @return
     * @throws RestClientException
     */
    List<Restaurant> getAllRestaurant() throws RestClientException, GetAllRestaurantsFondaWebApiControllerException;

}

