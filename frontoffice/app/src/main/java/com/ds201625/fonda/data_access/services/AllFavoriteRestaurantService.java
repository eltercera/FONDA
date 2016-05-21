package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by jesus on 21/05/16.
 */
public interface AllFavoriteRestaurantService {
    List<Restaurant> getAllFavoriteRestaurant(int fk1);

}
