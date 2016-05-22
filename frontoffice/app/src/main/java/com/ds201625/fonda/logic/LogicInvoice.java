package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.InvoiceService;

/**
 * Created by Katherina Molina on 5/21/2016.
 */

/**
 * clase que controla la logica de la factura
 */
public class LogicInvoice {

    /**
     * variable de tipo InvoiceService
     */
    private InvoiceService invoiceService;

    /**
     * Metodo que controla la llamada al ws para obtener la factura del cierre de cuenta
     * @return factura
     */
    public InvoiceService getInvoiceSW(){

        invoiceService = FondaServiceFactory.getInstance().getInvoiceService();
        return invoiceService;

    }

}
