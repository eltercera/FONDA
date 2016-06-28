package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Restaurant;

public interface DetailRestaurantActivityContract {

    /**
     * Inicializar la vista
     * @param restaurant
     */
    void setDetailsViewOf(Restaurant restaurant);

    /**
     * Cambiar el modo del icono de faboitos.
     * @param fab true es favorito false en otro caso.
     */
    void setIconFavorite(boolean fab);

    /**
     * Mostar un mensaje
     * @param msj
     */
    void displayMsj(String msj);
}
