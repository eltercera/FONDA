package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Comando para consultar todos los restaurantes favoritos
 */
public class AllFavoriteRestaurantCommand extends BaseCommand {

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Integer.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        List<Restaurant> restaurantList = null;

        int idCommensal = 0;
        try {
            idCommensal = (Integer) getParameter(0);
        } catch (Exception e) {
            e.printStackTrace();
        }

        try {
            idCommensal = (Integer) this.getParameter(1);
        } catch (Exception e) {
            e.printStackTrace();
        }

        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();

        try {
            restaurantList =  ps.getAllFavoriteRestaurant(idCommensal);
        } catch (RestClientException e) {
           e.printStackTrace();
        }

        setResult(restaurantList);
    }
}
