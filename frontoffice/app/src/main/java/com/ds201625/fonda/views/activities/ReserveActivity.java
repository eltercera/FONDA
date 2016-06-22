package com.ds201625.fonda.views.activities;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.ReserveListFragment;

import java.util.ArrayList;
import java.util.List;


public class ReserveActivity extends BaseNavigationActivity
{

    /**
     * Item del Menu para guardar
     */
    private MenuItem saveBotton;

    /**
     * Fragment del formulario
     */
   // private ReserveFormFragment reserveFormFrag;

    /**
     * Fragment de la lista
     */
    private ReserveListFragment reserveListFrag;

    /**
     * Boton Flotante
     */
    private FloatingActionButton fab;

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    /**
     * ToolBar
     */
    private Toolbar tb;

    /**
     * Solo para prueba de la interface
     */
    private List<Reservation> p;

    private boolean onForm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_reserve);
        super.onCreate(savedInstanceState);

        // Obtencion de los componentes necesaios de la vista
        fab = (FloatingActionButton)findViewById(R.id.fab);
        tb = (Toolbar)findViewById(R.id.toolbar);
        fm = getSupportFragmentManager();

        // Creacion de fragmen y pase argumento
       // reserveFormFrag = new ReserveFormFragment();
        reserveListFrag = new ReserveListFragment();
        Bundle args = new Bundle();
        args.putBoolean("multiSelect",true);
        reserveListFrag.setArguments(args);

        //Lanzamiento de reserveListFrag como el principal
        fm.beginTransaction()
                .replace(R.id.fragment_container,reserveListFrag)
                .commit();

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
     //           showFragment(reserveFormFrag);
       //         reserveFormFrag.setReserve();
            }
        });
    }
    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(reserveListFrag)){
            if(saveBotton != null)
                saveBotton.setVisible(false);
            fab.setVisibility(View.VISIBLE);
            onForm = false;
        } else {
            onForm = true;
            if(saveBotton != null)
                saveBotton.setVisible(true);
            fab.setVisibility(View.GONE);
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
        getMenuInflater().inflate(R.menu.profile, menu);

        saveBotton = menu.findItem(R.id.action_favorite_save);
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
            case R.id.action_favorite_save:
                save();
                break;
        }
        return true;
    }

    private void save() {
     //   reserveFormFrag.changeProfile();

   //     Reservation reserve = reserveFormFrag.getProfile();
        ProfileService ps = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
       /* try {
            if (reserve.getId() == 0) {
                ps.addProfile(reserve);
            } else {
                ps.editProfile(reserve);
            }
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        reserveListFrag.updateList();
        reserveListFrag.updateList();
        showFragment(reserveListFrag);
        hideKyboard();*/
    }
    /**
     * Implementaciones de comunicacion con los fragments
    // * @param reserve
     */
 /*   @Override
    public void OnProfileSelect(Reservation reserve) {
        showFragment(reserveFormFrag);
        reserveFormFrag.setProfile(reserve);
    }

    @Override
    public void OnProfilesSelected(ArrayList<Reservation> reserve) {

    }*/
/*
    @Override
    public void OnProfileSelectionMode() {
        tb.setVisibility(View.GONE);
        fab.setVisibility(View.GONE);
    }

    @Override
    public void OnProfileSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
        fab.setVisibility(View.VISIBLE);
    }

    @Override
    public void onBackPressed() {
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(reserveListFrag);
        }
    }*/
}

