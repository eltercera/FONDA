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
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.activities.AllRestaurantActivity;
import com.ds201625.fonda.views.activities.FilterList;

/**
 * Created by Valentina on 17/04/2016.
 */
public class FoodFragment extends BaseFragment {

    private ListView list;

    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View view= inflater.inflate(R.layout.fragment_food,container,false);

        FilterList adapter = new
                FilterList(getActivity(),location);
        list=(ListView)view.findViewById(R.id.listViewRestaurants);
        list.setAdapter(adapter);

        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                Toast.makeText(getActivity(), "You Clicked at " + location[+position], Toast.LENGTH_SHORT).show();
                Intent intent = new Intent (getActivity(),AllRestaurantActivity.class);
                startActivity(intent);
            }
        });

        return view;

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


