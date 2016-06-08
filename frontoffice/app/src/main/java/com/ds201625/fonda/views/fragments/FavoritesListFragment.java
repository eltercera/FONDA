package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.ActionMode;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.adapters.FavoriteRestViewItemList;

import java.util.ArrayList;

/**
 * Created by Hp on 06/06/2016.
 */
public class FavoritesListFragment extends BaseFragment implements SwipeRefreshLayout.OnRefreshListener{
    //Declaracion de
    String[] names = {
            "The dining room",
            "Mogi Mirin",
            "Gordo & Magro",
            "La Casona",
            "Tony's"} ;
    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;
    String[] shortDescription = {
            "Casual",
            "Romantico",
            "Italiano",
            "Italiano",
            "Americano"} ;
    Integer[] imageId = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002,
            R.mipmap.ic_restaurant003,
            R.mipmap.ic_restaurant004,
            R.mipmap.ic_restaurant005,

    };

    //Interface de comunicacion contra la activity
    favoritesListFragmentListener mCallBack;

    /**
     * Elementos de la vista
     */
    private ListView restaurants;
    private FavoriteRestViewItemList favoritesList;
    private SwipeRefreshLayout swipeRefreshLayout;
    private boolean multi;
    private Commensal logedComensal;
    private String emailToWebService;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        favoritesList = new FavoriteRestViewItemList(getContext());
        multi = getArguments().getBoolean("multiSelect");
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_favorites_list,container,false);
        restaurants = (ListView)layout.findViewById(R.id.lvFavoriteList);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);

        restaurants.setAdapter(favoritesList);
        Commensal log = SessionData.getInstance().getCommensal();
        emailToWebService=log.getEmail()+"/";
        RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().getLogedCommensalService();
        logedComensal =getComensal.getLogedCommensal(emailToWebService);

        if(multi) {
            restaurants.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
            restaurants.setMultiChoiceModeListener(new AbsListView.MultiChoiceModeListener() {
                @Override
                public void onItemCheckedStateChanged(ActionMode mode, int position, long id,
                                                      boolean checked) {
                    Log.d("Message:", position + " Is StateChanged");
                    favoritesList.setSelectedItem(position, checked);
                    mode.setTitle(favoritesList.countSelected() + " Seleccionado(s)");
                }

                @Override
                public boolean onCreateActionMode(ActionMode mode, Menu menu) {
                    mCallBack.OnFavoriteSelectionMode();
                    mode.getMenuInflater().inflate(R.menu.favorites_multiselect, menu);
                    return true;
                }

                @Override
                public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
                    return false;
                }

                @Override
                public boolean onActionItemClicked(ActionMode mode, MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.deleteFavorites:
                            String sal = "Fueron eliminados los Favoritos.";
                            for (Restaurant r : favoritesList.getAllSeletedItems()) {
                                 FavoriteRestaurantService favservice = FondaServiceFactory.getInstance().
                                        getFavoriteRestaurantService();

                                favservice.deleteFavoriteRestaurant(logedComensal.getId(),r.getId());
                            }
                            Log.v("Favoritos eliminados: ", sal);
                            favoritesList.cleanSelected();
                            mCallBack.OnFavoriteSelectionModeExit();
                            mode.finish();
                            updateList();
                            break;

                        default:
                            return false;
                    }
                    return true;
                }

                @Override
                public void onDestroyActionMode(ActionMode mode) {
                    mCallBack.OnFavoriteSelectionModeExit();
                    favoritesList.cleanSelected();
                }
            });

        }
            return layout ;
    }

    @Override
    public void onRefresh() {

    }


    public void updateList() {
        swipeRefreshLayout.setRefreshing(true);
        favoritesList.update(logedComensal.getId());
        restaurants.refreshDrawableState();
        swipeRefreshLayout.setRefreshing(false);
    }

    /**
     * Interface de la comunicacion contra una Activity
     */
    public interface favoritesListFragmentListener {
        /**
         * Cuando es seleccionado un perfil
         * @param r
         */
        void OnFavoriteSelect(Restaurant r);

        /**
         * Cuando Son seleccionados varios.
         * @param r
         */
        void OnFavoriteSelected(ArrayList<Restaurant> r);

        /**
         * Cuando el modo se seleccion inicia
         */
        void OnFavoriteSelectionMode();

        /**
         * Cuando el modo de seleccion finaliza
         */
        void OnFavoriteSelectionModeExit();
    }

}
