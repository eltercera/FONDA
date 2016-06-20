package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
public interface AllRestaurantsView {
    /**
     * Obtiene lista de todos restaurantes
     * @return restaurantes
     */
    List<Restaurant> getListSW();
}
