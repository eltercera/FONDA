package com.ds201625.fonda.activities;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ds201625.fonda.R;

public class RestauranstsActivity extends BaseActivityNavigation {
    //Se define la lista
    ListView listaFiltros;

    //Se define dentro de la lista lis items
    String[] filtros ={
            "Tipo de Comida",
            "Zona",
            "Costo",
            "Horario",
            "Cercanos a Mi"

    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        listaFiltros = (ListView) findViewById(R.id.listaFiltros); //Asignas el listview del content a la variable listview
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_expandable_list_item_1, filtros); //crear un adaptador para pasarlo a la lista. entorno,tipo de item que pasas, lista creada
        listaFiltros.setAdapter(adapter);

        listaFiltros.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

            }
        });

    }
}
