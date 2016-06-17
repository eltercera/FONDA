package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import java.util.ArrayList;

/**
 * Adapter para la vista de la lista de restaurantes
 */
public class RestaurantViewItemList extends BaseArrayAdapter<Restaurant> {


    public RestaurantViewItemList(Context context) {
        super(context, R.layout.list_restaurant,R.id.txt,new ArrayList<Restaurant>());

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
                .getColor(R.color.creme));
        return convertView;
    }

    @Override
    public View getNotSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }


}
