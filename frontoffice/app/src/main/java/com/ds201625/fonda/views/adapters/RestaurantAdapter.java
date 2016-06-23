package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.app.ListFragment;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by gbsoj on 6/22/2016.
 */
public class RestaurantAdapter extends BaseArrayAdapter<Restaurant> {
    int currentPage;


    public RestaurantAdapter(Context context) {
            super(context, R.layout.list_restaurant,R.id.txt,new ArrayList<Restaurant>());
    }

    @Override
    public View createView(Restaurant item) {
        currentPage = 0;
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_restaurant, null, true);

        TextView txtName = (TextView) convertView.findViewById(R.id.txt);
        TextView txtAdd = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtCategory = (TextView) convertView.findViewById(R.id.txt3);
        ImageView icon = (ImageView) convertView.findViewById(R.id.imageRest);


        txtName.setText(item.getName());
        txtAdd.setText(item.getAddress());
        txtCategory.setText(item.getRestaurantCategory().getName());
        String image = item.getLogo();
        Context context = icon.getContext();
        int idImage = context.getResources().getIdentifier(image, "mipmap", context.getPackageName());
        icon.setImageResource(idImage);

        return convertView;

    }

    /**
     * Obtiene la vista seleccionada
     * @param item item seleccionado
     * @param convertView vista ya creada
     * @return
     */
    @Override
    public View getSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.creme));
        return convertView;
    }

    @Override
    public View getNotSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    public void update() {
        List<Restaurant> restaurants = null;

        try {
            Command comando = FondaCommandFactory.getCategoriesCommand();

            comando.setParameter(1, 10);
            comando.setParameter(2, currentPage + 1);
            comando.run();
            restaurants = (List<Restaurant>)comando.getResult();
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        currentPage++;
        if (restaurants != null) addAll(restaurants);
        notifyDataSetChanged();
    }
}
