package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.AddFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.DeleteFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindByEmailUserAccountFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
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
     * Metodo de invoke implementado: Comando para obtener el comensal logueado
     */
    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para obtener el comensal logeado");
        Commensal commensal = FondaEntityFactory.getInstance().GetCommensal();
        RequireLogedCommensalService serviceFavorites = FondaServiceFactory.getInstance()
                .getLogedCommensalService();
        String email = "";
        try {
            email = (String) this.getParameter(0);
            commensal =  serviceFavorites.getLogedCommensal(email);

        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener el comensal logeado", e);
        }catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener el comensal logeado", e);

        }
       setResult(commensal);
    }

}

