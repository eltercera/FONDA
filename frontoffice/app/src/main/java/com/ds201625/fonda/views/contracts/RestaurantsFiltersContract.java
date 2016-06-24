package com.ds201625.fonda.views.contracts;

import android.content.Context;
import android.widget.ListView;

/**
 * Contrato de vista de busqueda de restaurantes
 */
public interface RestaurantsFiltersContract {

    /**
     * Obtiene el context de la app
     * @return context
     */
    Context getContext();

    /**
     * Obtiene el listview de la vista
     * @return ListView
     */
    ListView getListView();
}
