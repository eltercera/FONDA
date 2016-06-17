package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.entities.Commensal;
import com.ds201625.fonda.domains.entities.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Comando para agregar un restaurant a favorite
 */
public class AddFavoriteRestaurantCommand extends BaseCommand {

    private String TAG = "AddFavoriteRestaurantCommand";

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Commensal.class, true);
        parameters[1] = new Parameter(Restaurant.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para agregar un restaurante a favoritos");
        Commensal commensal = (Commensal) FondaEntityFactory.getInstance().GetCommensal();

        BaseEntity idCommensal = FondaEntityFactory.getInstance().GetCommensal();
        BaseEntity idRestaurant = FondaEntityFactory.getInstance().GetRestaurant();
        try {
            idCommensal = (Commensal) getParameter(0);
            idRestaurant = (Restaurant) getParameter(1);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
        }

        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();

        try {
             commensal =  ps.AddFavoriteRestaurant(idCommensal.getId(),idRestaurant.getId());
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
        }

        setResult(commensal);
    }
}
