package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Comando para agregar un restaurant a favorite
 */
public class AddFavoriteRestaurantCommand extends BaseCommand {

    private String TAG = "AddFavoriteRestaurantCommand";

    /**
     * Asigna valor a los parametros
     * @return parametros comensal y restaurant
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Commensal.class, true);
        parameters[1] = new Parameter(Restaurant.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para agregar un restaurante favorito
     */
    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para agregar un restaurante a favoritos");

        FavoriteRestaurantService serviceFavorites = FondaServiceFactory.getInstance()
		.getFavoriteRestaurantService();
        Commensal commensal = FondaEntityFactory.getInstance().GetCommensal();
        Commensal idCommensal;
        Restaurant idRestaurant;
        try {
            idCommensal = (Commensal) getParameter(0);
            idRestaurant = (Restaurant) getParameter(1);

            commensal = serviceFavorites.AddFavoriteRestaurant(idCommensal.getId(),
                    idRestaurant.getId());
            //AKI IRAN MAS EXCEPCIONES RECIBIDAS D BO
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
    }

        setResult(commensal);
    }
}
