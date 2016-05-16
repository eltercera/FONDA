package com.ds201625.fonda.data_access.retrofit_client.clients;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class RetrofitService {

    private static RetrofitService instance;

    public static RetrofitService getInstance(){
        if ( instance == null)
            instance = new RetrofitService();

        return instance;
    }

    private final String API_BASE_URL = "http://201.210.163.221:5300/api/";

    private OkHttpClient.Builder httpClient = new OkHttpClient.Builder();

    private Retrofit.Builder builder =
            new Retrofit.Builder()
                    .baseUrl(API_BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create());

    public <S> S createService(Class<S> serviceClass) {
        Retrofit retrofit = builder.client(httpClient.build()).build();
        return retrofit.create(serviceClass);
    }


}
