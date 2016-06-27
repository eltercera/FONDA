package com.ds201625.fonda.views.presenters;

import android.util.Log;

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
 * Created by rrodriguez on 6/25/16.
 */
public class DetailSearchRestaurantActivityPresenter {

    public Restaurant restaurant;

    public DetailRestaurantActivityContract activity;

    public DetailSearchRestaurantActivityPresenter
            (Restaurant restaurant, DetailRestaurantActivityContract activity) {
        this.restaurant = restaurant;
        this.activity = activity;
    }

    public void onCreate() {
        this.activity.setDetailsViewOf(this.restaurant);
        this.activity.setIconFavorite(this.restaurant.getFavorite());
    }


    public void setFavorite() {

        Command cmd = FondaCommandFactory.getInstance().getSetFabRestaurantCommand();

        try {
            cmd.setParameter(0,this.restaurant.getId());
            cmd.setParameter(1,!this.restaurant.getFavorite());
        } catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
            e.printStackTrace();
            return;
        }

        try {
            cmd.run();
        } catch (Exception e) {
            /*if (e.getClass() == RestClientException.class
                    || e.getClass() == ServerErrorException.class
                    || e.getClass() == UnknownServerErrorException.class )*/
            e.printStackTrace();
            return;
        }

        this.restaurant.setFavorite(!this.restaurant.getFavorite());
        this.activity.setIconFavorite(this.restaurant.getFavorite());
    }

}
