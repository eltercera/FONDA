package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Comando para obtener el comensal logueado
 */
public class RequireLogedCommensalCommand extends BaseCommand {
    private String TAG = "RequireLogedCommensalCommand";
    /**
     * Asigna valor a los parametros
     * @return parametros comensal y restaurant
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(String.class, true);

        return parameters;
    }
    /**
     * Comando para obtener el comensal logueado
     */
    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para obtener el comensal logeado");
        Commensal commensal = FondaEntityFactory.getInstance().GetCommensal();

        String email = "";
        try {
            email = (String) getParameter(0);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener el comensal logeado", e);
        }

        try {
            email = (String) this.getParameter(1);
        } catch (Exception e) {
          //  Log.e(TAG, "Se ha generado error en invoke al obtener el comensal logeado", e);
        }

        RequireLogedCommensalService ps = FondaServiceFactory.getInstance()
                .getLogedCommensalService();

        try {
            commensal =  ps.getLogedCommensal(email);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener el comensal logeado", e);
        }

        setResult(commensal);
    }
}
