package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Profile;

/**
 * Interfaz de ProfileListFragment
 */
public interface IProfileListView {
    /**
     * Metodo para eliminar un perfil
     * @param profile
     * @return true si se elimino el perfil
     */
    Boolean deleteProfile (Profile profile);
}
