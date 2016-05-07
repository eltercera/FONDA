package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

import com.ds201625.fonda.R;

public class RegistrarTdcActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registrar_tdc);
    }
    public void cambiarP (View v)
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }




}

