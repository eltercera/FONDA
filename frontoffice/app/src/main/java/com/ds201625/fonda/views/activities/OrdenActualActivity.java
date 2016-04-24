package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;

public class OrdenActualActivity extends BaseNavigationActivity {



    ListView list;
    String[] names = {
            "Pasta Con Salmon",
            "Coca-Cola",
            "Terciopelo Rojo"
            } ;
    String[] tipo = {
            "Pasta",
            "Refresco",
            "Torta"} ;
    String[] precio = {
            "Bs. 1000",
            "Bs. 100",
            "Bs. 500"} ;
    Integer[] imageId = {
            R.drawable.salmonpasta,
            R.drawable.refresco,
            R.drawable.redv2
            };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orden_actual);
        super.onCreate(savedInstanceState);

        OrdenList adapter = new
                OrdenList(OrdenActualActivity.this,tipo,names,precio,imageId);
        list=(ListView)findViewById(R.id.lVOrden);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                Toast.makeText(OrdenActualActivity.this, "You Clicked at " + names[+position], Toast.LENGTH_SHORT).show();

            }
        });
    }
    public void cambiarCC (View v)
    {
        Intent cambio = new Intent (this,CierreCuentaActivity.class);
        startActivity(cambio);
    }
  }
