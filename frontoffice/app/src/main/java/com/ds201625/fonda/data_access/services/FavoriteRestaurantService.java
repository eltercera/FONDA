package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by jesus on 21/05/16.
 */
public interface FavoriteRestaurantService {

    Commensal AddFavoriteRestaurant(int fk1, int f2k);
    Commensal deleteFavoriteRestaurant(int fk1, int fk2);
    List<Restaurant> getAllFavoriteRestaurant(int fk1);

}
