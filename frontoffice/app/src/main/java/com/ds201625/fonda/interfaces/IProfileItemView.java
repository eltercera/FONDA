package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.presenter.ProfilePresenter;

import java.util.List;

/**
 * Interfaz de ProfileViewItemList
 */
public interface IProfileItemView {

    /**
     * Metodo para buscar los perfiles de un commensal
     * @return la lista de perfiles
     */
    List<Profile> getProfiles (IProfileViewPresenter presenter);
}
