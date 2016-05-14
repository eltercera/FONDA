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
import android.widget.RadioButton;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.CreditCardFragment;
import com.ds201625.fonda.views.fragments.CurrentOrderFragment;
import com.ds201625.fonda.views.fragments.FacturaFragment;
import com.ds201625.fonda.views.fragments.HistoryVisitFragment;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.OrderPaymentFragment;
import com.ds201625.fonda.domains.Dish;

import java.util.ArrayList;

public class OrdersActivity extends BaseNavigationActivity {

    /**
     * Iten del Menu
     */
    private static MenuItem cerrarBotton;
    private static MenuItem sendBotton;
    private static MenuItem cancelBotton;
    private static MenuItem buscarBotton;
    private static MenuItem sendPayBotton;
    private static MenuItem cancelPayBotton;
    private static MenuItem downloadBotton;
    private static MenuItem saveCCButton;
    /**
     * Fragment de la lista
     */
    private static CurrentOrderFragment orderListFrag;

    /**
     * Boton Flotante
     */
    // private FloatingActionButton fab;

    /**
     * Administrador de Fragments
     */
    private static FragmentManager fm;

    /**
     * ToolBarr
     */
    // private Toolbar tb;

    private BaseSectionsPagerAdapter mSectionsPagerAdapter;

    private ViewPager mViewPager;

    private static TabLayout tb;

    private FrameLayout prueba;

    private static CloseAccountFragment prueba2;

    private static OrderPaymentFragment ordPay;

    private static FacturaFragment factFrag;

    private static CreditCardFragment ccFrag;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders);
        super.onCreate(savedInstanceState);

        //Importante Primero obtener el Tablayout
        tb = (TabLayout) findViewById(R.id.tabsO);

        prueba = (FrameLayout) findViewById(R.id.fragment_container2);

        //Inyectarlo al BaseSectionsPagerAdapter
        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager(), tb);

        mViewPager = (ViewPager) findViewById(R.id.containerO);
        mViewPager.setAdapter(mSectionsPagerAdapter);
        tb.setupWithViewPager(mViewPager);

        orderListFrag = new CurrentOrderFragment();

        //Tab con solo un String como titulo
        mSectionsPagerAdapter.addFragment("Orden Actual", orderListFrag);
        mSectionsPagerAdapter.addFragment("Historial de Visitas", new HistoryVisitFragment());

        //Importante ejecutar esto para que se creen los iconos en el tab.
        mSectionsPagerAdapter.iconsSetup();

        fm = getSupportFragmentManager();

    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     *
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
        saveCCButton = menu.findItem(R.id.action_favorite_save);
        return true;
    }

    /**
     * Realiza el intercambio de vistas de fragments
     *
     * @param fragment el fragment que se quiere mostrar
     */
    public static void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container2, fragment)
                .commit();
        fm.executePendingTransactions();
        tb.setVisibility(View.GONE);

        //Muestra y oculta compnentes.
        if (fragment.equals(orderListFrag)) {
            if (cerrarBotton != null)
                cerrarBotton.setVisible(true);
        } else if (fragment.equals(prueba2)) {
            if (cerrarBotton != null)
                cerrarBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(true);
                cancelBotton.setVisible(true);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
            if (saveCCButton != null)
                saveCCButton.setVisible(false);
        } else if (fragment.equals(ordPay)) {
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
            if (saveCCButton != null)
                saveCCButton.setVisible(false);
        } else if (fragment.equals(ccFrag)) {
            System.out.println("ENTROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
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
            if (saveCCButton != null)
                saveCCButton.setVisible(true);
        } else if (fragment.equals(factFrag)) {
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
            if (saveCCButton != null)
                saveCCButton.setVisible(false);
            if (downloadBotton != null)
                downloadBotton.setVisible(true);
        } else {
            if (downloadBotton != null)
                downloadBotton.setVisible(false);
        }
    }

    /**
     * Opciones y acciones del menu en el toolbars
     *
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
            case R.id.action_favorite_save:
                save();
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

    public void cambiarCC() {

        if (prueba2 == null)
            prueba2 = new CloseAccountFragment();
        showFragment(prueba2);
    }

    private void salir() {

        Intent cambio = new Intent(this, OrdersActivity.class);
        startActivity(cambio);
    }

    public void cambiarPa() {
        if (ordPay == null)
            ordPay = new OrderPaymentFragment();
        showFragment(ordPay);
    }

    private void save() {
        ccFrag = new CreditCardFragment();
        Toast.makeText(this, "Guardar bebe ", Toast.LENGTH_SHORT).show();
    }

    private void buscar() {

        //Metodo para el boton de buscar
    }

    public void cambiarFac() {
        if (factFrag == null)
            factFrag = new FacturaFragment();
        showFragment(factFrag);
    }

    public void download() {
        salir();
    }


    public void onRadioButtonClicked(View view) {
        // Is the button now checked?
        String typeOfCC = null;
        boolean checked = ((RadioButton) view).isChecked();

        // Check which radio button was clicked
        switch (view.getId()) {
            case R.id.rBVisa:
                if (checked)
                    typeOfCC = "Visa";
                Toast.makeText(this, "Tipo de tarjeta " + typeOfCC, Toast.LENGTH_SHORT).show();
                break;
            case R.id.rBMaster:
                if (checked)
                    typeOfCC = "MasterCard";
                Toast.makeText(this, "Tipo de tarjeta " + typeOfCC, Toast.LENGTH_SHORT).show();
                break;
        }
    }

}