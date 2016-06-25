package com.ds201625.fonda.logic.Commands.RestaurantCommands;

import android.util.Log;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.CommandInternalErrorException;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;

import java.util.List;

/**
 * Comando para obtener categorias de restaurante
 */
public class GetCategoriesCommand extends BaseCommand {

    private String TAG = "GetCategoriesCommand";

    /**
     * Asignacion de los parametros del comando.
     * Parametro en posicion 0: Query
     * Parametro en posicion 1: Max
     * Pareametro en posicion 2: Page
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[3];
        parameters[0] = new Parameter(String.class, false);
        parameters[1] = new Parameter(Integer.class, false);
        parameters[2] = new Parameter(Integer.class, false);

        return parameters;
    }

    @Override
    protected void invoke() throws Exception {
        List<RestaurantCategory> categories = null;

        RestaurantService resService = FondaServiceFactory.getInstance()
                .getRestaurantService();

        int max = 0;
        int page = 0;
        String query = null;
        try {
            if (getParameter(1) != null) {
                max = (int) getParameter(1);
            }
            if (getParameter(2) != null) {
                page = (int) getParameter(2);
            }
            query = (String) getParameter(0);
        } catch (ParameterOutOfIndexException e) {
            Log.e("Fonda Command",e.getMessage());
            throw CommandInternalErrorException.generate(this.getClass().toString(),e);
        }

        categories = resService.getCategories(query, max, page);

        setResult(categories);
    }
}