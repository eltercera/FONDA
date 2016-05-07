package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class RetrofitProfileService implements ProfileService {

    private ProfileClient profileClient =
            RetrofitService.getInstance().createService(ProfileClient.class);

    public RetrofitProfileService() {
        super();
    }

    @Override
    public Profile getProfile(int id) {
        return profileClient.getProfile(id);
    }

    @Override
    public List<Profile> getProfiles() {
        Call<List<Profile>> call = profileClient.getProfiles();
        List<Profile> a = null;
        try{
            a = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return a;
    }
}
