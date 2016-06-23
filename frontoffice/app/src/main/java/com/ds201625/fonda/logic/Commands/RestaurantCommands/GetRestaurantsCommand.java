package com.ds201625.fonda.logic.Commands.RestaurantCommands;

import android.util.Log;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
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
        parameters[0] = new Parameter(String.class, true);
        parameters[1] = new Parameter(Integer.class, true);
        parameters[2] = new Parameter(Integer.class, true);
        parameters[3] = new Parameter(String.class, true);
        parameters[4] = new Parameter(String.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para obtener la lista de Categorias");
        List<Restaurant> restaurants = null;

        RestaurantService resService = FondaServiceFactory.getInstance()
                .getRestaurantService();

        try
        {
            String query = (String) getParameter(0);
            int max = (int) getParameter(1);
            int page = (int) getParameter(2);
            String zone = (String) getParameter(3);
            String category = (String) getParameter(4);
            restaurants = resService.getRestaurants(query, max, page, category, zone);
        }
        catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes", e);
            e.printStackTrace();
        }

        setResult(restaurants);
    }
}
