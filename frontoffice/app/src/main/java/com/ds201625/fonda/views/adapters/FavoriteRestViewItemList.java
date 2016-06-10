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
        try {
            list = ps.getAllFavoriteRestaurant(id);
        } catch (RestClientException e) {
            e.printStackTrace();
            Log.v("Fonda",e.toString());
        }
        if (list != null)
            addAll(list);
        notifyDataSetChanged();
    }

    @Override
    public View createView(Restaurant item) {
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
