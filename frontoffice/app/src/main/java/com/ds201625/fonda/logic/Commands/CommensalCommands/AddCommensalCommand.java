package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Comando para agregar un commensal
 */
public class AddCommensalCommand extends BaseCommand {

    private String TAG = "AddCommensalCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro context y commensal
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

        Log.d(TAG, "Comando para agregar un commensal");
        Context context;
        Commensal commensal;

        CommensalService commensalService = FondaServiceFactory.getCommensalService();
        try
        {
            context = (Context) getParameter(0);
            commensal = (Commensal) getParameter(1);
            commensalService.saveCommensal(commensal,context);
        }
        catch (RestClientException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un commensal", e);
            e.printStackTrace();
        }
        catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un commensal", e);
            e.printStackTrace();
        }
        catch (LocalStorageException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un commensal", e);
            e.printStackTrace();
        }
        catch (Exception e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un commensal", e);
            e.printStackTrace();
        }


        setResult(true);
    }
}
