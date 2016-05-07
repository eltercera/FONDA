package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.factory.ServiceFactory;
import com.ds201625.fonda.data_access.services.ProfileService;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class RetroditServiceFactory implements ServiceFactory {

    @Override
    public ProfileService getProfileService() {
        return new RetrofitProfileService();
    }
}
