package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.Zone;

import java.util.List;

/**
 *  Interfaz de FilterByZoneService
 */

public interface FilterByZoneService {

    List<Restaurant> getRestaurant(Zone zone);

}
