package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.ExpandableListAdapter;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class HistoryVisitFragment extends BaseFragment {
    List<String> groupList;
    List<String> childList;
    Map<String, List<String>> collectionVisits;
    ExpandableListView expListView;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) { createGroupList();
      View layout =  (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        expListView = (ExpandableListView) layout.findViewById(R.id.restaurant_list);
        final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(), groupList,collectionVisits, names, shortDescription,location, dates);
        expListView.setAdapter(expListAdapter);

        //setGroupIndicatorToRight();

        expListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {
                final String selected = (String) expListAdapter.getChild(
                        groupPosition, childPosition);
                Toast.makeText(getContext(), selected, Toast.LENGTH_LONG)
                        .show();

                return true;
            }
        });
        return layout;

    }
    String[] dates ={
            "12/01/16",
            "12/01/16",
            "12/01/16",
            "12/01/16",
            "12/01/16"};
    String[]  names = {
            "The dining room",
            "Mogi Mirin",
            "Gordo & Magro",
            "La Casona",
            "Tony's"} ;
    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;
    String[] shortDescription = {
            "Casual",
            "Romantico",
            "Italiano",
            "Italiano",
            "Americano"} ;

    private void createGroupList() {
       groupList = new ArrayList<String>();

            for (String model : names)
                groupList.add(model);
        }

    private void createCollection() {
        // preparing laptops collection(child)
        String[] data1 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data2 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data3 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data4 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        String[] data5 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };


        collectionVisits = new LinkedHashMap<String, List<String>>();

        for (String listName : groupList) {
            if (listName.equals("The dining room")) {
                loadChild(data1);
            } else if (listName.equals("Mogi Mirin"))
                loadChild(data2);
            else if (listName.equals("Gordo & Magro"))
                loadChild(data3);
            else if (listName.equals("La Casona"))
                loadChild(data4);
            else  if (listName.equals("Tony's"))
                loadChild(data5);

            collectionVisits.put(listName, childList);
        }
    }

    private void loadChild(String[] restaurantDetails) {
        childList = new ArrayList<String>();
        for (String model : restaurantDetails)
            childList.add(model);
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }

}
