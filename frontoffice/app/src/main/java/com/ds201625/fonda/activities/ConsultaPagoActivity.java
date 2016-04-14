package com.ds201625.fonda.activities;

import android.app.Activity;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.Menu;
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
public class ConsultaPagoActivity extends Activity {
    List<String> groupList;
    List<String> childList;
    Map<String, List<String>> laptopCollection;
    ExpandableListView expListView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_consultarpago);
    createGroupList();

    createCollection();

    expListView = (ExpandableListView) findViewById(R.id.laptop_list);
    final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
            this, groupList, laptopCollection);
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
        groupList.add("12/12/15    5.000 Bs    7.000 Bs");
        groupList.add("12/12/15    5.000 Bs    7.000 Bs");
        groupList.add("16/01/16    5.000 Bs    7.000 Bs");
        groupList.add("02/02/16    5.000 Bs    7.000 Bs");
        groupList.add("03/04/16    5.000 Bs    7.000 Bs");
    }

    private void createCollection() {
        // preparing laptops collection(child)
        String[] data1 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data2 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data3 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data4 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data5 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };


        laptopCollection = new LinkedHashMap<String, List<String>>();

        for (String laptop : groupList) {
            if (laptop.equals("12/12/15    5.000 Bs    7.000 Bs")) {
                loadChild(data1);
            } else if (laptop.equals("12/12/15    5.000 Bs    7.000 Bs"))
                loadChild(data2);
            else if (laptop.equals("16/01/16    5.000 Bs    7.000 Bs"))
                loadChild(data3);
            else if (laptop.equals("02/02/16    5.000 Bs    7.000 Bs"))
                loadChild(data4);
            else  if (laptop.equals("03/04/16    5.000 Bs    7.000 Bs"))
                loadChild(data5);

            laptopCollection.put(laptop, childList);
        }
    }

    private void loadChild(String[] laptopModels) {
        childList = new ArrayList<String>();
        for (String model : laptopModels)
            childList.add(model);
    }

    private void setGroupIndicatorToRight() {
		/* Get the screen width */
        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        int width = dm.widthPixels;

        expListView.setIndicatorBounds(width - getDipsFromPixel(35), width
                - getDipsFromPixel(5));
    }

    // Convert pixel to dip
    public int getDipsFromPixel(float pixels) {
        // Get the screen's density scale
        final float scale = getResources().getDisplayMetrics().density;
        // Convert the dps to pixels, based on density scale
        return (int) (pixels * scale + 0.5f);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //  getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }
}
