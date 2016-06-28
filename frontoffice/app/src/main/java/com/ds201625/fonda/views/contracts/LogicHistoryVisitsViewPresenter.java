package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de RestaurantList.
 */
public interface LogicHistoryVisitsViewPresenter {
    /**
     * Encuentra todos los platos pedidos
     * @return orden
     */
    List<Invoice> findAllHistoryVisits();

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();
}
