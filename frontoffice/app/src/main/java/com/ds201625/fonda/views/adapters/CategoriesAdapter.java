package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.RestaurantCategory;
import java.util.ArrayList;

public class CategoriesAdapter extends BaseArrayAdapter<RestaurantCategory> {

    public CategoriesAdapter(Context context) {
        super(context, R.layout.fragment_filter,R.id.tvFilter,new ArrayList<RestaurantCategory>());
    }

    @Override
    public View createView(RestaurantCategory item) {
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_filter, null, true);
        TextView tvFilter = (TextView) convertView.findViewById(R.id.tvFilter);
        tvFilter.setText(item.getNameCategory());
        return convertView;
    }

    @Override
    public View getSelectedView(RestaurantCategory item, View convertView) {
        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.creme));
        return convertView;
    }

    @Override
    public View getNotSelectedView(RestaurantCategory item, View convertView) {
        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

}
