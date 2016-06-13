package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para agregar un restaurant a favorite
 */
public class AddFavoriteRestaurantCommand extends BaseCommand {

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Integer.class, true);
        parameters[1] = new Parameter(Integer.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        Commensal commensal = null;

        int idCommensal = 0;
        int idRestaurant = 0;
        try {
            idCommensal = (Integer) getParameter(0);
            idRestaurant = (Integer) getParameter(1);
        } catch (Exception e) {
            e.printStackTrace();
        }

        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();

        try {
             commensal =  ps.AddFavoriteRestaurant(idCommensal,idRestaurant);
        } catch (RestClientException e) {
           e.printStackTrace();
        }

        setResult(commensal);
    }
}
