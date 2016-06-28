package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de La orden actual.
 */
public interface LogicCurrentOrderView {
    /**
     * Obtiene a orden actual
     * @return orden
     */
    List<DishOrder> getOrderSW();
}
