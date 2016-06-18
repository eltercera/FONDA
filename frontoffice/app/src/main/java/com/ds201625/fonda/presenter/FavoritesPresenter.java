package com.ds201625.fonda.presenter;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.IFavoriteView;
import com.ds201625.fonda.interfaces.IFavoriteViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 * Presentador para obtener todos los favoritos
 */
public class FavoritesPresenter implements IFavoriteViewPresenter {

    private IFavoriteView iFavoriteView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private List<Restaurant> listRestWS;

    /**
     * Constructor
     * @param view
     */
    public FavoritesPresenter(IFavoriteView view){
        iFavoriteView = view;
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
     * Encuentra los restaurantes favoritos
     *
     * @return
     */
    @Override
    public List<Restaurant> findAllFavoriteRestaurant() {
        Command cmdAllFavorite = facCmd.allFavoriteRestaurantCommand();
        try {
            cmdAllFavorite.setParameter(0,logedComensal);
            cmdAllFavorite.run();
        } catch (Exception e) {
            e.printStackTrace();
        }
        listRestWS = (List<Restaurant>) cmdAllFavorite.getResult();
        return listRestWS;
    }

    /**
     * Elimina el restaurante seleccionado
     *
     * @param restaurant
     */
    @Override
    public void deleteFavoriteRestaurant(Restaurant restaurant) {
        Command cmdDelete = facCmd.deleteFavoriteRestaurantCommand();
        try {
            cmdDelete.setParameter(0,logedComensal);
            cmdDelete.setParameter(1,restaurant);
            cmdDelete.run();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Agrega un restaurante a favoritos
     *
     * @param restaurant
     */
    @Override
    public void addFavoriteRestaurant(Restaurant restaurant) {
        Command cmdAddFavorite = facCmd.addFavoriteRestaurantCommand();
        try {
            cmdAddFavorite.setParameter(0,logedComensal);
            cmdAddFavorite.setParameter(1,restaurant);
            cmdAddFavorite.run();

        } catch (Exception e) {
            e.printStackTrace();
        }

    }



}
