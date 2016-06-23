package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de RestaurantList.
 */
public interface LogicCurrentOrderView {
    /**
     * Obtiene lista de todos los platos
     * @return orden
     */
    List<DishOrder> getOrderSW();
}
