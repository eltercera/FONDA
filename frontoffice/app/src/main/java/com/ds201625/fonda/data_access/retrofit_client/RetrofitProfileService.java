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

    @Override
    public void AddProfile(Profile profile) {
        Call<Profile> call = profileClient.postProfile(profile);
        Profile aux = null;
        try{
            aux = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }
    }

    @Override
    public void EditProfile(Profile profile) {
        Call<Profile> call = profileClient.putProfile(profile,profile.getId());
        Profile aux = null;
        try{
            aux = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }
    }

    @Override
    public void DeleteProfile(int id) {
        Call<String> call = profileClient.DeleteProfile(id);
        String aux = null;
        try{
            aux = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ", e.toString());
        }
    }
}
