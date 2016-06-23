package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Commensal;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public interface ILoginViewPresenter {
    /**
     * Metodo para registrar un commensal
     * @param email
     * @param password
     */
    void regiter(String email, String password);

    /**
     * Metodo de logeo de un commensal
     * @param commensal
     */
    void login(Commensal commensal);
}
