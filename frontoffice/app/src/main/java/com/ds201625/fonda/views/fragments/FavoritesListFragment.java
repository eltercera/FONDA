package com.ds201625.fonda.views.fragments;

import android.content.Context;
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
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.adapters.FavoriteRestViewItemList;

import java.util.ArrayList;
import java.util.List;

/**
 * Fragment que contiene la lista de restaurantes favoritos
 */
public class FavoritesListFragment extends BaseFragment implements SwipeRefreshLayout.OnRefreshListener{
   
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
    private List<Restaurant> restaurantList;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        multi = getArguments().getBoolean("multiSelect");
        favoritesList = new FavoriteRestViewItemList(getContext());
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_favorites_list,container,false);
        restaurants = (ListView)layout.findViewById(R.id.lvFavoriteList);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);


        restaurantList = getListSW();
        favoritesList.addAll(restaurantList);
        restaurants.setAdapter(favoritesList);



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

                                FondaCommandFactory facCmd = FondaCommandFactory.getInstance();

                                try{

                                    //Llamo al comando de deleteFavoriteRestaurant
                                    Command cmdDelete = facCmd.deleteFavoriteRestaurantCommand();
                                    cmdDelete.setParameter(0,logedComensal.getId());
                                    cmdDelete.setParameter(1,r.getId());
                                    cmdDelete.run();

                                    Toast.makeText(FavoritesListFragment.super.getContext(),
                                            "Se han eliminado "+favoritesList.countSelected()+" Restaurantes de Favoritos",
                                            Toast.LENGTH_LONG).show();
                                } catch (RestClientException e) {
                                    e.printStackTrace();
                                }
                                catch (Exception e) {
                                    System.out.println("Error en la Conexión");
                                }
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

        restaurants.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Restaurant item = favoritesList.getItem(position);
                mCallBack.OnFavoriteSelect(item);
            }
        });


        return layout ;
    }

    @Override
    public void onRefresh() {
        updateList();
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            mCallBack = (favoritesListFragmentListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString()
                    + " must implement OnHeadlineSelectedListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
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
         * Cuando es seleccionado un restaurante favorito
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


    /**
     * Metodo que obtiene los elementos del WS
     */
    public List<Restaurant> getListSW(){
        List<Restaurant> listRestWS;

            try {
                Commensal log = SessionData.getInstance().getCommensal();
                try {

                    emailToWebService=log.getEmail()+"/";

                    FondaCommandFactory facCmd = FondaCommandFactory.getInstance();

                    //Llamo al comando de requireLogedCommensalCommand
                    Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
                    cmdRequireLoged.setParameter(0,emailToWebService);
                    cmdRequireLoged.run();
                    logedComensal = (Commensal) cmdRequireLoged.getResult();

                    //Llamo al comando de allFavoriteRestaurantCommand
                    Command cmdAllFavorite = facCmd.allFavoriteRestaurantCommand();
                    cmdAllFavorite.setParameter(0,logedComensal.getId());
                    cmdAllFavorite.run();

                    listRestWS = (List<Restaurant>) cmdAllFavorite.getResult();

                    return listRestWS;
                } catch (RestClientException e) {
                    e.printStackTrace();
                }
                catch (NullPointerException nu) {
                    nu.printStackTrace();
                }
            } catch (Exception e) {
                System.out.println("Error en la Conexión");
            }

        return null;
    }


}
