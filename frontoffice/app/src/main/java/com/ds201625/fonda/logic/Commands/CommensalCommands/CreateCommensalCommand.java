package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para crear un perfil
 */
public class CreateCommensalCommand extends BaseCommand {

    private String TAG = "CreateProfileCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro email y password
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[3];
        parameters[0] = new Parameter(String.class, true);
        parameters[1] = new Parameter(String.class, true);
        parameters[2] = new Parameter(Context.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para agregar un perfil a un commensal");
        String email;
        String password;
        Context context;
        Commensal commensal = null;

        CommensalService commensalService = FondaServiceFactory.getInstance().getCommensalService();
        try
        {
            email = (String) getParameter(0);
            password = (String) getParameter(1);
            context = (Context) getParameter(2);
            commensal = commensalService.RegisterCommensal(email,password,context);
        }
        catch (RestClientException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }
        catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }
        catch (Exception e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }

        setResult(commensal);
    }
}
