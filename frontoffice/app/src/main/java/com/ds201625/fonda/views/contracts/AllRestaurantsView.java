package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */

/**
 * Interfaz para la vista de RestaurantList.
 */
public interface AllRestaurantsView {
    /**
     * Obtiene lista de todos restaurantes
     * @return restaurantes
     */
    List<Restaurant> getListSW();
}
