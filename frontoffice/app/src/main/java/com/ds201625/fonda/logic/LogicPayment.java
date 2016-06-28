package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Invoice;

/**
 * Logica del pago
 */
public class LogicPayment {
/*

    */
/**
     * variable de tipo PaymentService
     *//*

    private Invoice payment;

    */
/**
     * Metodo que controla la llamada al ws para el manejo de facturas
     * @param invoice
     * @return
     * @throws RestClientException
     * @throws InvalidDataRetrofitException
     */

    /*public Invoice paymentService (Invoice invoice) throws RestClientException, InvalidDataRetrofitException {

        try {
            payment = FondaServiceFactory.getInstance().setPaymentService().setPayments(invoice);
        } catch (RestClientException e) {
            throw new RestClientException("Error de IO",e);
        } catch (InvalidDataRetrofitException e) {
            throw new InvalidDataRetrofitException("Invoice es nulo.");
        }
        return payment;
    }*/

}
