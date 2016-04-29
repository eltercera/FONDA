package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnChildClickListener;
import android.widget.Toast;

import com.ds201625.fonda.R;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Adri on 13/04/2016.
 */
public class DetailVisitActivity extends BaseNavigationActivity {
    List<String> groupList;
    List<String> childList;
    Map<String, List<String>> coleccionDevisitas;
    ExpandableListView expListView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {

        setContentView(R.layout.activity_detail_visit);
        super.onCreate(savedInstanceState);

    createGroupList();

    createCollection();

    expListView = (ExpandableListView) findViewById(R.id.laptop_list);
    final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
            this, groupList, coleccionDevisitas);
    expListView.setAdapter(expListAdapter);

    //setGroupIndicatorToRight();

    expListView.setOnChildClickListener(new OnChildClickListener() {

        public boolean onChildClick(ExpandableListView parent, View v,
        int groupPosition, int childPosition, long id) {
            final String selected = (String) expListAdapter.getChild(
                    groupPosition, childPosition);
            Toast.makeText(getBaseContext(), selected, Toast.LENGTH_LONG)
                    .show();

            return true;
        }
    });
}

    private void createGroupList() {
        groupList = new ArrayList<String>();
        groupList.add("RESTAURANTE: El tinajero                                12/10/15");
        groupList.add("RESTAURANTE: La Castanuela                              12/10/15");
        groupList.add("RESTAURANTE: Moute Grill                                12/10/15");
        groupList.add("RESTAURANTE: Chino                                      12/10/15");
        groupList.add("RESTAURANTE: Loreto                                     12/10/15");
    }

    private void createCollection() {
        // preparing laptops collection(child)
        String[] data1 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data2 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data3 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data4 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data5 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };


        coleccionDevisitas = new LinkedHashMap<String, List<String>>();

        for (String laptop : groupList) {
            if (laptop.equals("RESTAURANTE: El tinajero                                12/10/15")) {
                loadChild(data1);
            } else if (laptop.equals("RESTAURANTE: La Castanuela                              12/10/15"))
                loadChild(data2);
            else if (laptop.equals("RESTAURANTE: Moute Grill                                12/10/15"))
                loadChild(data3);
            else if (laptop.equals("RESTAURANTE: Chino                                      12/10/15"))
                loadChild(data4);
            else  if (laptop.equals("RESTAURANTE: Loreto                                     12/10/15"))
                loadChild(data5);

            coleccionDevisitas.put(laptop, childList);
        }
    }

    private void loadChild(String[] laptopModels) {
        childList = new ArrayList<String>();
        for (String model : laptopModels)
            childList.add(model);
    }



}
