package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.AddFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.DeleteFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;


/**
 * Interfaz para el servicio de Favoritos
 */
public interface FavoriteRestaurantService {
    /**
     * Agrega un restaurante a favoritos
     * @param idCommensal
     * @param idRestaurant
     * @return
     * @throws RestClientException
     */
    Commensal AddFavoriteRestaurant(int idCommensal, int idRestaurant)
            throws RestClientException, AddFavoriteRestaurantFondaWebApiControllerException;;

    /**
     * Elimina un restaurante de favoritos
     * @param idCommensal
     * @param idRestaurant
     * @return
     * @throws RestClientException
     */
    Commensal deleteFavoriteRestaurant(int idCommensal, int idRestaurant)
            throws RestClientException, DeleteFavoriteRestaurantFondaWebApiControllerException;;

    /**
     * Obtiene todos los restaurantes favoritos
     * @param idCommensal
     * @return
     * @throws RestClientException
     */
    List<Restaurant> getAllFavoriteRestaurant(int idCommensal) throws Exception;;

}

