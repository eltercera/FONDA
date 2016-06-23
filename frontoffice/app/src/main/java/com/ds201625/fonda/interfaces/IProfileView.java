
package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Profile;

/**
 * Interfaz de ProfileActivity
 */
public interface IProfileView {

    /**
     * Metodo para crear un perfil
     * @param profile
     * @return true si se agrego el perfil
     */
    Boolean createProfile (Profile profile) throws Exception;

    /**
     * Metodo para modificar un perdil
     * @param profile
     * @return true si se modifico el perfil
     */
    Boolean updateProfile (Profile profile) throws Exception;
}
