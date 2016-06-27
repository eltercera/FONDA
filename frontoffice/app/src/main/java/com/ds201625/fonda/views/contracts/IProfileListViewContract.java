
package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Profile;

/**
 * Interfaz de ProfileListFragment
 */
public interface IProfileListViewContract {
    /**
     * Metodo para eliminar un perfil
     * @param profile
     * @return true si se elimino el perfil
     */
    Boolean deleteProfile (Profile profile) throws Exception;
}
