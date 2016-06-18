package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
public interface IAllRestaurantsViewPresenter {

    /**
     * Encuentra todos los restaurantes
     * @return
     */
    public List<Restaurant> findAllRestaurants();

    /**
     * Encuentra el comensal logueado
     */
    public void findLoggedComensal();


}
