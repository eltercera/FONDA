
package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PutProfileFondaWebApiControllerException;
import com.ds201625.fonda.domains.Profile;
import java.util.List;

/**
 * Interfaz para el servicio de Profiles
 */
public interface ProfileService {

    List<Profile> getProfiles() throws Exception;
    void addProfile(Profile profile) throws RestClientException, PostProfileFondaWebApiControllerException;
    void editProfile(Profile profile) throws RestClientException, PutProfileFondaWebApiControllerException;
    void deleteProfile(int id) throws RestClientException, DeleteProfileFondaWebApiControllerException;
}
