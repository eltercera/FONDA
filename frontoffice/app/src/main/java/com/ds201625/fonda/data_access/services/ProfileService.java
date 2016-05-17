package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

/**
 * Interfaz para el servicio de Profiles
 */
public interface ProfileService {

    List<Profile> getProfiles() throws RestClientException;
    void AddProfile(Profile profile) throws RestClientException;
    void EditProfile(Profile profile) throws RestClientException;
    void DeleteProfile(int id) throws RestClientException;
}
