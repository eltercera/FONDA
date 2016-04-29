package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AlertDialog;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.FacturaFragment;

public class GenerarFacturaActivity extends BaseNavigationActivity {

    /**
     * Iten del Menu para cerrar
     */
    private MenuItem descargaBotton;

    private FacturaFragment facturaAccFrag;

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_g_factura);
        super.onCreate(savedInstanceState);

        facturaAccFrag = new FacturaFragment();

        fm = getSupportFragmentManager();

        //Lanzamiento de closeAccFrag como el principal
        fm.beginTransaction()
                .replace(R.id.fragment_container2,facturaAccFrag)
                .commit();

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();
    }


    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.factura, menu);
        descargaBotton = menu.findItem(R.id.action_favorite_download);

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
            case R.id.action_favorite_download:
                generar();
                break;
        }
        return true;
    }

    private void generar() {
     /*   AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
                "Se puede proceder con el cierre.");
        dialog.show();
     */
        cambiarinicio();
    }


    public void cambiarinicio ()
    {
        Intent cambio = new Intent (this,OrdersActivity.class);
        startActivity(cambio);
    }
}
