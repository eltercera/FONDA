package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.ZoneService;
import com.ds201625.fonda.domains.Zone;
import com.ds201625.fonda.views.activities.FilterZoneList;
import com.ds201625.fonda.views.activities.RestaurantListActivity;
import com.google.gson.Gson;

import java.util.Iterator;
import java.util.List;

/**
 * Created by Valentina on 17/04/2016.
 */
public class ZoneFragment extends BaseFragment {

    /**
     * List view para mostrar en pantalla
     */
    private ListView list;
    /**
     * Servicio de zonas
     */
    private ZoneService zoneService;
    /**
     *Lista que contiene las zonas
     */
    private List<Zone> listZone;
    /**
     * Adaptador para el list view
     */
    private FilterZoneList adapter;
    /**
     * Iterador para recorrer las zonas
     */
    private Iterator iterator;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        View view= inflater.inflate(R.layout.fragment_zone,container,false);
        list=(ListView)view.findViewById(R.id.listViewRestaurants);

        zoneService = FondaServiceFactory.getInstance().getZoneService();
        listZone = zoneService.getZone();
        iterator = listZone.listIterator();

        while (iterator.hasNext()) {
            Zone zone = (Zone) iterator.next();
            //String nameZona = zone.getName();
            //System.out.println("Zona: "+nameZona);
        }
       list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                Intent intent = new Intent (getActivity(),RestaurantListActivity.class);
                Zone _zone = getSelectedZone(position);
                intent.putExtra("zona", new Gson().toJson(_zone));
                startActivity(intent);
            }
        });

        setupListView();
        return view;

    }

    private void setupListView() {
        FilterZoneList adapter = new FilterZoneList(getActivity(), listZone);
        list.setAdapter(adapter);

    }

    /**
     * Metodo para devolver la posicion de cada zona en el list view
     * @param position
     * @return
     */
    private Zone getSelectedZone(int position){
        int counter =0;
        for (Zone zone: this.listZone){
            if (counter == position){
                return zone;
            }
            counter++;
        }
        return null;
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


