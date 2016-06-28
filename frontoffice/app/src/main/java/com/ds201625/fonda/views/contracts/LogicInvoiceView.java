package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Invoice;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de RestaurantList.
 */
public interface LogicInvoiceView {
    /**
     * Obtiene la factura
     * @return orden
     */
    Invoice getInvoiceSW();
}
