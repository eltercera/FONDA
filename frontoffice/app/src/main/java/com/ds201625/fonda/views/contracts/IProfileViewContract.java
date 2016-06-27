
package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Profile;

/**
 * Interfaz de ProfileActivity
 */
public interface IProfileViewContract {

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

    /**
     * Metodo para el Despliegue de mensajes
     * @param msj
     */
    void displayMsj(String msj);
}
