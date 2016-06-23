package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.ds201625.fonda.R;


public class FilterCostList extends ArrayAdapter<String> {

    private final Activity context;
    private final String[] name;

    public FilterCostList(Activity context,
                          String[] web) {
        super(context, R.layout.filter_list, web);
        this.context = context;
        this.name = web;

    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_restaurant_filter, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);

        txtTitle.setText(name[position]);

        return rowView;
    }
}