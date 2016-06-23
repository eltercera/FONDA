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
import com.ds201625.fonda.data_access.retrofit_client.exceptions.AddFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.AllRestaurantsView;
import com.ds201625.fonda.interfaces.AllRestaurantsViewPresenter;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.interfaces.FavoriteViewPresenter;
import com.ds201625.fonda.presenter.AllRestaurantsPresenter;
import com.ds201625.fonda.presenter.FavoritesPresenter;
import com.ds201625.fonda.views.adapters.RestaurantViewItemList;

import java.util.ArrayList;
import java.util.List;

/**
 * Fragment que contiene la lista de restaurantes
 */
public class RestaurantListFragment extends BaseFragment implements
        AllRestaurantsView,FavoriteView, SwipeRefreshLayout.OnRefreshListener{
    /**
     * String para indicar al logger la clase actual
     */
    private String TAG = "RestaurantListFragment";

    //Interface de comunicacion contra la activity
    restaurantListFragmentListener mCallBack;

    /**
     * Elementos de la vista
     */
    private ListView restaurants;
    private RestaurantViewItemList restList;
    private boolean multi;
    private List<Restaurant> restaurantList;
    private AllRestaurantsViewPresenter presenter;
    private FavoriteViewPresenter presenterfav;

    /**
     * Crea el fragment
     * @param savedInstanceState
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        super.onCreate(savedInstanceState);
        multi = getArguments().getBoolean("multiSelect");
        restList = new RestaurantViewItemList(getContext());
        presenter = new AllRestaurantsPresenter(this);
        presenterfav = new FavoritesPresenter(this);
    }

    /**
     * Crea la vista
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreateView");
        View layout = inflater.inflate(R.layout.fragment_restaurants_list,container,false);
        restaurants = (ListView)layout.findViewById(R.id.lvRestaurantList);

        restaurantList = getListSW();
        try {
            restList.addAll(restaurantList);
            restaurants.setAdapter(restList);
        }
        catch(NullPointerException e){

        }
        if(multi) {
            restaurants.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
            restaurants.setMultiChoiceModeListener(new AbsListView.MultiChoiceModeListener() {
                @Override
                public void onItemCheckedStateChanged(ActionMode mode, int position, long id,
                                                      boolean checked) {
                    Log.d("Message:", position + " Is StateChanged");
                    restList.setSelectedItem(position, checked);
                    mode.setTitle(restList.countSelected() + " Seleccionado(s)");
                }

                @Override
                public boolean onCreateActionMode(ActionMode mode, Menu menu) {
                    mCallBack.OnRestaurantSelectionMode();
                    mode.getMenuInflater().inflate(R.menu.favorites_add_multiselect, menu);
                    return true;
                }

                @Override
                public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
                    return false;
                }

                @Override
                public boolean onActionItemClicked(ActionMode mode, MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.action_set_favorite:

                            for (Restaurant r : restList.getAllSeletedItems()) {
                             try{
                                 //Llamo al comando de addFavoriteRestaurant
                                    presenterfav.findLoggedComensal();
                                    presenterfav.addFavoriteRestaurant(r);

                                    Toast.makeText(RestaurantListFragment.super.getContext(),
                                            "Se han agregado "+restList.countSelected()+
                                                    " Restaurantes a Favoritos",
                                            Toast.LENGTH_LONG).show();
                                    Log.d("Favoritos eliminados: ",r.getName().toString());
                                }catch (AddFavoriteRestaurantFondaWebApiControllerException e) {
                                    Toast.makeText(RestaurantListFragment.super.getContext(),
                                            "Ha ocurrido un error al obtener los restaurantes del WS",
                                            Toast.LENGTH_LONG).show();
                                    Log.e(TAG, "Error Proveniente del WEB SERVICE al obtener favoritos", e);
                                }
                                catch (Exception e) {
                                    Log.e(TAG,"Error en onActionItemClicked al agregar restaurant",
                                            e);
                                }
                            }

                            restList.cleanSelected();
                            mCallBack.OnRestaurantSelectionModeExit();
                            mode.finish();
                            break;

                        default:
                            return false;
                    }
                    return true;
                }

                @Override
                public void onDestroyActionMode(ActionMode mode) {
                    mCallBack.OnRestaurantSelectionModeExit();
                    restList.cleanSelected();
                }
            });

        }

        restaurants.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Restaurant item = restList.getItem(position);
                mCallBack.OnRestaurantSelect(item);
            }
        });

        Log.d(TAG,"Ha salido de onCreateView");
        return layout ;
    }

    /**
     * AL refrescar el fragment
     */
    @Override
    public void onRefresh() {

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
            mCallBack = (restaurantListFragmentListener) context;
        } catch (ClassCastException e) {
            Log.e(TAG,"Error en onAttach", e);
            throw new ClassCastException(context.toString());
        }
        Log.d(TAG,"Ha salido de onAttach");
    }

    /**
     * Cuando se desune
     */
    @Override
    public void onDetach() {
        super.onDetach();
    }


    /**
     * Interface de la comunicacion contra una Activity
     */
    public interface restaurantListFragmentListener {
        /**
         * Cuando es seleccionado un restaurante
         * @param r
         */
        void OnRestaurantSelect(Restaurant r);

        /**
         * Cuando Son seleccionados varios.
         * @param r
         */
        void OnRestaurantSelected(ArrayList<Restaurant> r);

        /**
         * Cuando el modo se seleccion inicia
         */
        void OnRestaurantSelectionMode();

        /**
         * Cuando el modo de seleccion finaliza
         */
        void OnRestaurantSelectionModeExit();
    }


    /**
     * Metodo que obtiene los elementos del WS
     */
    public List<Restaurant> getListSW(){
        List<Restaurant> listRestWS;
        Log.d(TAG,"Ha ingresado a getListSW");
            try {
                presenter.findLoggedComensal();

                   listRestWS = presenter.findAllRestaurants();
                    return listRestWS;
                } catch (GetAllRestaurantsFondaWebApiControllerException e) {
                Toast.makeText(RestaurantListFragment.super.getContext(),
                        "Ha ocurrido un error al obtener los restaurantes del WS",
                        Toast.LENGTH_LONG).show();
                Log.e(TAG, "Error Proveniente del WEB SERVICE al obtener lista de restaurantes", e);
            }
            catch (NullPointerException nu) {
                    Log.e(TAG,"Error en getListSW al obtener restaurantes", nu);
                }
             catch (Exception e) {
                Log.e(TAG,"Error en getListSW al obtener restaurantes", e);
            }
        Log.d(TAG,"Ha finalizado getListSW");
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {

    }


}
