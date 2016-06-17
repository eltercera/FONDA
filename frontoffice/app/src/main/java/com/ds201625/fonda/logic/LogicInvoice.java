package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Invoice;

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
    private Invoice invoiceService;

    /**
     * Metodo que controla la llamada al ws para obtener la factura del cierre de cuenta
     * @return factura
     */
    public Invoice getInvoiceSW() throws RestClientException {

        try {
        invoiceService = FondaServiceFactory.getInstance().getInvoiceService().getCurrentInvoice();
        } catch (RestClientException e) {
            throw new RestClientException("Error de IO", e);
        }
        return invoiceService;

    }

}
