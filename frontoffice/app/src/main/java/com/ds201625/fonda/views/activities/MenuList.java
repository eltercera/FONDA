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
 * Created by Jessica on 11/5/2016.
 */
public class MenuList extends ArrayAdapter<String> {

    private final Activity context;
    private final Integer[] picture;
    private final String[] category;
    private final String[] plate;
    private final String[] information;
    private final String[] price;


    public MenuList (Activity context,
                       String[] category, String[] plate, String[] information, String[] price, Integer[] picture) {
        super(context, R.layout.list_menu, plate);
        this.context = context;
        this.category = category;
        this.plate = plate;
        this.information = information;
        this.price = price;
        this.picture = picture;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_menu, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.text);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.text2);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.text3);
        TextView txtTitle4 = (TextView) rowView.findViewById(R.id.text4);

        ImageView imageView = (ImageView) rowView.findViewById(R.id.img);
        txtTitle.setText(category[position]);
        txtTitle2.setText(plate[position]);
        txtTitle3.setText(information[position]);
        txtTitle4.setText(price[position]);
        imageView.setImageResource(picture[position]);
        return rowView;
    }
}