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

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.adapters.FavoriteRestViewItemList;
import com.ds201625.fonda.views.adapters.RestaurantViewItemList;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Hp on 06/06/2016.
 */
public class RestaurantListFragment extends BaseFragment implements SwipeRefreshLayout.OnRefreshListener{
   
    //Interface de comunicacion contra la activity
    restaurantListFragmentListener mCallBack;

    /**
     * Elementos de la vista
     */
    private ListView restaurants;
    private RestaurantViewItemList restList;
    private SwipeRefreshLayout swipeRefreshLayout;
    private boolean multi;
    private Commensal logedComensal;
    private String emailToWebService;
    private List<Restaurant> restaurantList;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        multi = getArguments().getBoolean("multiSelect");
        restList = new RestaurantViewItemList(getContext());
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_restaurants_list,container,false);
        restaurants = (ListView)layout.findViewById(R.id.lvRestaurantList);
        //swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        //swipeRefreshLayout.setOnRefreshListener(this);

        restaurantList = getListSW();

        restList.addAll(restaurantList);
        restaurants.setAdapter(restList);

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
                            String sal = "Fueron seleccionados los Favoritos.";
                            for (Restaurant r : restList.getAllSeletedItems()) {
                                FavoriteRestaurantService favservice = FondaServiceFactory.getInstance().
                                        getFavoriteRestaurantService();
                                try{

                                favservice.AddFavoriteRestaurant(logedComensal.getId(),r.getId());

                                } catch (RestClientException e) {
                                    e.printStackTrace();
                                }
                            }
                            Log.v("Favoritos seleccionados: ", sal);
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


        return layout ;
    }

    @Override
    public void onRefresh() {

    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            mCallBack = (restaurantListFragmentListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString()
                    + " must implement OnHeadlineSelectedListener");
        }
    }

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

            try {
                Commensal log = SessionData.getInstance().getCommensal();
                try {

                    emailToWebService=log.getEmail()+"/";
                    RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().getLogedCommensalService();
                    logedComensal =getComensal.getLogedCommensal(emailToWebService);
                    AllRestaurantService allRestaurant = FondaServiceFactory.getInstance().
                            getAllRestaurantsService();
                    listRestWS = allRestaurant.getAllRestaurant();
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
