package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.entities.Restaurant;
import com.ds201625.fonda.domains.entities.Zone;

import java.util.List;

/**
 *  Interfaz de FilterByZoneService
 */

public interface FilterByZoneService {

    List<Restaurant> getRestaurant(Zone zone);

}
