package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
public interface IFavoriteViewPresenter {

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();

    /**
     * Encuentra los restaurantes favoritos
     * @return
     */
    List<Restaurant> findAllFavoriteRestaurant();

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
