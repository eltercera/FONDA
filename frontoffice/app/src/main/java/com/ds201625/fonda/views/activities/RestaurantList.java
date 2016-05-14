package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;

/**
 * Created by jesus on 13/04/16.
 */

public class RestaurantList extends ArrayAdapter<String> {

    private final Activity context;
    private final String[] name;
    private final Integer[] imageId;
    private final String[] location;
    private final String[] shortDescription;

    public RestaurantList(Activity context,
                          String[] web, String[] location , String[] shortDescription, Integer[] imageId) {
        super(context, R.layout.list_favorite_restaurant, web);
        this.context = context;
        this.name = web;
        this.imageId = imageId;
        this.location = location;
        this.shortDescription = shortDescription;

    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_favorite_restaurant, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.txt2);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.txt3);


        ImageView imageView = (ImageView) rowView.findViewById(R.id.img);
        txtTitle.setText(name[position]);
        txtTitle2.setText(location[position]);
        txtTitle3.setText(shortDescription[position]);
        imageView.setImageResource(imageId[position]);
        return rowView;
    }
}