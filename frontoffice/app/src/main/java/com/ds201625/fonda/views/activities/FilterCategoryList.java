package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.RestaurantCategory;

import java.util.List;


public class FilterCategoryList extends ArrayAdapter<RestaurantCategory> {

    private final Activity context;
    private final List<RestaurantCategory> listCategory;

    public FilterCategoryList(Activity context,
                              List<RestaurantCategory> _listCategory) {
        super(context, R.layout.filter_list, _listCategory);
        this.context = context;
        this.listCategory = _listCategory;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_restaurant_filter, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);

        int counter = 0;

        for (RestaurantCategory restaurantCategory: this.listCategory){
            if (counter == position){
                txtTitle.setText(restaurantCategory.getNameCategory());
            }
            counter++;
        }
        return rowView;
    }
}