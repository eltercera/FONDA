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
 * Created by Jessica on 18/4/2016.
 */


public class ReserveList extends ArrayAdapter<String> {

    private final Activity context;
    private final Integer[] picture;
    private final String[] restaurants;
    private final String[] date;
    private final String[] time;
    private final String[] dinners;

    public ReserveList(Activity context,
                       String[] restaurants, String[] date, String[] time, String[] dinners, Integer[] picture) {
        super(context, R.layout.list_reservations, restaurants);
        this.context = context;
        this.restaurants = restaurants;
        this.date = date;
        this.time = time;
        this.dinners = dinners;
        this.picture = picture;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_reservations, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.text);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.text2);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.text3);
        TextView txtTitle4 = (TextView) rowView.findViewById(R.id.text4);

        ImageView imageView = (ImageView) rowView.findViewById(R.id.img);
        txtTitle.setText(restaurants[position]);
        txtTitle2.setText(date[position]);
        txtTitle3.setText(time[position]);
        txtTitle4.setText(dinners[position]);
        imageView.setImageResource(picture[position]);
        return rowView;
    }
}