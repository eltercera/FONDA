package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.activities.FavoritesActivity;
import com.ds201625.fonda.views.activities.RestaurantListActivity;

/**
 * Created by Valentina on 17/04/2016.
 */
public class TimeFragment extends BaseFragment {

    private ImageView imgMorning;
    private ImageView imgAfternoon;
    private ImageView imgNight;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View view= inflater.inflate(R.layout.fragment_time,container,false);

        imgMorning = (ImageView) view.findViewById(R.id.img_morning);
        imgMorning.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent= new Intent(getActivity(),RestaurantListActivity.class);
                startActivity(intent);
            }
        });

        imgAfternoon = (ImageView) view.findViewById(R.id.img_afternoon);
        imgAfternoon.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent= new Intent(getActivity(),RestaurantListActivity.class);
                startActivity(intent);
            }
        });

        imgNight = (ImageView) view.findViewById(R.id.img_night);
        imgNight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent= new Intent(getActivity(),RestaurantListActivity.class);
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


