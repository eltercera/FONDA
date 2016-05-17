package com.ds201625.fonda.logic;

import android.content.Context;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import java.util.Date;

/**
 * Para mantener la objetos de uso constante
 */
public class SessionData {

    /**
     * Commensal logeado.
     */
    private Commensal commensal;

    /**
     * Token actual
     */
    private Token token;

    /**
     * Contexto de la aplicacion
     */
    private Context context;

    /**
     * Instancia singelton
     */
    private static SessionData instance;

    /**
     * Inicializacio del instancia
     * @param context
     */
    public static void initInstance(Context context) throws Exception {
        instance = new SessionData(context);
        instance.setCommensal();
        instance.setToken();
    }

    /**
     * Otemcion de la instancia.
     * @return
     */
    public  static SessionData getInstance() {
        return instance;
    }

    /**
     * Contctor
     * @param context Contexto de la aplicacion
     */
    private SessionData(Context context) {
        this.context = context;
    }

    /**
     * Obtiene el Commensal Logiado.
     * @return
     */
    public Commensal getCommensal() {
        return this.commensal;
    }

    /**
     * obtiene el Token Actual
     * @return
     */
    public Token getToken() {
        return this.token;
    }

    /**
     * Registro de un commensal.
     * @param email cooreo
     * @param password contraseña
     * @throws Exception
     */
    public void registerCommensal(String email, String password) throws Exception {
        if (email.isEmpty() || password.isEmpty()) {
            // // TODO: 5/16/16 InvalidRegisterDataException.
            throw new Exception("Datos de regsitro invalido");
        }
        Commensal newCommensal;
        newCommensal = getCommensalsrv().RegisterCommensal(email,password,context);

        if (newCommensal == null) {
            // // TODO: 5/16/16 Exception.
            throw new Exception("No se logro crear el usuario");
        }
        this.commensal = newCommensal;
    }

    /**
     * Obtencion de un token. (login)
     * @throws Exception
     */
    public void loginCommensal() throws Exception {
        if (this.commensal == null) {
            // // TODO: 5/16/16 No existe commensal Exception
            throw new Exception("No existe commensal");
        }
        Token tokenTest = getTokenServ().createToken(this.context);
        if (tokenTest == null) {
            // // TODO: 5/16/16 No se pudo obtener toke
            throw new Exception("No se pud obtener token");
        }
        this.token = tokenTest;
    }

    /**
     * Guarda localmente a un commensal
     * @param commensal
     * @throws LocalStorageException
     */
    public void addCommensal(Commensal commensal) throws LocalStorageException {
        getCommensalsrv().saveCommensal(commensal,context);
        setCommensal();
    }

    /**
     * Obtiene del commensal
     * @throws LocalStorageException
     */
    private void setCommensal() throws LocalStorageException {
        this.commensal = getCommensalsrv().getCommensal(this.context);
    }

    /**
     * Obtiene el token actual.
     */
    private void setToken() throws Exception {

        if (this.commensal == null)
            return;

        Token tokenTest = getTokenServ().getToken(this.context);
        if (tokenTest == null || tokenTest.getExpiration().compareTo(new Date()) < 0) {
            tokenTest = getTokenServ().createToken(this.context);
        }
        this.token = tokenTest;
    }

    /**
     * Obtiene el servicio de commensal
     * @return
     */
    private CommensalService getCommensalsrv() {
        return FondaServiceFactory.getInstance().getCommensalService();
    }

    /**
     * obtiene el servicio de Token.
     * @return
     */
    private TokenService getTokenServ() {
        return FondaServiceFactory.getInstance().getTokenService(commensal);
    }

}
