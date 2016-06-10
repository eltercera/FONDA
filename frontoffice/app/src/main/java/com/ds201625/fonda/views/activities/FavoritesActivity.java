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
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.FavoritesListFragment;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

public class FavoritesActivity extends BaseNavigationActivity implements
        FavoritesListFragment.favoritesListFragmentListener {

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    /**
     * ToolBar
     */
    private Toolbar tb;
    /**
     * Fragmento favoritos
     */
    private FavoritesListFragment fv;

    // UI references.
    private ListView list;

    private RestaurantList adapter;
    private List<Restaurant> restaurantList;
    private Commensal logedComensal;
    private String TAG ="FavoritesActivity";




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_favorites);
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
                    fv = new FavoritesListFragment();
                    Bundle args = new Bundle();
                    args.putBoolean("multiSelect", true);
                    fv.setArguments(args);

                    //Lanzamiento de profileListFrag como el principal
                    fm.beginTransaction()
                            .replace(R.id.fragment_container_fav, fv)
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
     * Devuelve el restaurante Seleccionado por el usuario.
     * @param // position
     * @return Restaurant.

    private Restaurant getSelectedRestaurant(int position){
        int contador =0;
        for (Restaurant restaurant: this.restaurantList){
            if (contador == position){
                Log.v(TAG, restaurant.getName());
                return restaurant;
            }
            contador++;
        }
        return null;
    } */

    @Override
    public void OnFavoriteSelect(Restaurant r) {

    }

    @Override
    public void OnFavoriteSelected(ArrayList<Restaurant> r) {

    }

    @Override
    public void OnFavoriteSelectionMode() {
        tb.setVisibility(View.GONE);
    }

    @Override
    public void OnFavoriteSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
    }


}
