package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.IFavoriteView;
import com.ds201625.fonda.interfaces.IFavoriteViewPresenter;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.presenter.FavoritesPresenter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.DetailRestaurantFragment;
import com.ds201625.fonda.views.fragments.FavoritesListFragment;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity de los Resturantes Favoritos
 */
public class FavoritesActivity extends BaseNavigationActivity implements
        IFavoriteView, FavoritesListFragment.favoritesListFragmentListener {

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
    /**
     * Fragmento de Detalle de restaurant
     */
    private DetailRestaurantFragment detailRestaurantFrag;
    // UI references.
    private Restaurant selectedRestaurant;
    /**
     * String para indicar en que clase se esta en el logger
     */
    private String TAG ="FavoritesActivity";
    /**
     * Iten del Menu para favorito
     */
    private MenuItem favoriteBotton;
    private MenuItem reserveBotton;
    /**
     * Variable booleana para determinar el form
     */
    private boolean onForm;
    /**
     * Presentador de Favoritos
     */
    private IFavoriteViewPresenter presenter;

    /**
     * Inicializa la actividad
     * @param savedInstanceState
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        setContentView(R.layout.activity_favorites);
       presenter = new FavoritesPresenter(this);


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


    /**
     * Acción de saltar esta actividad.
     */
    public void skip() {
        Log.d(TAG,"Ha entrado en skip");
        startActivity(new Intent(this,LoginActivity.class));
        Log.d(TAG,"Ha salido de skip");
    }

    /**
     * Muestra el fragment actual
     * @param fragment
     */
    public void showFragment(BaseFragment fragment) {
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
     * Va a la actividad de reserva
     */
    public void goReserve() {
        Intent r = new Intent(this,ReserveActivity.class);
        startActivity(r);
    }

    /**
     * Elimina un restaurante de favoritos
     */
    public void removeFavorite() {
            //Valida que es un favorito o lo quita
        Log.d(TAG,"Ha entrado en removeFavorite");
         try {
             //Llamo al presentador de requireLogedCommensalCommand
                presenter.findLoggedComensal();
                selectedRestaurant = detailRestaurantFrag.getRestaurant();
                //Llamo al presentador de deleteFavoriteRestaurant
                presenter.deleteFavoriteRestaurant(selectedRestaurant);
                Toast.makeText(getApplicationContext(), R.string.favorite_remove_success_meessage,
                        Toast.LENGTH_LONG).show();
                 showFragment(fv);
            }
            catch (NullPointerException nu) {
                Log.e(TAG,"Error en removeFavorite al eliminar un favorito",nu);
            }
         catch (Exception e) {
            Log.e(TAG,"Error en removeFavorite al eliminar un favorito",e);
        }
        hideKyboard();
         Log.d(TAG,"Se ha eliminado un favorito");
    }

    /**
     * Al seleccionar el restaurante
     * @param r
     */
    @Override
    public void OnFavoriteSelect(Restaurant r) {
        showFragment(detailRestaurantFrag);
        detailRestaurantFrag.setRestaurant(r);
        favoriteBotton.setIcon(R.drawable.ic_star_yellow);
    }

    /**
     * Al seleccionar el restaurante
     * @param r
     */
    @Override
    public void OnFavoriteSelected(ArrayList<Restaurant> r) {

    }
    /**
     * Al seleccionar el restaurante
     */
    @Override
    public void OnFavoriteSelectionMode() {
        tb.setVisibility(View.GONE);
    }
    /**
     * Al seleccionar el restaurante
     */
    @Override
    public void OnFavoriteSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
    }

    /**
     * Al presionar el botón volver
     */
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


    /**
     * Lista de todos los restaurantes favoritos
     *
     * @return restauraantes favoritos
     */
    @Override
    public List<Restaurant> getListSW() {
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {

    }
}
