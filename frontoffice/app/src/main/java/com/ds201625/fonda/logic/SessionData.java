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
            throw new Exception("Datos de regsitro invalido");
        }
        Commensal newCommensal;

        Command commandoCreateCommensal = FondaCommandFactory.createCommensalCommand();
        commandoCreateCommensal.setParameter(0,email);
        commandoCreateCommensal.setParameter(1,password);
        commandoCreateCommensal.setParameter(2,context);
        commandoCreateCommensal.run();
        newCommensal = (Commensal)commandoCreateCommensal.getResult();
        if (newCommensal == null) {
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
            throw new Exception("No existe commensal");
        }
        Token tokenTest = getTokenServ().createToken(this.context);
        if (tokenTest == null) {
            throw new Exception("No se pudo obtener token");
        }
        this.token = tokenTest;
    }

    public void logoutCommensal() throws Exception {
        removeToken();
        removeCommensal();
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
        Command commandoCreateToken = FondaCommandFactory.deleteTokenCommand();
        commandoCreateToken.setParameter(0,this.context);
        commandoCreateToken.setParameter(1,this.commensal);
        commandoCreateToken.run();
        Token tokenTest = (Token)commandoCreateToken.getResult();
        this.token = tokenTest;
    }

    private void removeToken() throws Exception {

        if (this.commensal == null)
            return;
        try
        {
            Command commandoDeleteToken = FondaCommandFactory.deleteTokenCommand();
            commandoDeleteToken.setParameter(0,this.context);
            commandoDeleteToken.setParameter(1,this.commensal);
            commandoDeleteToken.run();
            boolean resp =  (boolean)commandoDeleteToken.getResult();
            if (resp)
            { this.token = null;}
        }
        catch (Exception e)
        {}
    }

    private void removeCommensal() throws Exception {

        if (this.commensal == null)
            return;

        Commensal commensal = getCommensalsrv().getCommensal(this.context);
        if (commensal != null) {
            CommensalService service = getCommensalsrv();
            service.deleteCommensal(context);
        }

        this.commensal = null;
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
