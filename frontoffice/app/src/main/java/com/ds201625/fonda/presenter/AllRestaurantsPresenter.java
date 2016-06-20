package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.AllRestaurantsView;
import com.ds201625.fonda.interfaces.AllRestaurantsViewPresenter;
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
    public void findLoggedComensal() {
        Log.d(TAG,"Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();
        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
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
    public List<Restaurant> findAllRestaurants() {
        Log.d(TAG,"Ha entrado en findAllRestaurants");
        Command cmdAllRest = facCmd.allRestaurantCommand();
        try {
            cmdAllRest.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllRestaurants al buscar todos los restaurantes",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findAllRestaurants al buscar todos los restaurantes",
                    e);
        }
        listRestWS = (List<Restaurant>) cmdAllRest.getResult();
        Log.d(TAG,"Se retorna la lista de Restaurantes");
        Log.d(TAG,"Ha finalizado findAllRestaurants");
        return listRestWS;
    }

}
