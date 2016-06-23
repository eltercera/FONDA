package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Comando para mostrar todos los restaurantes favoritos
 */
public class AllFavoriteRestaurantCommand extends BaseCommand {
    private String TAG = "AllFavoriteRestaurantCommand";
    private List<Restaurant> restaurantList = null;
    private Commensal idCommensal;
    /**
     * Asigna valor a los parametros
     * @return parametros comensal y restaurant
     */
    @Override
    protected Parameter[] setParameters() {

        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Commensal.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para mostrar todos los restaurantes favoritos
     */
    @Override
    protected void invoke()  {
        Log.d(TAG, "Comando para obtener los restaurantes favoritos");
        FavoriteRestaurantService serviceFavorits = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();
        idCommensal = FondaEntityFactory.getInstance().GetCommensal();

        try {
            idCommensal = (Commensal) this.getParameter(0);
            restaurantList =  serviceFavorits.getAllFavoriteRestaurant(idCommensal.getId());

            //AKI IRAN D BO DE PARAMETROS
        } catch (RestClientException e) {
           // throw  new FindFavoriteRestaurantFondaWebApiControllerException(e);
        //    Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes favoritos", e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
        } catch (Exception e) {
          //  throw  new FindFavoriteRestaurantFondaWebApiControllerException(e);
          //  Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito");
        }
        setResult(restaurantList);
    }
}
