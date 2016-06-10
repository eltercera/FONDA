package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;

import java.util.ArrayList;
import java.util.List;

/**
 * Adapter para la vista de la lista de Profiles
 */
public class FavoriteRestViewItemList extends BaseArrayAdapter<Restaurant> {


    public FavoriteRestViewItemList(Context context) {
        super(context, R.layout.list_restaurant,R.id.txt,new ArrayList<Restaurant>());

    }

    public void update(int id) {
        FavoriteRestaurantService ps = FondaServiceFactory.getInstance()
                .getFavoriteRestaurantService();
        List<Restaurant> list = null;
        clear();
        list = ps.getAllFavoriteRestaurant(id);
        if (list != null)
            addAll(list);
        notifyDataSetChanged();
    }

    @Override
    public View createView(Restaurant item) {

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_restaurant, null, true);

        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.txt2);
        TextView txtTitle3 = (TextView) rowView.findViewById(R.id.txt3);
        ImageView icon = (ImageView) rowView.findViewById(R.id.imageRest);


            txtTitle.setText(item.getName());
            txtTitle2.setText(item.getAddress());
            txtTitle3.setText(item.getRestaurantCategory().getNameCategory());
            String image = item.getLogo();
            Context context = icon.getContext();
            int idImage = context.getResources().getIdentifier(image, "drawable", context.getPackageName());
            icon.setImageResource(idImage);

        return rowView;

    }



    @Override
    public View getSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.colorPrimaryDark));
        return convertView;
    }

    @Override
    public View getNotSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }


}
