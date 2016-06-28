package com.ds201625.fonda.views.contracts;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public interface LoginViewContract {

    /**
     * Metodo para registrar un commensal
     * @param email
     * @param password
     * @param repassword
     */
    void regiter(String email, String password, String repassword);

    /**
     * Metodo de logeo de un commensal
     * @param email
     * @param password
     */
    void login(String email, String password);

    /**
     * Metodo para el Despliegue de mensajes
     * @param msj
     */
    void displayMsj(String msj);
}
