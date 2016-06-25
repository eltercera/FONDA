package com.ds201625.fonda.data_access.services;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Zone;

import java.util.List;

/**
 * Interfaz para el servicio del restaurant
 */
public interface RestaurantService {

    List<RestaurantCategory> getCategories(String query, int max, int page);

    List<Zone> getZones(String query, int max, int page);

    List<Restaurant> getRestaurants(String query, int max, int page, int category, int zone);
}