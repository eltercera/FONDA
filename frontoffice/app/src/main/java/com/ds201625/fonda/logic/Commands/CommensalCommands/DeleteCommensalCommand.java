package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para eliminar un commensal
 */
public class DeleteCommensalCommand extends BaseCommand {

    private String TAG = "DeleteCommensalCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro context
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Context.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para eliminar un commensal");
        Context context;

        CommensalService commensalService = FondaServiceFactory.getInstance().getCommensalService();
        try
        {
            context = (Context) getParameter(0);
            commensalService.deleteCommensal(context);
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

        setResult(true);
    }
}
