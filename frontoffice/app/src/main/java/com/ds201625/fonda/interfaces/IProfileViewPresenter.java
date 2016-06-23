package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PutProfileFondaWebApiControllerException;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

/**
 * Interfaz de ProfilePresenter
 */
public interface IProfileViewPresenter {

    /**
     * Metodo para crear un perfil
     * @param profile
     * @return true si se agrego el perfil
     */
    Boolean createProfile (Profile profile) throws PostProfileFondaWebApiControllerException;

    /**
     * Metodo para modificar un perdil
     * @param profile
     * @return true si se modifico el perfil
     */
    Boolean updateProfile (Profile profile) throws PutProfileFondaWebApiControllerException;

    /**
     * Metodo para eliminar un perfil
     * @param profile
     * @return true si se elimino el perfil
     */
    Boolean deleteProfile (Profile profile) throws DeleteProfileFondaWebApiControllerException;

    /**
     * Metodo para buscar los perfiles de un commensal
     * @return la lista de perfiles
     */
    List<Profile> getProfiles () throws GetProfilesFondaWebApiControllerException;
}
