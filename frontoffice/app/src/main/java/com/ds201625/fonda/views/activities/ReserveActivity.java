
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

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
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


public class ReserveActivity extends BaseNavigationActivity implements
        ReservationView, ReserveListFragment.reserveListFragmentListener {


    private String TAG = "ReserveActivity";
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
    private ReserveListFragment reserveListFrag;

    private static ReserveListFragment rf;

    /**
     * Boton Flotante
     */
    private FloatingActionButton fab;


    /**
     * Presentador de reservas
     */
    private ReservationViewPresenter presenter;

    /**
     * Solo para prueba de la interface
     */
    private List<Reservation> p;

    private boolean onForm;

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
         //   detailRestaurantFrag = new DetailRestaurantFragment();

        }
        Log.d(TAG,"Ha salido de onCreate");
    }


    /**
     * Acción de saltar esta actividad.
     */
    public void skip() {
        Log.d(TAG,"Ha entrado en skip");
        startActivity(new Intent(this,LoginActivity.class));
        Log.d(TAG,"Ha salido de skip");
    }

    @Override
    public List<Reservation> getListSW() {
        return null;
    }
}

