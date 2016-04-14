package com.ds201625.fonda.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

import com.ds201625.fonda.R;

public class CerrarCuentaActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cerra_cuenta);
    }

    public void cambiarP (View v)
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }
}
