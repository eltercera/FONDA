package com.ds201625.fonda.logic.Commands.RestaurantCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.Zone;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Comando para obtener zonas
 */
public class GetZonesCommand extends BaseCommand {

    private String TAG = "GetZonesCommand";

    /**
     * Asignacion de los parametros del comando.
     * Parametro en posicion 0: Query
     * Parametro en posicion 1: Max
     * Pareametro en posicion 2: Page
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[3];
        parameters[0] = new Parameter(String.class, true);
        parameters[1] = new Parameter(Integer.class, true);
        parameters[2] = new Parameter(Integer.class, true);

        return parameters;
    }

    @Override
    public void invoke () {
        Log.d(TAG, "Comando para obtener la lista de Categorias");
        List<Zone> zones = null;

        RestaurantService resService = FondaServiceFactory.getInstance()
                .getRestaurantService();

        try {
            String query = (String) getParameter(0);
            int max = (int) getParameter(1);
            int page = (int) getParameter(2);
            zones = resService.getZones(query, max, page);
        }
        catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener las zonas de restaurantes", e);
            e.printStackTrace();
        }

        setResult(zones);
    }

}
