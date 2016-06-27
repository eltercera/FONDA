package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.Date;

/**
 * Comando para crear un Token
 */
public class CreateTokenCommand extends BaseCommand {

    private String TAG = "CreateTokenCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro Context y commensal
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Context.class, true);
        parameters[1] = new Parameter(Commensal.class, true);
        return parameters;
    }

    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para crear un Token");
        Context context;
        Commensal commensal;
        Token tokenTest = null;

        try
        {
            context = (Context) getParameter(0);
            commensal = (Commensal) getParameter(1);
            TokenService tokenService = FondaServiceFactory.getInstance().getTokenService(commensal);
            tokenTest = tokenService.getToken(context);
            if (tokenTest == null || tokenTest.getExpiration().compareTo(new Date()) < 0) {
                tokenTest = tokenService.createToken(context);
                Log.d(TAG, "Token creado: " + tokenTest.getId());
            }
            Log.d(TAG, "Token actual: " + tokenTest.getId());

        }
        catch (RestClientException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }
        catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }
        catch (Exception e)
        {
            Log.e(TAG, "Se ha generado error en invoke al crear un Token", e);
            e.printStackTrace();
        }

        setResult(tokenTest);
        Log.d(TAG, "Se agrego con exito el Token. Result: " + getResult().toString());
        Log.d(TAG, "Se agrego con exito el Token");
    }
}
