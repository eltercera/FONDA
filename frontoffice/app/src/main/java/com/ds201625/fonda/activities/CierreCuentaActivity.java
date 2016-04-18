package com.ds201625.fonda.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ds201625.fonda.R;

public class CierreCuentaActivity extends BaseNavigationActivity {

    private String[] comidas = { "      1       Plato 1         Bs. 1000", "        1       Refresco         Bs. 100",
            "       1       Torta         Bs. 500"};

    private ListView lv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_cierre_cuenta);
        super.onCreate(savedInstanceState);

        lv1 =(ListView)findViewById(R.id.lVOrden);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, comidas);
        lv1.setAdapter(adapter);
    }

    public void cambiarPa (View v)
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }
}
