package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.FavoritesListFragment;
import com.ds201625.fonda.views.fragments.RestaurantListFragment;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

public class AllRestaurantActivity extends BaseNavigationActivity
        implements RestaurantListFragment.restaurantListFragmentListener {

    // UI references.
    private ListView list;

    private RestaurantList adapter;
    private List<Restaurant> restaurantList;
    private Commensal logedComensal;
    private String TAG ="AllRestaurantActivity";

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    /**
     * ToolBar
     */
    private Toolbar tb;
    /**
     * Fragmento AllRestaurant
     */
    private RestaurantListFragment AllRestaurantFrag;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_all_restaurant);
        /**
         * Esta es la validacion de si el usuario ya esta loggeado o no.
         */
        // para saltar o no
        boolean skp = false;

        // inicializa los datos de la sesion
        if (SessionData.getInstance() == null) {
            try {
                SessionData.initInstance(getApplicationContext());
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        super.onCreate(savedInstanceState);

        if (SessionData.getInstance().getToken() == null) {
            skip();
            return;
        }
        else {

            // Obtencion de los componentes necesaios de la vista
            tb = (Toolbar) findViewById(R.id.toolbar);
            fm = getSupportFragmentManager();

            // Creacion de fragmen y pase argumento
            AllRestaurantFrag = new RestaurantListFragment();
            Bundle args = new Bundle();
            args.putBoolean("multiSelect", true);
            AllRestaurantFrag.setArguments(args);

            //Lanzamiento de profileListFrag como el principal
            fm.beginTransaction()
                    .replace(R.id.fragment_container_rest, AllRestaurantFrag)
                    .commit();


            // Asegura que almenos onCreate se ejecuto en el fragment
            fm.executePendingTransactions();
        }
    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,LoginActivity.class));
    }

    /**
     * Inicializa el ListView y le asigna valores.
     * @param
     * @return


    private void setupListView(){
        adapter = new
                RestaurantList(AllRestaurantActivity.this, names,location ,shortDescription,imageId,restaurantList);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                Intent detailActivity = new Intent(AllRestaurantActivity.this, DetailRestaurantActivity.class);
                Restaurant test = getSelectedRestaurant(position);
                detailActivity.putExtra("restaurant", new Gson().toJson(test));
                detailActivity.putExtra("commensal", new Gson().toJson(logedComensal));
                startActivity(detailActivity);
            }
        });
    }
     */

    /**
     * Devuelve el restaurante Seleccionado por el usuario.
     * @param //position
     * @return Restaurant.
     */
  /* private Restaurant getSelectedRestaurant(int position){
        int contador =0;
        for (Restaurant restaurant: this.restaurantList){
            if (contador == position){
                Log.v(TAG, restaurant.getName());
                return restaurant;
            }
            contador++;
        }
        return null;
    }*/


    @Override
    public void OnRestaurantSelect(Restaurant r) {

    }

    @Override
    public void OnRestaurantSelected(ArrayList<Restaurant> r) {

    }

    @Override
    public void OnRestaurantSelectionMode() {
        tb.setVisibility(View.GONE);
    }

    @Override
    public void OnRestaurantSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
    }
}
