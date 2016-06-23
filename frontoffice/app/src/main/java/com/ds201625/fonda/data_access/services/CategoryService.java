package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.RestaurantCategory;

import java.util.List;

/**
 *  Interfaz de CategoryService
 */

public interface CategoryService {

    List<RestaurantCategory> getRestaurantCategory();

}
