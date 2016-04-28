package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.ds201625.fonda.R;

public class OrdersActivity extends BaseNavigationActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders);
        super.onCreate(savedInstanceState);
    }
    public void cambiarC (View v)
    {
        Intent cambio = new Intent (this,OrdenActualActivity.class);
        startActivity(cambio);
    }
    public void cambiarHist (View v)
    {
        Intent cambio = new Intent (this,ConsultaVisitasActivity.class);
        startActivity(cambio);
    }

    public void cambiarPrueba (View v)
    {
        Intent cambio = new Intent (this,Orders2Activity.class);
        startActivity(cambio);
    }

}
