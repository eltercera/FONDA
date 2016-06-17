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
 * Comando para eliminar un restaurant a favorite
 */
public class DeleteFavoriteRestaurantCommand extends BaseCommand {

    private String TAG = "DeleteFavoriteRestaurantCommand";

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Commensal.class, true);
        parameters[1] = new Parameter(Restaurant.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para eliminar un restaurante de favoritos");
        Commensal commensal = (Commensal) FondaEntityFactory.getInstance().GetCommensal();

        BaseEntity idCommensal = FondaEntityFactory.getInstance().GetCommensal();
        BaseEntity idRestaurant = FondaEntityFactory.getInstance().GetRestaurant();
        try {
            idCommensal = (Commensal) getParameter(0);
            idRestaurant = (Restaurant) getParameter(1);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un restaurant favorito", e);
        }

        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();

        try {
             commensal =  ps.deleteFavoriteRestaurant(idCommensal.getId(),idRestaurant.getId());
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un restaurant favorito", e);
        }

        setResult(commensal);
    }
}
