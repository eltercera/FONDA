package com.ds201625.fonda.views.presenters;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.DetailRestaurantActivityContract;

/**
 * Created by rrodriguez on 6/25/16.
 */
public class DetailRestaurantActivityPresenter {

    public Restaurant restaurant;

    public DetailRestaurantActivityContract activity;

    public DetailRestaurantActivityPresenter
            (Restaurant restaurant, DetailRestaurantActivityContract activity) {
        this.restaurant = restaurant;
        this.activity = activity;
    }

    public void onCreate() {
        this.activity.setDetailsViewOf(this.restaurant);
    }


    public void setFavorite() {
        this.activity.setDetailsViewOf(this.restaurant);
    }

    public void goToReserve() {
        this.activity.setDetailsViewOf(this.restaurant);
    }

}
