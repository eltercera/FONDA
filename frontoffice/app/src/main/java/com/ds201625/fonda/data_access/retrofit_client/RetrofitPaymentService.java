package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.PaymentClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.CreditCarPayment;
import com.ds201625.fonda.domains.Invoice;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by Melanie on 22/05/2016.
 */
public class RetrofitPaymentService implements PaymentService {

    /**
     * Instance rest cliente PaymentClient
     */
    private PaymentClient paymentClient = RetrofitService.getInstance().createService(PaymentClient.class);

    @Override
    public Invoice setPayments(Invoice invoice) throws RestClientException, InvalidDataRetrofitException {

        if (invoice == null){
            throw new InvalidDataRetrofitException("Invoice es nulo.");
        }

        Call<Invoice> call = paymentClient.setPayments(invoice);
        Invoice rsvPayment = null;
        try{
            rsvPayment = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }

        return rsvPayment;
    }


}


