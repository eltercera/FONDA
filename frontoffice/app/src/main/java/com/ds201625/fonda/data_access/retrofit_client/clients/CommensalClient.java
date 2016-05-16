package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by rrodriguez on 5/12/16.
 */
public interface CommensalClient {

    @POST("commensal")
    Call<Commensal> registerCommensal(@Body Commensal commensal);

}
