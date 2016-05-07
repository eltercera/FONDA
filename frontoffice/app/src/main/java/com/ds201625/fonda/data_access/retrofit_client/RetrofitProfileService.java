package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class RetrofitProfileService implements ProfileService {

    private ProfileClient profileClient = ServiceFactory.createService(ProfileClient.class);

    @Override
    public Profile getProfile(int id) {
        return profileClient.getProfile(id);
    }

    @Override
    public List<Profile> getProfiles() {
        return profileClient.getProfiles();
    }
}
