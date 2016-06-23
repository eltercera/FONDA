package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Token;

import retrofit2.Call;
import retrofit2.http.DELETE;
import retrofit2.http.POST;
import retrofit2.http.Path;

/**
 * Created by rrodriguez on 5/16/16.
 */
public interface TokenClient {
    @POST("token")
    Call<Token> postToken();

    @DELETE("token/{id}")
    Call<Token> deleteToken(@Path("id") int id);
}
