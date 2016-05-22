package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Invoice;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by Hp on 21/05/2016.
 */


/**
 * Interfaz para ser implementada por retrofit
 */
public interface PaymentClient {

       /**
        * Post /api/payment
        * Envia los pagos de las facturas
        */
       @POST("payment")
       Call<Invoice> setPayments(@Body Invoice invoice);
}
