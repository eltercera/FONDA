package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.FrameLayout;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.CurrentOrderFragment;
import com.ds201625.fonda.views.fragments.FacturaFragment;
import com.ds201625.fonda.views.fragments.HistoryVisitFragment;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.OrderPaymentFragment;

public class OrdersActivity extends BaseNavigationActivity {

    /**
     * Iten del Menu
     */
    private MenuItem cerrarBotton;
    private MenuItem sendBotton;
    private MenuItem cancelBotton;
    private MenuItem buscarBotton;
    private MenuItem sendPayBotton;
    private MenuItem cancelPayBotton;
    private MenuItem downloadBotton;

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

    private TabLayout tb;

    private FrameLayout prueba;

    private CloseAccountFragment prueba2;

    private OrderPaymentFragment ordPay;

    private FacturaFragment factFrag;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders);
        super.onCreate(savedInstanceState);


        //Importante Primero obtener el Tablayout
        tb = (TabLayout) findViewById(R.id.tabsO);

        prueba = (FrameLayout) findViewById(R.id.fragment_container2);

        //Inyectarlo al BaseSectionsPagerAdapter
        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager(),tb);

        mViewPager = (ViewPager) findViewById(R.id.containerO);
        mViewPager.setAdapter(mSectionsPagerAdapter);
        tb.setupWithViewPager(mViewPager);

        orderListFrag = new CurrentOrderFragment();


        //Tab con solo un String como titulo
        mSectionsPagerAdapter.addFragment("Orden Actual",orderListFrag);
        mSectionsPagerAdapter.addFragment("Historial de Visitas",new HistoryVisitFragment());

        //Importante ejecutar esto para que se creen los iconos en el tab.
        mSectionsPagerAdapter.iconsSetup();

        fm = getSupportFragmentManager();

    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.orders, menu);
        cerrarBotton = menu.findItem(R.id.close);
        sendBotton = menu.findItem(R.id.action_favorite_send);
        cancelBotton = menu.findItem(R.id.action_favorite_cancel);
        buscarBotton = menu.findItem(R.id.action_favorite_search);
        sendPayBotton = menu.findItem(R.id.action_favorite_send_pay);
        cancelPayBotton = menu.findItem(R.id.action_favorite_cancel_pay);
        downloadBotton = menu.findItem(R.id.action_favorite_download);
        return true;
    }

    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container2,fragment)
                .commit();
        fm.executePendingTransactions();
        tb.setVisibility(View.GONE);

        //Muestra y oculta compnentes.
        if(fragment.equals(orderListFrag)){
            if(cerrarBotton != null)
                cerrarBotton.setVisible(true);
        }
        else if(fragment.equals(prueba2)) {
            if(cerrarBotton != null)
                cerrarBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)){
                sendBotton.setVisible(true);
                cancelBotton.setVisible(true);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
        }
        else if (fragment.equals(ordPay)) {
                if (cerrarBotton != null)
                    cerrarBotton.setVisible(false);
                if ((sendBotton != null) && (cancelBotton != null)) {
                    sendBotton.setVisible(false);
                    cancelBotton.setVisible(false);
                }
                if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                    sendPayBotton.setVisible(true);
                    cancelPayBotton.setVisible(true);
                }
            }
        else if (fragment.equals(factFrag)) {
            if (cerrarBotton != null)
                cerrarBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(false);
                cancelBotton.setVisible(false);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
            if (downloadBotton != null)
                downloadBotton.setVisible(true);
        } else {
            if (downloadBotton != null)
                downloadBotton.setVisible(false);
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
            case R.id.action_favorite_search:
                buscar();
                break;
            case R.id.action_favorite_send:
                cambiarPa();
                break;
            case R.id.action_favorite_cancel:
                salir();
                break;
            case R.id.action_favorite_send_pay:
                cambiarFac();
                break;
            case R.id.action_favorite_cancel_pay:
                cambiarCC();
                break;
            case R.id.action_favorite_download:
                download();
                break;
        }
        return true;
    }

    private void cerrar() {
     /*   AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
                "Se puede proceder con el cierre.");
        dialog.show();
    */
        cambiarCC();
    }

    public void cambiarCC ()
    {

        if (prueba2 == null)
            prueba2 = new CloseAccountFragment();
        showFragment(prueba2);
    }

    private void salir() {

        Intent cambio = new Intent (this,OrdersActivity.class);
        startActivity(cambio);
    }

    public void cambiarPa ()
    {
        if (ordPay == null)
            ordPay = new OrderPaymentFragment();
         showFragment(ordPay);
    }

    private void buscar() {

        //Metodo para el boton de buscar
    }

    public void cambiarFac ()
    {
        if (factFrag == null)
            factFrag = new FacturaFragment();
        showFragment(factFrag);
    }

    public void download ()
    {
        salir();
    }
}
