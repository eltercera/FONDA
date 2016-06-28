package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.Path;

/**
 * Created by Jessica on 21/06/2016.
 */


/**
 * Interfaz a ser implementada por retrofit
 */
public interface PaymentClient {

       /**
        * Post /api/payment
        * Envia el pagopara crear la factura
        */
       @POST("PayAccount/{idRestaurant}/{idOrder}/{idProfile}/{Payment}")
       Call<Invoice> setPayments(@Path("idrestaurant") int idRestaurant,
                                 @Path("idorder") int idOrder,
                                 @Path("idprofile") int idProfile,
                                 @Body Payment payment);
}
