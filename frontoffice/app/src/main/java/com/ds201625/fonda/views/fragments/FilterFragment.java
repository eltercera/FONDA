package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.ActionMode;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.RestaurantsFiltersContract;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;

/**
 * Frament para la vista de busqueda de restaurantes
 */
public class FilterFragment extends BaseFragment
        implements SwipeRefreshLayout.OnRefreshListener,RestaurantsFiltersContract,
        AbsListView.MultiChoiceModeListener,
        AbsListView.OnScrollListener{

    /**
     * componentes de la vista
     */
    private ListView listView;
    private SwipeRefreshLayout swipeRefreshLayout;
    private FilterFragmentListener activity;
    private MenuItem itemFav;

    /**
     * presentador / controlador
     */
    private RestaurantsFilterPresenter presenter;

    /**
     * Para controlar la actualizacion de la lista con el scroll
     */
    private int lastfirstVisibleItem = 100;
    private int lastvisibleItemCount = 100;

    /**
     * Asignacion del presentador / controlador
     * @param presenter
     */
    public void setPresenter(RestaurantsFilterPresenter presenter) {
        this.presenter = presenter;
    }

    /**
     * Asignacion de activity padre.
     * @param activity
     */
    public void setActivity(FilterFragmentListener activity) {
        this.activity = activity;
    }

    /**
     * Implementacion de contrato
     * @return
     */
    @Override
    public ListView getListView() {
        return this.listView;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        //Obtencion de componentes
        View layout = inflater.inflate(R.layout.fragment_filter,container,false);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);
        if (this.listView == null) {
            this.listView = (ListView) layout.findViewById(R.id.lvFilterList);
        }

        // inicializacion de componetes y escuchas
        this.presenter.onCreateView();

        this.listView.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView view, int scrollState) {

            }

            @Override
            public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {

                if (totalItemCount > 0 && lastfirstVisibleItem !=firstVisibleItem
                        && lastvisibleItemCount != visibleItemCount) {
                    int lastInScreen = firstVisibleItem + visibleItemCount;
                    if(lastInScreen == totalItemCount) {
                        lastfirstVisibleItem =firstVisibleItem;
                        lastvisibleItemCount = visibleItemCount;
                        presenter.scrollOnBottom();
                    }
                }
            }
        });

        this.listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                presenter.onItemClick(position);
            }
        });

        return layout;
    }

    @Override
    public void onScrollStateChanged(AbsListView view, int scrollState) {

    }

    /**
     * Control de paginacion del scroll
     */
    @Override
    public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {

        if (totalItemCount > 0 && this.lastfirstVisibleItem !=firstVisibleItem
                && this.lastvisibleItemCount != visibleItemCount) {
            int lastInScreen = firstVisibleItem + visibleItemCount;
            if(lastInScreen == totalItemCount) {
                this.lastfirstVisibleItem =firstVisibleItem;
                this.lastvisibleItemCount = visibleItemCount;
                this.presenter.scrollOnBottom();
            }
        }
    }

    /**
     * actualizacion total de la lista
     */
    @Override
    public void onRefresh() {
        this.swipeRefreshLayout.setRefreshing(true);
        this.presenter.onRefresh();
        this.swipeRefreshLayout.setRefreshing(false);
    }

    /**
     * proxy
     * @return
     */
    public boolean onBackPressed() {
        return this.presenter.onBackPressed();
    }

    /**
     * proxy
     * @param restaurant
     */
    public void openRestaurantActiviy(Restaurant restaurant) {
        this.activity.openRestaurantActiviy(restaurant);
    }

    /**
     * Proxy search
     * @param query string de busqueda
     */
    public void search(String query) {
        presenter.search(query);
    }


    @Override
    public void closeSearchView() {
        this.activity.closeSearchView();
    }

    @Override
    public void displayMsj(String msj) {
        activity.displayMsj(msj);
    }

    @Override
    public void setListViewEmtyType(ListViewEmtyType type) {
        switch (type) {
            case NORMAL:
                activity.setNormalView();
                break;
            case NO_CONNECTION:
                activity.setErrorView();
                break;

            case EMPTY:
                activity.setEmptyView();
                break;

            default:

                break;
        }
    }

    @Override
    public void setMultiSelect(Boolean multiSelect) {
        if (multiSelect) {
            this.listView.setChoiceMode(AbsListView.CHOICE_MODE_MULTIPLE_MODAL);
            this.listView.setMultiChoiceModeListener(this);
        } else {
            this.listView.setChoiceMode(AbsListView.CHOICE_MODE_SINGLE);
            this.listView.setMultiChoiceModeListener(null);
        }
    }

    @Override
    public void onItemCheckedStateChanged(ActionMode mode, int position, long id, boolean checked) {
        int count = this.presenter.checkItem(position,checked);
        mode.setTitle(count + (count>1?" selecciones":" selección"));
    }

    @Override
    public boolean onCreateActionMode(ActionMode mode, Menu menu) {
        this.activity.onMultiSelect(true);
        mode.getMenuInflater().inflate(R.menu.detail_restaurant, menu);
        this.itemFav = menu.findItem(R.id.action_set_favorite);
        this.itemFav.setIcon(R.drawable.ic_star_yellow);
        this.itemFav.setVisible(true);
        menu.findItem(R.id.action_make_order).setVisible(false);
        return true;
    }

    @Override
    public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
        return true;
    }

    @Override
    public boolean onActionItemClicked(ActionMode mode, MenuItem item) {
        if (item.getItemId() == this.itemFav.getItemId()) {
            this.presenter.favoriteMack();
            mode.finish();
        }
        return true;
    }

    @Override
    public void onDestroyActionMode(ActionMode mode) {
        this.activity.onMultiSelect(false);
        this.presenter.reset();
    }

    /**
     * Interface de comunicación conta el Activity padre
     */
    public interface FilterFragmentListener {

        /**
         * Para el cierre de la vista de busqueda
         */
        void closeSearchView();

        /**
         * Para mostrar un mensaje
         * @param msj mensajea mostrar
         */
        void displayMsj(String msj);

        /**
         * Obtiene una vista
         * @param id
         * @return
         */
        View findViewById (int id);

        /**
         * Vista normal
         */
        void setNormalView();

        /**
         * Vista con  lista vacia
         */
        void setEmptyView();

        /**
         * Vista de error
         */
        void setErrorView();

        /**
         * Apertura de actividad de restaurante
         * @param restaurant
         */
        void openRestaurantActiviy(Restaurant restaurant);

        /**
         * Colocar la actividad en modo multi seleccion
         * @param multi
         */
        void onMultiSelect(boolean multi);
    }
}
