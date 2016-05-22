package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Commensal;

/**
 * Created by jesus on 21/05/16.
 */
public interface DeleteFavoriteRestaurantService {

    Commensal deleteFavoriteRestaurant(int fk1, int fk2);

}
