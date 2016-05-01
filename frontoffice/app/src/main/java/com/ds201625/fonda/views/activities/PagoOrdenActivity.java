package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.OrderPaymentFragment;

public class PagoOrdenActivity extends BaseNavigationActivity {

    private OrderPaymentFragment opfrag;

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    private MenuItem sendBotton;
    private MenuItem cancelBotton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_pago_orden);
        super.onCreate(savedInstanceState);
        opfrag = new OrderPaymentFragment();
        fm = getSupportFragmentManager();

        //Lanzamiento de opfrag como el principal
        fm.beginTransaction()
                .replace(R.id.fragment_container2,opfrag)
                .commit();

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();

    }


    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.close2, menu);
        sendBotton = menu.findItem(R.id.action_favorite_send);
        cancelBotton = menu.findItem(R.id.action_favorite_cancel);
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
            case R.id.action_favorite_send:
                pagar();
                break;
            case R.id.action_favorite_cancel:
                cancelar();
                break;
        }
        return true;
    }

    private void pagar() {
        //  AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
        //         "Se puede proceder con el cierre.");
        //  dialog.show();

        cambiarFac();
    }


    private void cancelar() {
        //  AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
        //         "Se puede proceder con el cierre.");
        //  dialog.show();

        cambiarOrden ();
    }

    public void cambiarFac ()
    {
        Intent cambio = new Intent (this,GenerarFacturaActivity.class);
        startActivity(cambio);
    }

    public void cambiarOrden ()
    {
        //Intent cambio = new Intent (this,CierreCuentaActivity.class);
       // startActivity(cambio);
    }

    /*public void suma(View v) {
        int m=2000;
        propina = (EditText)findViewById(R.id.eT_propina);
        total = (TextView)findViewById(R.id.tV_ultimo);
        int a= Integer.parseInt(propina.getText().toString());
        int z=a+m;
        total.setText(String.valueOf(z));
    }

    public void cambiarTdc (View v)
    {
        Intent cambio = new Intent (this,RegistrarTdcActivity.class);
        startActivity(cambio);
    }
    public void cambiarFactura (View v)
    {
        Intent cambio = new Intent (this,GenerarFacturaActivity.class);
        startActivity(cambio);
    }*/
}
