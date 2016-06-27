package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.AddFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.DeleteFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindByEmailUserAccountFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
/**
 * Interfaz para el presentador de Favorite.
 */
public interface FavoriteViewPresenter {

    /**
     * Encuentra el comensal logueado
     */
    void findLoggedComensal() throws FindByEmailUserAccountFondaWebApiControllerException;

    /**
     * Encuentra los restaurantes favoritos
     * @return
     */
    List<Restaurant> findAllFavoriteRestaurant() throws
            FindFavoriteRestaurantFondaWebApiControllerException;

    /**
     * Elimina el restaurante seleccionado
     * @param restaurant
     */
    void deleteFavoriteRestaurant(Restaurant restaurant) throws
            DeleteFavoriteRestaurantFondaWebApiControllerException;

    /**
     * Agrega un restaurante a favoritos
     * @param restaurant
     */
    void addFavoriteRestaurant(Restaurant restaurant) throws
            AddFavoriteRestaurantFondaWebApiControllerException;
}

