
package com.ds201625.fonda.views.activities;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetReservationFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.interfaces.ReservationView;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.ReserveListFragment;


import com.ds201625.fonda.interfaces.ReservationViewPresenter;
import com.ds201625.fonda.presenter.ReservationPresenter;

import com.ds201625.fonda.views.fragments.DetailRestaurantFragment;
import com.ds201625.fonda.views.fragments.FavoritesEmptyFragment;
import com.ds201625.fonda.views.fragments.FavoritesListFragment;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity de los Reservas
 */
public class ReserveActivity extends BaseNavigationActivity implements
        ReservationView, ReserveListFragment.reserveListFragmentListener {


    /**
     * Administrador de Fragments
     */
    private static FragmentManager fm;
    /**
     * ToolBar
     */
    private Toolbar tb;

    /**
     * Fragment de la lista
     */
      private static ReserveListFragment rf;

    /**
     * Fragmento favoritos vacio
     */
    private static FavoritesEmptyFragment favoritesEmptyFragment;
    /**
     * Fragmento de Detalle de restaurant
     */
    private static DetailRestaurantFragment detailRestaurantFrag;
    // UI references.
    private Reservation selectedReservation;
    /**
     * String para indicar en que clase se esta en el logger
     */
    private String TAG ="ReserveActivity";
    /**
     * String static para indicar en que clase se esta en el logger
     */
    private static String TAGS ="ReserveActivity";
    /**
     * Iten del Menu para favorito
     */
    private static MenuItem favoriteBotton;
    private static MenuItem reserveBotton;
    /**
     * Variable booleana para determinar el form
     */
    private static boolean onForm;
    /**
     * Presentador de Favoritos
     */
    private ReservationViewPresenter presenter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        setContentView(R.layout.activity_reserve);
        presenter = new ReservationPresenter(this);

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
            rf = new ReserveListFragment();
            detailRestaurantFrag = new DetailRestaurantFragment();

            if(!isEmptyFavorite()) {
                Bundle args = new Bundle();
                args.putBoolean("multiSelect", true);
                rf.setArguments(args);

                //Lanzamiento de favoriteListFrag como el principal
                fm.beginTransaction()
                        .replace(R.id.fragment_container_fav, rf)
                        .commit();

            }else
            {
                //Lanzamiento de favoriteListFrag como el principal
                fm.beginTransaction()
                        .replace(R.id.fragment_container_fav, favoritesEmptyFragment)
                        .commit();
            }
            // Asegura que almenos onCreate se ejecuto en el fragment
            fm.executePendingTransactions();
        }
        Log.d(TAG,"Ha salido de onCreate");
    }


    public boolean isEmptyFavorite() {
        try {
            //Llamo al comando de requireLogedCommensalCommand
            presenter.findLoggedComensal();
            List<Reservation> reservationListList = presenter.AllReservation();

            if (reservationListList != null) {
                if (reservationListList.size() == 0)
                    return true;
            }

        }catch (GetReservationFondaWebApiControllerException e) {
            Toast.makeText(getApplicationContext(),
                    "Ha ocurrido un error al obtener las reservas del WS",
                    Toast.LENGTH_LONG).show();
            Log.e(TAG, "Error Proveniente del WEB SERVICE al obtener las reservas", e);
        }
        catch (Exception e) {
            //  Log.e(TAG,"Error",e);
        }
        return false;
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
     * Al presionar el botón volver
     */
    @Override
    public void onBackPressed() {
        Log.d(TAG,"Ha entrado en onBackPressed");
        if (!onForm) {
            super.onBackPressed();
        } else {

        }
        Log.d(TAG,"Ha salido de onBackPressed");
    }


    @Override
    public List<Reservation> getListSW() {
        return null;
    }
}

