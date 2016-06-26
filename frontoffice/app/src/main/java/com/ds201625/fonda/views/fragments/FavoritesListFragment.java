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
import com.ds201625.fonda.data_access.retrofit_client.exceptions.*;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.interfaces.FavoriteViewPresenter;
import com.ds201625.fonda.presenter.FavoritesPresenter;
import com.ds201625.fonda.views.activities.FavoritesActivity;
import com.ds201625.fonda.views.adapters.FavoriteRestViewItemList;

import java.util.ArrayList;
import java.util.List;

/**
 * Fragment que contiene la lista de restaurantes favoritos
 */
public class FavoritesListFragment extends BaseFragment implements
        FavoriteView, SwipeRefreshLayout.OnRefreshListener{
    /**
     * String que indica la clase al logger
     */
    private String TAG = "FavoritesListFragment";

    //Interface de comunicacion contra la activity
    favoritesListFragmentListener mCallBack;

    /**
     * Elementos de la vista
     */
    private ListView restaurants;
    private FavoriteRestViewItemList favoritesList;
    private SwipeRefreshLayout swipeRefreshLayout;
    private boolean multi;
    private List<Restaurant> restaurantList;
    private FavoriteViewPresenter presenter;
    private FavoritesActivity favoritesAct;
    private boolean empty;
    /**
     * Crea el fragment
     * @param savedInstanceState
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        super.onCreate(savedInstanceState);
        multi = getArguments().getBoolean("multiSelect");
        favoritesList = new FavoriteRestViewItemList(getContext());
        presenter = new FavoritesPresenter(this);
    }

    /**
     * Crea la vista del fragment
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState)
    {
        Log.d(TAG,"Ha entrado en onCreateView");
        View layout = inflater.inflate(R.layout.fragment_favorites_list,container,false);
        restaurants = (ListView)layout.findViewById(R.id.lvFavoriteList);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);

        try {
            restaurantList = getListSW();
            if (restaurantList != null){
                favoritesList.addAll(restaurantList);
            }
            restaurants.setAdapter(favoritesList);
        }
        catch(NullPointerException e){
             Log.e(TAG,"Error al iniciar favoritos",e);
            }


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
                             for (Restaurant r : favoritesList.getAllSeletedItems()) {
                                try{
                                    //Llamo al comando de deleteFavoriteRestaurant
                                    presenter.deleteFavoriteRestaurant(r);
                                        Toast.makeText(FavoritesListFragment.super.getContext(),
                                            "Se han eliminado "+favoritesList.countSelected()+
                                            " Restaurantes de Favoritos",
                                            Toast.LENGTH_LONG).show();
                                    Log.d("Favoritos eliminados: ",r.getName().toString());
                                } catch (DeleteFavoriteRestaurantFondaWebApiControllerException e) {
                                    Toast.makeText(FavoritesListFragment.super.getContext(),
                                            "Ha ocurrido un error al eliminar los restaurantes del WS",
                                            Toast.LENGTH_LONG).show();
                                    Log.e(TAG, "Error Proveniente del WEB SERVICE al eliminar favoritos", e);
                                } catch (Exception e) {
                                    Log.e(TAG,"Error en onActionItemClicked al eliminar restaurant",
                                            e);
                                }
                             }
                            if(isEmptyFavorite()){
                                FavoritesActivity.changeFrag(1);
                            }
                            updateList();
                            favoritesList.cleanSelected();
                            mCallBack.OnFavoriteSelectionModeExit();
                            mode.finish();
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

        Log.d(TAG,"Ha finalizado onCreateView");
        return layout ;
    }

    /**
     * Cuando se refresca la lista
     */
    @Override
    public void onRefresh() {
        Log.d(TAG,"Ha ingresado a onRefresh");
        updateList();
        Log.d(TAG,"Ha finalizado onRefresh");
    }

    /**
     * Cuando se une
     * @param context
     */
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        Log.d(TAG,"Ha ingresado a onAttach");
        try {
            mCallBack = (favoritesListFragmentListener) context;
        } catch (ClassCastException e) {
            Log.e(TAG,"Error en onAttach", e);
            throw new ClassCastException(context.toString());
        }
        Log.d(TAG,"Ha finalizado onAttach");
    }

    /**
     * Cuando se desune
     */
    @Override
    public void onDetach() {
        super.onDetach();
    }

    /**
     * Actualiza la lista al eliminar favoritos
     */
    public void updateList() {
        Log.d(TAG,"Ha ingresado a updateList");
        swipeRefreshLayout.setRefreshing(true);
        favoritesList.updateList();
        restaurants.refreshDrawableState();
        swipeRefreshLayout.setRefreshing(false);
        Log.d(TAG,"Ha finalizado updateList");
    }
    /**
     * Devuelve el estado de los restaurantes favoritos con respecto al usuario.
     * @param
     * @return Boolean.
     */
    public boolean isEmptyFavorite() {
        try {
            //Llamo al comando de requireLogedCommensalCommand
            presenter.findLoggedComensal();
            List<Restaurant> restaurantList = presenter.findAllFavoriteRestaurant();

            if (restaurantList.size() == 0) {
                return true;
            }

        }catch (FindFavoriteRestaurantFondaWebApiControllerException e) {
            Toast.makeText(this.getContext(),
                    "Ha ocurrido un error al obtener los restaurantes (BO)",
                    Toast.LENGTH_LONG).show();
            Log.e(TAG, "Error Proveniente del WEB SERVICE al obtener favoritos", e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error al determinar si el commensal tiene favoritos",e);
        }
        return false;
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
        Log.d(TAG,"Ha ingresado a getListSW");
            try {
                //Llamo al comando de requireLogedCommensalCommand
                    presenter.findLoggedComensal();
                    //Llamo al comando de allFavoriteRestaurantCommand
                    listRestWS = presenter.findAllFavoriteRestaurant();
                    return listRestWS;
                }
                catch (NullPointerException nu) {
                    Toast.makeText(FavoritesListFragment.super.getContext(),
                            "Ha ocurrido un error al obtener los restaurantes",
                            Toast.LENGTH_LONG).show();
                    Log.e(TAG, "Error en getListSW al obtener favoritos", nu);
                } catch (FindFavoriteRestaurantFondaWebApiControllerException e) {
                Toast.makeText(this.getContext(),
                        "Ha ocurrido un error al obtener los restaurantes (BO)",
                        Toast.LENGTH_LONG).show();
                Log.e(TAG, "Error Proveniente del WEB SERVICE al obtener favoritos", e);
            } catch(Exception e){
                Toast.makeText(FavoritesListFragment.super.getContext(),
                        "Ha ocurrido un error al obtener los restaurantes",
                        Toast.LENGTH_LONG).show();
                Log.e(TAG, "Error en getListSW al obtener favoritos", e);
            }
        Log.d(TAG,"Ha finalizado getListSW");
        return null;
    }


}

