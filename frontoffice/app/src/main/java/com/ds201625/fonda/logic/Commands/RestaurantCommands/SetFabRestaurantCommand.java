package com.ds201625.fonda.logic.Commands.RestaurantCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.CommandInternalErrorException;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;


public class SetFabRestaurantCommand extends BaseCommand {

    private String TAG = "GetCategoriesCommand";

    /**
     * Asignacion de los parametros del comando.
     * Parametro en posicion 0: id restaurante
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Integer.class, true);
        parameters[1] = new Parameter(Boolean.class, true);

        return parameters;
    }

    @Override
    protected void invoke() throws Exception {

        RestaurantService resService = FondaServiceFactory.getInstance()
                .getRestaurantService(SessionData.getInstance().getToken());

        Integer id;
        Boolean bool;
        try {
            id = (Integer) getParameter(0);
            bool = (Boolean) getParameter(1);
        } catch (ParameterOutOfIndexException e) {
            Log.e("Fonda Command",e.getMessage());
            throw CommandInternalErrorException.generate(this.getClass().toString(),e);
        }

        resService.setRestaurantFab(bool,id);

    }
}