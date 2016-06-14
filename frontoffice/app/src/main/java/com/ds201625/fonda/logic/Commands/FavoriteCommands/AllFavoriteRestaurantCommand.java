package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

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
    private String TAG = "AllFavoriteRestaurantCommand";
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Integer.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para obtener los restaurantes favoritos");
        List<Restaurant> restaurantList = null;

        int idCommensal = 0;
        try {
            idCommensal = (Integer) getParameter(0);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes favoritos", e);
        }

        try {
            idCommensal = (Integer) this.getParameter(1);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes favoritos", e);
        }

        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();

        try {
            restaurantList =  ps.getAllFavoriteRestaurant(idCommensal);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes favoritos", e);
        }

        setResult(restaurantList);
    }
}
