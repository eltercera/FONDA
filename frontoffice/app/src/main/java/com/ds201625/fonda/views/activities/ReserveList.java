package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.entities.Reservation;

import java.util.List;

/**
 * Created by Jessica on 18/4/2016.
 */


public class ReserveList extends ArrayAdapter<Reservation> {

    private final Activity context;
    private final Integer[] picture;
    private final String[] date;
    private final String[] dinners;
    private final String[] name;
    private final List<Reservation> mReserveList;

    public ReserveList(Activity context,
                       String[] web, String[] date, String[] dinners, Integer[] picture, List<Reservation> reserveList) {
        super(context, R.layout.list_reservations, reserveList);
        this.context = context;
        this.name = web;
        this.date = date;
        this.dinners = dinners;
        this.picture = picture;
        this.mReserveList = reserveList;

    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_reservations, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.text);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.text2);
        // TextView txtTitle3 = (TextView) rowView.findViewById(R.id.text3);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.text3);

        int contador = 0;

        for (Reservation reservation: this.mReserveList){
            if (contador == position){
                txtTitle.setText(reservation.getRestaurant().getName());
                txtTitle2.setText(reservation.getRestaurant().getName());
            }
            contador ++;
        }

        try{
            ImageView imageView = (ImageView) rowView.findViewById(R.id.img);
            // txtTitle.setText(restaurants[position]);
            // txtTitle2.setText(date[position]);
            txtTitle3.setText(dinners[position]);
            imageView.setImageResource(picture[position]);
        }catch(ArrayIndexOutOfBoundsException e){

        }
        return rowView;
    }
}