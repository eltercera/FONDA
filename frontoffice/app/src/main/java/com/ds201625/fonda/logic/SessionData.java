package com.ds201625.fonda.logic;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;

import java.util.Date;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class SessionData {

    private Commensal commensal;

    private Token token;

    private Context context;

    private static SessionData instance;

    public static void initInstance(Context context) {
        instance = new SessionData(context);
        instance.setCommensal();
        instance.setToken();
    }

    public  static SessionData getInstance() {
        return instance;
    }

    private SessionData(Context context) {
        this.context = context;
    }

    public Commensal getCommensal() {
        return this.commensal;
    }

    public Token getToken() {
        return this.token;
    }

    private void setCommensal() {
        CommensalService commensalServ = FondaServiceFactory.getInstance().getCommensalService();
        this.commensal = commensalServ.getCommensal(this.context);
    }

    private void setToken() {

        if (this.commensal == null)
            return;

        TokenService tkService = FondaServiceFactory.getInstance().getTokenService(commensal);
        Token tokenTest = tkService.getToken(this.context);
        if (!(tokenTest != null && tokenTest.getExpiration().compareTo(new Date()) < 0)) {
            tokenTest = tkService.createToken(this.context);
        }
        this.token = tokenTest;
    }


}
