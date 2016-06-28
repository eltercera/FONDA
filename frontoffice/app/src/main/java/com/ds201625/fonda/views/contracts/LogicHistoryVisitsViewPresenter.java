package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de historial de pagos.
 */
public interface LogicHistoryVisitsViewPresenter {
    /**
     * Encuentra historial de pagos
     * @return lista de pagos
     */
    List<Invoice> findAllHistoryVisits();

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();
}
