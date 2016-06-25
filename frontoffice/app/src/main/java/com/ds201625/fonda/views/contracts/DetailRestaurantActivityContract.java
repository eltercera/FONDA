package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Restaurant;

public interface DetailRestaurantActivityContract {

    void setDetailsViewOf(Restaurant restaurant);

    void setIconFavorite(boolean fab);
}
