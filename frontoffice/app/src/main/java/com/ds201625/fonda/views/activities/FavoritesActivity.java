package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.DetailRestaurantFragment;
import com.ds201625.fonda.views.fragments.FavoritesListFragment;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity de los Resturantes Favoritos
 */
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

    private DetailRestaurantFragment detailRestaurantFrag;
    // UI references.
    private ListView list;

    private RestaurantList adapter;
    private List<Restaurant> restaurantList;
    private Commensal logedComensal;
    private String TAG ="FavoritesActivity";
    private String emailToWebService;
    private Restaurant selectedRestaurant;

    /**
     * Iten del Menu para favorito
     */
    private MenuItem favoriteBotton;
    private MenuItem reserveBotton;

    private boolean onForm;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
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
                    detailRestaurantFrag = new DetailRestaurantFragment();
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
        Log.d(TAG,"Ha salido de onCreate");
    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        Log.d(TAG,"Ha entrado en skip");
        startActivity(new Intent(this,LoginActivity.class));
        Log.d(TAG,"Ha salido de skip");
    }

    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        Log.d(TAG,"Ha entrado en showFragment");
        fm.beginTransaction()
                .replace(R.id.fragment_container_fav,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(fv)){
            Log.d(TAG,"Fragment FavoritesListFragment");
            if(favoriteBotton != null)
                favoriteBotton.setVisible(false);
            if(reserveBotton != null)
                reserveBotton.setVisible(false);
            onForm = false;
        } else {
            if(favoriteBotton != null)
                Log.d(TAG,"Fragment DetailRestaurantFragment");
                favoriteBotton.setVisible(true);
            if(reserveBotton != null)
                reserveBotton.setVisible(true);
            onForm = true;

        }
        Log.d(TAG,"Ha salido de showFragment");
    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        Log.d(TAG,"Ha entrado en onCreateOptionsMenu");
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);
        favoriteBotton = menu.findItem(R.id.action_set_favorite);
        reserveBotton = menu.findItem(R.id.action_make_order);
        Log.d(TAG,"Ha salido de onCreateOptionsMenu");
        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        Log.d(TAG,"Ha entrado en onOptionsItemSelected");
        switch (item.getItemId()) {
            case R.id.action_set_favorite:
                removeFavorite();
                break;
            case R.id.action_make_order:
                goReserve();
                break;
        }
        Log.d(TAG,"Ha salido de onOptionsItemSelected");
        return true;
    }

    private void goReserve() {
        Intent r = new Intent(this,ReserveActivity.class);
        startActivity(r);
    }

    private void removeFavorite() {
        //Valida que es un favorito o lo quita
        Log.d(TAG,"Ha entrado en removeFavorite");
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

                selectedRestaurant = detailRestaurantFrag.getRestaurant();

                //Llamo al comando de deleteFavoriteRestaurant
                Command cmdDelete = facCmd.deleteFavoriteRestaurantCommand();
                cmdDelete.setParameter(0,logedComensal.getId());
                cmdDelete.setParameter(1,selectedRestaurant.getId());
                cmdDelete.run();

                Toast.makeText(getApplicationContext(), R.string.favorite_remove_success_meessage,
                        Toast.LENGTH_LONG).show();

                showFragment(fv);
            } catch (RestClientException e) {
                Log.e(TAG,"Error en removeFavorite al eliminar un favorito",e);
            }
            catch (NullPointerException nu) {
                Log.e(TAG,"Error en removeFavorite al eliminar un favorito",nu);
            }
        } catch (Exception e) {
            Log.e(TAG,"Error en removeFavorite al eliminar un favorito",e);
        }
         hideKyboard();

        Log.d(TAG,"Se ha eliminado un favorito");

    }


    @Override
    public void OnFavoriteSelect(Restaurant r) {
        showFragment(detailRestaurantFrag);
        detailRestaurantFrag.setRestaurant(r);
        favoriteBotton.setIcon(R.drawable.ic_star_yellow);
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

    @Override
    public void onBackPressed() {
        Log.d(TAG,"Ha entrado en onBackPressed");
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(fv);
        }
        Log.d(TAG,"Ha salido de onBackPressed");
    }

}
