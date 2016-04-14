package com.ds201625.fonda.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;

import com.ds201625.fonda.R;

public class OrdersActivity extends BaseActivityNavigation {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders);
        super.onCreate(savedInstanceState);
    }
    public void cambiarP (View v)
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }
    public void cambiarHist (View v)
    {
        Intent cambio = new Intent (this,ConsultaPagoActivity.class);
        startActivity(cambio);
    }
}
