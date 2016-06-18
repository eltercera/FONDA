package com.ds201625.fonda.presenter;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.IAllRestaurantsView;
import com.ds201625.fonda.interfaces.IAllRestaurantsViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 * Presentador para obtener todos los restaurantes
 */
public class AllRestaurantsPresenter implements IAllRestaurantsViewPresenter {
    private FondaCommandFactory facCmd;
    private   List<Restaurant> listRestWS;
    private IAllRestaurantsView iAllRestaurantsView;
    private Commensal logedComensal;
    private String emailToWebService;

    /**
     * Constructor
     * @param view
     */
    public AllRestaurantsPresenter(IAllRestaurantsView view){
        iAllRestaurantsView = view;
    }

    /**
     * Encuentra el comensal logueado
     */
    @Override
    public void findLoggedComensal() {
        Commensal log = SessionData.getInstance().getCommensal();
        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        } catch (Exception e) {
            e.printStackTrace();
        }

        logedComensal = (Commensal) cmdRequireLoged.getResult();
    }
    /**
     * Encuentra todos los restaurantes
     *
     * @return
     */
    @Override
    public List<Restaurant> findAllRestaurants() {
        Command cmdAllRest = facCmd.allRestaurantCommand();
        try {
            cmdAllRest.run();
        } catch (Exception e) {
            e.printStackTrace();
        }
        listRestWS = (List<Restaurant>) cmdAllRest.getResult();

        return listRestWS;
    }

}
