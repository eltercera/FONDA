package com.ds201625.fonda.logic.Commands.RestaurantCommands;

import android.util.Log;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.CommandInternalErrorException;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Comando para obtener restaurantes
 */
public class GetRestaurantsCommand extends BaseCommand {

    private String TAG = "GetRestaurantsCommand";

    /**
     * Asignacion de los parametros del comando.
     * Parametro en posicion 0: Query
     * Parametro en posicion 1: Max
     * Pareametro en posicion 2: Page
     * Parametro en posicion 3: Zone
     * Parametro en posicion 4: Category
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[5];
        parameters[0] = new Parameter(String.class, false);
        parameters[1] = new Parameter(Integer.class, false);
        parameters[2] = new Parameter(Integer.class, false);
        parameters[3] = new Parameter(Integer.class, false);
        parameters[4] = new Parameter(Integer.class, false);

        return parameters;
    }

    @Override
    protected void invoke() throws Exception {
        Log.d(TAG, "Comando para obtener la lista de restaurantes");
        List<Restaurant> restaurants = null;

        RestaurantService resService = FondaServiceFactory.getInstance()
                .getRestaurantService(SessionData.getInstance().getToken());

        int max = 0;
        int page = 0;
        int zone = 0;
        int category = 0;

        try
        {
            String query = (String) getParameter(0);

            if (getParameter(1) != null) {
                max = (int) getParameter(1);
            }
            if (getParameter(2) != null) {
                page = (int) getParameter(2);
            }
            if (getParameter(3) != null) {
                zone = (int) getParameter(3);
            }
            if (getParameter(4) != null) {
                category = (int) getParameter(4);
            }
            restaurants = resService.getRestaurants(query, max, page, category, zone);
        } catch (ParameterOutOfIndexException e) {
            Log.e("Fonda Command",e.getMessage());
            throw CommandInternalErrorException.generate(this.getClass().toString(),e);
        }

        setResult(restaurants);
    }
}
