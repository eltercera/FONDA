package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.CurrentOrderFragment;
import com.ds201625.fonda.views.fragments.HistorialVisitasFragment;
import com.ds201625.fonda.views.fragments.ProfileListFragment;

/**
 * Actividad de prueba Orden para mostrar el uso de los Tabs.
 */
public class Orders2Activity extends BaseNavigationActivity {

    /**
     * Iten del Menu para cerrar
     */
    private MenuItem cerrarBotton;


    /**
     * Fragment de la lista
     */
    private CurrentOrderFragment orderListFrag;

    /**
     * Boton Flotante
     */
   // private FloatingActionButton fab;

    /**
     * Administrador de Fragments
     */
     private FragmentManager fm;

    /**
     * ToolBarr
     */
   // private Toolbar tb;

    private BaseSectionsPagerAdapter mSectionsPagerAdapter;

    private ViewPager mViewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders2);
        super.onCreate(savedInstanceState);

        //Importante Primero obtener el Tablayout
        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs2);
        //Inyectarlo al BaseSectionsPagerAdapter
        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager(),tabLayout);

        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);
        tabLayout.setupWithViewPager(mViewPager);

        orderListFrag = new CurrentOrderFragment();


       //Tab con solo un String como titulo
        mSectionsPagerAdapter.addFragment("Orden Actual",orderListFrag);
        mSectionsPagerAdapter.addFragment("Historial de Visitas",new HistorialVisitasFragment());
       // mSectionsPagerAdapter.addFragment("Cerrar Cuenta",closeAccFrag);
        //Importante ejecutar esto para que se creen los iconos en el tab.
        mSectionsPagerAdapter.iconsSetup();


    }


    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
     @Override
   public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.close, menu);
        cerrarBotton = menu.findItem(R.id.close);

        return true;
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
        if(fragment.equals(orderListFrag)){
            if(cerrarBotton != null)
                cerrarBotton.setVisible(false);
           // fab.setVisibility(View.VISIBLE);
          //  profileListFrag.seProfiles(p);
        } else {
            if(cerrarBotton != null)
                cerrarBotton.setVisible(true);
          //  fab.setVisibility(View.GONE);
        }

    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.close:
                cerrar();
                break;
        }
        return true;
    }

    private void cerrar() {
        AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
                "Se puede proceder con el cierre.");
        dialog.show();

        cambiarCC();
    }

    public void cambiarCC ()
    {
        Intent cambio = new Intent (this,CierreCuentaActivity.class);
        startActivity(cambio);
    }

}
