
package com.ds201625.fonda.views.activities;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.views.contracts.ReservationView;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.ReserveEmptyFragment;
import com.ds201625.fonda.views.fragments.ReserveListFragment;


import com.ds201625.fonda.views.contracts.ReservationViewPresenter;
import com.ds201625.fonda.views.presenters.ReservationPresenter;

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
     * Fragmento  vacio
     */
    private static ReserveEmptyFragment reserveEmptyFragment;
    /**
     * Fragmento de Detalle de reserva
     */
 //   private static DetailReservationFragment detailReservationFrag;

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


    private static boolean onForm;
    /**
     * Presentador de Reserva
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
         //   detailRestaurantFrag = new DetailRestaurantFragment();

            //Lanzamiento de ListFrag como el principal
            fm.beginTransaction()
                    .replace(R.id.fragment_container, rf)
                    .commit();


            // Asegura que almenos onCreate se ejecuto en el fragment
            fm.executePendingTransactions();
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

