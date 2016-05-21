package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by jesus on 13/04/16.
 */

public class RestaurantList extends ArrayAdapter<Restaurant> {

    private final Activity context;
    private final String[] name;
    private final Integer[] imageId;
    private final String[] location;
    private final String[] shortDescription;
    private final List<Restaurant> mRestaurantList;

    public RestaurantList(Activity context,
                                  String[] web,String[] location , String[] shortDescription,Integer[] imageId, List<Restaurant> restaurantList) {
        super(context, R.layout.list_restaurant, restaurantList);
        this.context = context;
        this.name = web;
        this.imageId = imageId;
        this.location = location;
        this.shortDescription = shortDescription;
        this.mRestaurantList = restaurantList;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_restaurant, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.txt2);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.txt3);

        int contador = 0;


        for (Restaurant restaurante: this.mRestaurantList){
            if (contador == position){
                txtTitle.setText(restaurante.getName());
                txtTitle2.setText(restaurante.getName());

                //   Log.v("WEBSERVICEList", restaurante.getId() + "");
                // Log.v("WEBSERVICEList",restaurante.getName());
                //Log.v("WEBSERVICEList",restaurante.getAddress());
            }
            contador++;
        }

        try {
            ImageView imageView = (ImageView) rowView.findViewById(R.id.img);
            txtTitle3.setText(shortDescription[position]);
            imageView.setImageResource(imageId[position]);
        }catch (ArrayIndexOutOfBoundsException e){
            //e.printStackTrace();
        }
        return rowView;

    }
}