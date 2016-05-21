package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Invoice;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by Hp on 21/05/2016.
 */
public interface PaymentClient {
       @POST("payment")
       Call<Invoice> setPayments(@Body Invoice invoice);
}
