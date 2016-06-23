package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Profile;
import java.util.List;

/**
 * Interfaz para el servicio de Profiles
 */
public interface ProfileService {

    List<Profile> getProfiles() throws RestClientException;
    void addProfile(Profile profile) throws RestClientException;
    void editProfile(Profile profile) throws RestClientException;
    void deleteProfile(int id) throws RestClientException;
}
