package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

/**
 * Created by Yuneth on 5/15/2016.
 */

/**
 * Interface de CurrentOrderService
 */
public interface CurrentOrderService {

    List<DishOrder> getListDishOrder() throws RestClientException;

}
