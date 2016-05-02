package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.Gravity;
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

public class CloseViewItemList extends ArrayAdapter<String> {

    private final Context context;
    private final String[] name;
    private final String[] quantity;
    private final String[] price;

    public CloseViewItemList(Context context,
                             String[] web, String[] quantity , String[] price) {
        super(context, R.layout.item_close, web);
        this.context = context;
        this.name = web;
        this.quantity = quantity;
        this.price = price;

    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
       // LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.item_close, null, true);

        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.txt2);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.txt3);

        txtTitle3.setGravity(Gravity.RIGHT);
        txtTitle2.setGravity(Gravity.CENTER);

        txtTitle2.setText(quantity[position]);
        txtTitle.setText(name[position]);
        txtTitle3.setText(price[position]);
        return rowView;
    }
}