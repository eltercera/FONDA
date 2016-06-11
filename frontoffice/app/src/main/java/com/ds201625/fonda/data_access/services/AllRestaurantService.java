package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by jesus on 19/05/16.
 */
public interface AllRestaurantService {

    List<Restaurant> getAllRestaurant() throws RestClientException;

}
