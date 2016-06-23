package com.ds201625.fonda.logic.Commands.FavoriteCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.DeleteFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Comando para eliminar un restaurant a favorite
 */
public class DeleteFavoriteRestaurantCommand extends BaseCommand {

    private String TAG = "DeleteFavoriteRestaurantCommand";
    private Commensal commensal;
    private Commensal idCommensal;
    private Restaurant idRestaurant;
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
     * Metodo de invoke implementado: Comando para eliminar un restaurante favorito
     */
    @Override
    protected void invoke() throws DeleteFavoriteRestaurantFondaWebApiControllerException {
        Log.d(TAG, "Comando para eliminar un restaurante de favoritos");
        FavoriteRestaurantService serviceFavorits = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();
        commensal = FondaEntityFactory.getInstance().GetCommensal();
        idCommensal = FondaEntityFactory.getInstance().GetCommensal();
        idRestaurant = FondaEntityFactory.getInstance().GetRestaurant();

        try {
            idCommensal = (Commensal) getParameter(0);
            idRestaurant = (Restaurant) getParameter(1);
            commensal =  serviceFavorits.deleteFavoriteRestaurant(idCommensal.getId(),
                    idRestaurant.getId());

        } catch(DeleteFavoriteRestaurantFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al obtener los restaurantes favoritos", e);
            throw  new DeleteFavoriteRestaurantFondaWebApiControllerException(e);
        }catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un restaurant favorito", e);
            throw  new DeleteFavoriteRestaurantFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
            throw  new DeleteFavoriteRestaurantFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un restaurant favorito", e);
            throw  new DeleteFavoriteRestaurantFondaWebApiControllerException(e);
    }
        setResult(commensal);
    }
}
