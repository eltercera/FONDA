package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Profile;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by rrodriguez on 5/7/16.
 */
public interface ProfileClient {

    @GET("profile/{id}")
    Profile getProfile(@Path("id") int id);

    @GET("profiles")
    Call<List<Profile>> getProfiles();

}
