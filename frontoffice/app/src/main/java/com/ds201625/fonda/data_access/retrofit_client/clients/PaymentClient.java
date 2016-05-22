package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.CreditCarPayment;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by Hp on 21/05/2016.
 */


/**
 * Interface to be implemented by retrofit
 */
public interface PaymentClient {

       /**
        * Post /api/payment
        * Sends the payments to create the bill
        */
       @POST("payment")
       Call<CreditCarPayment> requestClosedOrder(int profileId, float tip, @Body CreditCarPayment creditCarPayment);
}
