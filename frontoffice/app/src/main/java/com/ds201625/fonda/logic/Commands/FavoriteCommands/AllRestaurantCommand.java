package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Comando para consultar todos los restaurantes favoritos
 */
public class AllRestaurantCommand extends BaseCommand {

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[0];
        return parameters;
    }

    @Override
    protected void invoke() {

        List<Restaurant> restaurantList = null;

        AllRestaurantService ps = FondaServiceFactory.getInstance().getAllRestaurantsService();

        try {
            restaurantList =  ps.getAllRestaurant();
        } catch (RestClientException e) {
           e.printStackTrace();
        }

        setResult(restaurantList);
    }
}
