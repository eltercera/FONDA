package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
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
    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,LoginActivity.class));
    }


    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container_rest,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(allRestaurantFrag)){
            if(favoriteBotton != null)
                favoriteBotton.setVisible(false);
            if(reserveBotton != null)
                reserveBotton.setVisible(false);
            onForm = false;
        } else {
            if(favoriteBotton != null)
                favoriteBotton.setVisible(true);

            onForm = true;

        }
    }


    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);

        favoriteBotton = menu.findItem(R.id.action_set_favorite);
        reserveBotton = menu.findItem(R.id.action_make_order);
        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_set_favorite:
                save();
                break;
            case R.id.action_make_order:
                goReserve();
                break;
        }
        return true;
    }

    private void goReserve() {
        Intent r = new Intent(this,ReserveActivity.class);
        startActivity(r);
    }

    private void save() {
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
                cmdAddFavorite.setParameter(0,logedComensal.getId());
                cmdAddFavorite.setParameter(1,restaurant.getId());
                cmdAddFavorite.run();

                Toast.makeText(getApplicationContext(), R.string.favorite_add_success_meessage,
                        Toast.LENGTH_LONG).show();
            } catch (RestClientException e) {
                e.printStackTrace();
            }
            catch (NullPointerException nu) {
                nu.printStackTrace();
            }
        } catch (Exception e) {
            System.out.println("Error en la Conexión");
        }
        hideKyboard();
    }

    @Override
    public void OnRestaurantSelect(Restaurant r) {
        showFragment(detailRestaurantFrag);
        detailRestaurantFrag.setRestaurant(r);
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
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(allRestaurantFrag);
        }
    }
}
