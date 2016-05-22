package com.ds201625.fonda.data_access.services;

import android.app.backup.RestoreObserver;
import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.CreditCarPayment;
import com.ds201625.fonda.domains.Invoice;

/**
 * Paymentservice interface
 */
public interface PaymentService {

    /**
     * Registra el pago para una factura
     * @param invoice
     * @return
     * @throws RestClientException
     * @throws InvalidDataRetrofitException
     */
    Invoice setPayments(Invoice invoice) throws RestClientException, InvalidDataRetrofitException;

    }
