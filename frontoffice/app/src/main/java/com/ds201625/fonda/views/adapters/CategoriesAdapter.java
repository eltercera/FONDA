package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import java.util.ArrayList;
import java.util.List;

public class CategoriesAdapter extends BaseArrayAdapter<RestaurantCategory> {

    int currentPage;

    public CategoriesAdapter(Context context) {
        super(context, R.layout.fragment_filter,R.id.tvFilter,new ArrayList<RestaurantCategory>());
    }

    @Override
    public View createView(RestaurantCategory item) {
        int currentPage = 0;
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_filter, null, true);
        TextView tvFilter = (TextView) convertView.findViewById(R.id.tvFilter);
        tvFilter.setText(item.getNameCategory());
        update();
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

    public void update() {
        List<RestaurantCategory> restaurants = null;

        try {
            Command comando = FondaCommandFactory.getCategoriesCommand();
            comando.setParameter(0, 10);
            comando.setParameter(1, currentPage + 1);
            comando.run();
            restaurants = (List<RestaurantCategory>)comando.getResult();
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        currentPage++;
        if (restaurants != null) addAll(restaurants);
        notifyDataSetChanged();
    }
}
