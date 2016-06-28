package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;

/**
 * Created by Jessica on 20/06/2016
 */

/**
 * Interfaz para la vista de Payments.
 */
public interface LogicPaymentViewPresenter {
    /**
     * Encuentra el pago
     * @return pago
     */
    Payment findAllPayments();

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal();
}
