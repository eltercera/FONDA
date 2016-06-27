package com.ds201625.fonda.views.contracts;

import android.content.Context;
import android.widget.ListView;
import com.ds201625.fonda.domains.Restaurant;

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

    /**
     * Cirerra la vista de busqueda
     */
    void closeSearchView();

    void displayMsj(String msj);

    void setListViewEmtyType(ListViewEmtyType type);

    void setMultiSelect(Boolean multiSelect);

    void openRestaurantActiviy(Restaurant restaurant);

    enum ListViewEmtyType {
        NORMAL,
        NO_CONNECTION,
        EMPTY
    }
}
