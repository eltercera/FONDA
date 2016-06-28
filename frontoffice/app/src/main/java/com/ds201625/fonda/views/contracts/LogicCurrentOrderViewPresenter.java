package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.DishOrder;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de la orden actual.
 */
public interface LogicCurrentOrderViewPresenter {
    /**
     * Encuentra todos los platos pedidos
     * @return orden
     */
    List<DishOrder> findAllDishOrder();

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();
}
