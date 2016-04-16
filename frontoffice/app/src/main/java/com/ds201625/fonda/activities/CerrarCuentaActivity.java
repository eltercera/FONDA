package com.ds201625.fonda.activities;

import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import com.ds201625.fonda.R;
import android.content.Intent;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.view.View;

public class CerrarCuentaActivity extends AppCompatActivity {

    private String[] comidas = { "1       Plato 1         Bs. 1000", "1       Refresco         Bs. 100",
            "1       Torta         Bs. 500"};

    private ListView lv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_cerra_cuenta);
        super.onCreate(savedInstanceState);

        lv1 =(ListView)findViewById(R.id.listView2);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, comidas);
        lv1.setAdapter(adapter);
    }

    public void cambiarP (View v)
    {
        Intent cambio = new Intent (this,PagoOrdenActivity.class);
        startActivity(cambio);
    }
}
