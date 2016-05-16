package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Profile;
import com.google.android.gms.appdatasearch.GetRecentContextCall;

import java.net.ResponseCache;
import java.util.List;
import java.util.concurrent.ThreadPoolExecutor;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by rrodriguez on 5/7/16.
 */
public interface ProfileClient {

    @GET("profiles")
    Call<List<Profile>> getProfiles();

    @POST("profile")
    Call<Profile> postProfile(@Body Profile profile);

    @PUT("profile/{id}")
    Call<Profile> putProfile(@Body Profile profile, @Path("id") int id);

    @DELETE("profile/{id}")
    Call<String> DeleteProfile(@Path("id") int id);


}
