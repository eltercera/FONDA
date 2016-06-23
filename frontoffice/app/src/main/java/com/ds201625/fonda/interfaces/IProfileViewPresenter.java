package com.ds201625.fonda.interfaces;

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
    Boolean createProfile (Profile profile);

    /**
     * Metodo para modificar un perdil
     * @param profile
     * @return true si se modifico el perfil
     */
    Boolean updateProfile (Profile profile);

    /**
     * Metodo para eliminar un perfil
     * @param profile
     * @return true si se elimino el perfil
     */
    Boolean deleteProfile (Profile profile);

    /**
     * Metodo para buscar los perfiles de un commensal
     * @return la lista de perfiles
     */
    List<Profile> getProfiles ();
}
