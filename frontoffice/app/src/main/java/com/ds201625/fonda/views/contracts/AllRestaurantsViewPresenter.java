package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindByEmailUserAccountFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */

/**
 * Interfaz para el presentador de AllRestaurants.
 */
public interface AllRestaurantsViewPresenter {

    /**
     * Encuentra todos los restaurantes
     * @return
     */
    List<Restaurant> findAllRestaurants() throws GetAllRestaurantsFondaWebApiControllerException;

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal() throws FindByEmailUserAccountFondaWebApiControllerException;


}

