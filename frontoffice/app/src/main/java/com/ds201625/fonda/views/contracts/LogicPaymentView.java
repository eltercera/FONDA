package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Invoice;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de Payments.
 */
public interface LogicPaymentView {
    /**
     * Obtiene el pago
     * @return pago
     */
    Invoice getPaymentSW();
}
