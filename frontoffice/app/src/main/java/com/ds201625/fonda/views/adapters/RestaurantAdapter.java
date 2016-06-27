package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;

import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;

/**
 * Adactador para lista de restaurantes
 */
public class RestaurantAdapter extends BaseArrayAdapter<Restaurant> {


    public RestaurantAdapter(Context context) {
        super(context, R.layout.list_restaurant,R.id.txt,new ArrayList<Restaurant>());
    }

    /**
     * Creacion de la vusta de in iten de restaurante
     * @param item elemento a construir la vista
     * @return vista contruida
     */
    @Override
    public View createView(Restaurant item) {
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_restaurant, null, true);

        TextView txtName = (TextView) convertView.findViewById(R.id.txt);
        TextView txtAdd = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtCategory = (TextView) convertView.findViewById(R.id.txt3);
        ImageView icon = (ImageView) convertView.findViewById(R.id.imageRest);
        ImageView favIcon = (ImageView) convertView.findViewById(R.id.fav);
        if (item.getFavorite())
            favIcon.setVisibility(View.VISIBLE);
        else
            favIcon.setVisibility(View.GONE);

        txtName.setText(item.getName());
        txtAdd.setText(item.getAddress());
        txtCategory.setText(item.getRestaurantCategory().getName());
        String path = item.getLogo();
        Drawable image = loadImageFromWebOperations(path);
        if (image == null)
            icon.setImageResource(R.mipmap.ic_launcher);
        else
            icon.setImageDrawable(image);
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

    public Drawable loadImageFromWebOperations(String url) {
        try {
            InputStream is = (InputStream) new URL(url).getContent();
            Drawable d = Drawable.createFromStream(is, "logo");
            return d;
        } catch (Exception e) {
            return null;
        }
    }
}
