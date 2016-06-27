package com.ds201625.fonda.data_access.services;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.UnknownServerErrorException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.ServerErrorException;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Zone;

import java.util.List;

/**
 * Interfaz para el servicio del restaurant
 */
public interface RestaurantService {

    /**
     * Ontiene una lista de categorias de restaurantes
     * @param query string de busqueda
     * @param max maxima cantidad de items
     * @param page numero de paginador
     * @return lista de  categorias de restaurantes
     * @throws RestClientException
     * @throws ServerErrorException
     * @throws UnknownServerErrorException
     */
    List<RestaurantCategory> getCategories(String query, int max, int page)
            throws RestClientException, ServerErrorException, UnknownServerErrorException;

    /**
     * Obtiene la lista de zonas de restaurantes
     * @param query string de busqueda
     * @param max maxima cantidad de items
     * @param page numero de paginador
     * @return lista de zonas de restaurantes
     * @throws RestClientException
     * @throws ServerErrorException
     * @throws UnknownServerErrorException
     */
    List<Zone> getZones(String query, int max, int page)
            throws RestClientException, ServerErrorException, UnknownServerErrorException;

    /**
     * Obtiene lista de restaurantes
     * @param query string de busqueda
     * @param max maxima cantidad de items
     * @param page numero de paginador
     * @param category identificador de categoria
     * @param zone identificador de zona
     * @return lista de restaurantes
     * @throws RestClientException
     * @throws ServerErrorException
     * @throws UnknownServerErrorException
     */
    List<Restaurant> getRestaurants(String query, int max, int page, int category, int zone)
            throws RestClientException, ServerErrorException, UnknownServerErrorException;

    void setRestaurantFab(boolean fab, int id)
            throws RestClientException, ServerErrorException, UnknownServerErrorException;
}