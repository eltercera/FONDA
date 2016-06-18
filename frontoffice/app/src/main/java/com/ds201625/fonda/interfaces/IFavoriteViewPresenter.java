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
    public void findLoggedComensal();

    /**
     * Encuentra el id del comensal logueado
     */
    public int findLoggedComensalById();

    /**
     * Encuentra los restaurantes favoritos
     * @return
     */
    public List<Restaurant> findAllFavoriteRestaurant();

    /**
     * Elimina el restaurante seleccionado
     * @param restaurant
     */
    public void deleteFavoriteRestaurant(Restaurant restaurant);

    /**
     * Agrega un restaurante a favoritos
     * @param restaurant
     */
    public void addFavoriteRestaurant(Restaurant restaurant);
}
