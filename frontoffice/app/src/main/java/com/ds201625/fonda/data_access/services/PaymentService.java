package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicPaymentWebApiControllerException;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.Restaurant;

/**
 * Paymentservice interface
 */
public interface PaymentService {

    /**
     * Registra el pago para una factura
     * @param idRestaurant,orderId,profileId,payment
     * @return
     * @throws RestClientException
     * @throws InvalidDataRetrofitException
     */
    Invoice setPayments(int idRestaurant, int orderId, int profileId, Payment payment)
            throws RestClientException, InvalidDataRetrofitException, LogicPaymentWebApiControllerException;

    }
