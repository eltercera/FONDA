package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.data_access.retrofit_client.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
/**
 * Interfaz para el presentador de Favorite.
 */
public interface FavoriteViewPresenter {

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();

    /**
     * Encuentra los restaurantes favoritos
     * @return
     */
    List<Restaurant> findAllFavoriteRestaurant() throws FindFavoriteRestaurantFondaWebApiControllerException, FindFavoriteRestaurantFondaWebApiControllerException;

    /**
     * Elimina el restaurante seleccionado
     * @param restaurant
     */
    void deleteFavoriteRestaurant(Restaurant restaurant);

    /**
     * Agrega un restaurante a favoritos
     * @param restaurant
     */
    void addFavoriteRestaurant(Restaurant restaurant);
}
