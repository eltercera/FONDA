package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindByEmailUserAccountFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.AllRestaurantsView;
import com.ds201625.fonda.views.contracts.AllRestaurantsViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 * Presentador para obtener todos los restaurantes
 */
public class AllRestaurantsPresenter implements AllRestaurantsViewPresenter {
    private FondaCommandFactory facCmd;
    private   List<Restaurant> listRestWS;
    private AllRestaurantsView iAllRestaurantsView;
    private Commensal logedComensal;
    private String emailToWebService;
    private String TAG = "AllRestaurantsPresenter";

    /**
     * Constructor
     * @param view
     */
    public AllRestaurantsPresenter(AllRestaurantsView view){
        iAllRestaurantsView = view;
    }

    /**
     * Encuentra el comensal logueado
     */
    @Override
    public void findLoggedComensal() throws FindByEmailUserAccountFondaWebApiControllerException {
        Log.d(TAG,"Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();
        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        }catch (FindByEmailUserAccountFondaWebApiControllerException e) {
            Log.e(TAG, "Error en findLoggedComensal al buscar el comensal logueado", e);
            throw  new FindByEmailUserAccountFondaWebApiControllerException(e);
        }
        catch (NullPointerException e){
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
            throw  new FindByEmailUserAccountFondaWebApiControllerException(e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
            throw  new FindByEmailUserAccountFondaWebApiControllerException(e);
        }
         logedComensal = (Commensal) cmdRequireLoged.getResult();
        Log.d(TAG,"Se obtiene el comensal logueado "+logedComensal.getId());
        Log.d(TAG,"Ha finalizado findLoggedComensal");
    }
    /**
     * Encuentra todos los restaurantes
     *
     * @return
     */
    @Override
    public List<Restaurant> findAllRestaurants()
            throws GetAllRestaurantsFondaWebApiControllerException{
        Log.d(TAG,"Ha entrado en findAllRestaurants");
        Command cmdAllRest = facCmd.allRestaurantCommand();
        try {
            cmdAllRest.run();
        }catch (GetAllRestaurantsFondaWebApiControllerException e) {
            Log.e(TAG,"Error en findAllRestaurants al buscar los restaurantes favoritos",
                    e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        }
        catch (NullPointerException e){
            Log.e(TAG,"Error en findAllRestaurants al buscar todos los restaurantes",
                    e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findAllRestaurants al buscar todos los restaurantes",
                    e);
            throw  new GetAllRestaurantsFondaWebApiControllerException(e);
        }
        listRestWS = (List<Restaurant>) cmdAllRest.getResult();
        Log.d(TAG,"Se retorna la lista de Restaurantes");
        Log.d(TAG,"Ha finalizado findAllRestaurants");
        return listRestWS;
    }

}
