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
import com.ds201625.fonda.domains.entities.Commensal;
import com.ds201625.fonda.domains.entities.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.DetailRestaurantFragment;
import com.ds201625.fonda.views.fragments.RestaurantListFragment;
import java.util.ArrayList;
import java.util.List;


/**
 * Activity de Todos los Resturantes
 */
public class AllRestaurantActivity extends BaseNavigationActivity
        implements RestaurantListFragment.restaurantListFragmentListener {

    // UI references.
    private ListView list;

    private RestaurantList adapter;
    private List<Restaurant> restaurantList;
    private String emailToWebService;
    private Commensal logedComensal;
    private String TAG ="AllRestaurantActivity";

    /**
     * Iten del Menu para favorito
     */
    private MenuItem favoriteBotton;
    private MenuItem reserveBotton;

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
    private RestaurantListFragment allRestaurantFrag;

    private DetailRestaurantFragment detailRestaurantFrag;

    private boolean onForm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
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
            allRestaurantFrag = new RestaurantListFragment();
            detailRestaurantFrag = new DetailRestaurantFragment();

            Bundle args = new Bundle();
            args.putBoolean("multiSelect", true);
            allRestaurantFrag.setArguments(args);

            //Lanzamiento de profileListFrag como el principal
            fm.beginTransaction()
                    .replace(R.id.fragment_container_rest, allRestaurantFrag)
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
                .replace(R.id.fragment_container_rest,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(allRestaurantFrag)){
            Log.d(TAG,"Fragment allRestaurantFrag");
            if(favoriteBotton != null)
                favoriteBotton.setVisible(false);
            if(reserveBotton != null)
                reserveBotton.setVisible(false);
            onForm = false;
        } else {
            if(favoriteBotton != null)
                favoriteBotton.setVisible(true);
            Log.d(TAG,"Fragment detailRestaurantFrag");
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
        // Inflate the menu; this adds items to the action bar if it is present.
        Log.d(TAG,"Ha entrado en onCreateOptionsMenu");
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
                save();
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

    private void save() {
        Log.d(TAG,"Ha entrado en save");
        //Guardar un favorito
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


                Restaurant restaurant = detailRestaurantFrag.getRestaurant();


                //Llamo al comando de addFavoriteRestaurant
                Command cmdAddFavorite = facCmd.addFavoriteRestaurantCommand();
                cmdAddFavorite.setParameter(0,logedComensal);
                cmdAddFavorite.setParameter(1,restaurant);
                cmdAddFavorite.run();

                Toast.makeText(getApplicationContext(), R.string.favorite_add_success_meessage,
                        Toast.LENGTH_LONG).show();
            } catch (RestClientException e) {
               Log.e(TAG,"Error en save al guardar un favorito",e);
            }
            catch (NullPointerException nu) {
                Log.e(TAG,"Error en save al guardar un favorito",nu);
            }
        } catch (Exception e) {
            Log.e(TAG,"Error en save al guardar un favorito",e);
        }
        hideKyboard();
        Log.d(TAG,"Se ha guardado el favorito");
    }

    @Override
    public void OnRestaurantSelect(Restaurant r) {
        Log.d(TAG,"Ha entrado en OnRestaurantSelect");
        showFragment(detailRestaurantFrag);
        detailRestaurantFrag.setRestaurant(r);
        Log.d(TAG,"Ha seleccionado el restaurante "+r.getName().toString());
        Log.d(TAG,"Han salido de OnRestaurantSelect");
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

    @Override
    public void onBackPressed() {
        Log.d(TAG,"Ha entrado en onBackPressed");
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(allRestaurantFrag);
        }
        Log.d(TAG,"Ha salido de onBackPressed");

    }
}
