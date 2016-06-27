package com.ds201625.fonda.views.presenters;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.UnknownServerErrorException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.ServerErrorException;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.InvalidParameterTypeException;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.views.contracts.DetailRestaurantActivityContract;

/**
 * Presentador de vista de detalles de restaurantes
 */
public class DetailSearchRestaurantActivityPresenter {

    /**
     * El restaurante a mostrar
     */
    public Restaurant restaurant;

    /**
     * Activity con la implementacion de la interfaz
     */
    public DetailRestaurantActivityContract activity;

    /**
     * Contructor
     * @param restaurant Restaurante a mostrar
     * @param activity Activity con la implementacion de la interfaz
     */
    public DetailSearchRestaurantActivityPresenter
            (Restaurant restaurant, DetailRestaurantActivityContract activity) {
        this.restaurant = restaurant;
        this.activity = activity;
    }

    public void onCreate() {
        this.activity.setDetailsViewOf(this.restaurant);
        this.activity.setIconFavorite(this.restaurant.getFavorite());
    }

    /**
     * Accion de marcar / desmarcar como favorito
     */
    public void setFavorite() {

        Command cmd = FondaCommandFactory.getInstance().getSetFabRestaurantCommand();

        try {
            cmd.setParameter(0,this.restaurant.getId());
            cmd.setParameter(1,!this.restaurant.getFavorite());
        } catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
            this.activity.displayMsj("Se ha producido un error interno en la aplicación " +
                    "intente mas tarde.");
            e.printStackTrace();
            return;
        }

        try {
            cmd.run();
        } catch (Exception e) {
            if (e.getClass() == RestClientException.class
                    || e.getClass() == ServerErrorException.class
                    || e.getClass() == UnknownServerErrorException.class ){
                this.activity.displayMsj("Se ha producido un error al conectarse con el servidor, " +
                        "intente mas tarde.");
            }
            e.printStackTrace();
            return;
        }

        this.restaurant.setFavorite(!this.restaurant.getFavorite());
        this.activity.setIconFavorite(this.restaurant.getFavorite());
        this.activity.displayMsj("Se han agregado el restaurante " +
                this.restaurant.getName() +" a sus favoritos.");
    }

}
