package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de RestaurantList.
 */
public interface LogicHistoryVisitsView {
    /**
     * Obtiene lista de historial de pagos
     * @return orden
     */
    List<Invoice> getHistoryVisitsSW();
}
