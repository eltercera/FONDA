package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Token;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Implementacion de la interfaz ProfileService
 */
public class RetrofitProfileService implements ProfileService {

    /**
     * Instancia cliente rest ProfileClient
     */
    private ProfileClient profileClient;

    public RetrofitProfileService(Token token) {
        super();
        profileClient = RetrofitService.getInstance()
                .createService(ProfileClient.class,token.getStrToken());
    }

    @Override
    public List<Profile> getProfiles() throws RestClientException {
        Call<List<Profile>> call = profileClient.getProfiles();
        List<Profile> profiles = null;
        try{
            profiles = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }
        return profiles;
    }

    @Override
    public void addProfile(Profile profile) throws RestClientException {
        Call<Profile> call = profileClient.postProfile(profile);
        Profile ProfileNew = null;
        try{
            ProfileNew = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }
    }

    @Override
    public void editProfile(Profile profile) throws RestClientException {
        Call<Profile> call = profileClient.putProfile(profile,profile.getId());
        Profile profileNew = null;
        try{
            profileNew = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }
    }

    @Override
    public void deleteProfile(int id) throws RestClientException {
        Call<String> call = profileClient.DeleteProfile(id);
        String aux = null;
        try{
            aux = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }
    }
}
