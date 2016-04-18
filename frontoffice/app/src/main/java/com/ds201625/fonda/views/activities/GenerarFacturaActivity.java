package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.ds201625.fonda.R;

public class GenerarFacturaActivity extends BaseNavigationActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_g_factura);
        super.onCreate(savedInstanceState);
    }

    public void cambiarinicio (View v)
    {
        Intent cambio = new Intent (this,OrdersActivity.class);
        startActivity(cambio);
    }
}
