package com.ds201625.fonda.interfaces;

import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Hp on 17/06/2016.
 */
/**
 * Interfaz para la vista de FavoriteList.
 */
public interface FavoriteView {

    /**
     * Lista de todos los restaurantes favoritos
     * @return restauraantes favoritos
     */
    List<Restaurant> getListSW();

    /**
     * Actualiza la lista luego de eliminar
     */
    void updateList();
}
