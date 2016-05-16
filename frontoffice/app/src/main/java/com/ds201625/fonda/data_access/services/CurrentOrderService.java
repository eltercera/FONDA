package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

/**
 * Created by rrodriguez on 5/7/16.
 */
public interface CurrentOrderService {

    List<DishOrder> getListDishOrder();

}
