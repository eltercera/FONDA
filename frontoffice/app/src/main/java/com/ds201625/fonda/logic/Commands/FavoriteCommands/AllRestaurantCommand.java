package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Comando para consultar todos los restaurantes favoritos
 */
public class AllRestaurantCommand extends BaseCommand {

    private String TAG = "AllRestaurantCommand";
    private List<Restaurant> restaurantList = null;
    /**
     * Asigna valor a los parametros
     * @return parametros comensal y restaurant
     */
    @Override
    protected Parameter[] setParameters() {

        Parameter [] parameters = new Parameter[0];
        return parameters;
    }
    /**
     * Metodo de invoke implementado: Comando para mostrar todos los restaurantes
     */
    @Override
    protected void invokeF() throws GetAllRestaurantsFondaWebApiControllerException {

        Log.d(TAG, "Comando para obtener los restaurantes");

        AllRestaurantService serviceAllRestaurants = FondaServiceFactory.getInstance().
                getAllRestaurantsService();

        try {
            restaurantList =  serviceAllRestaurants.getAllRestaurant();
        }
        catch(GetAllRestaurantsFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes", e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        }

        setResult(restaurantList);
    }

    @Override
    protected void invoke() {}
}
