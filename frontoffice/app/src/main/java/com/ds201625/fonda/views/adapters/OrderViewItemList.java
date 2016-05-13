package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.R;
import java.util.ArrayList;
/**
 * Created by jesus on 13/04/16.
 */

public class OrderViewItemList extends BaseArrayAdapter<Dish> {

    public OrderViewItemList(Context context) {
        super(context, R.layout.list_current_order, R.id.txt,new ArrayList<Dish>());

    }

    @Override
    public View createView(Dish item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_current_order, null, true);
        TextView txtTitle = (TextView) convertView.findViewById(R.id.txt);
        TextView txtTitle2 = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtTitle3 = (TextView) convertView.findViewById(R.id.txt3);
        ImageView imageView = (ImageView) convertView.findViewById(R.id.img);

        txtTitle.setText(item.getDescription());
        txtTitle2.setText(item.getName());
        String cost = String.valueOf(item.getCost());
        txtTitle3.setText(item.getCurrency().getSymbol()+ " " + cost);
        imageView.setImageResource(Integer.parseInt(item.getImage()));

        return convertView;

    }

    @Override
    public View getNotSelectedView(Dish item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    @Override
    public View getSelectedView(Dish item, View convertView) {
        //TODO: Colocar un color desente
        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.colorPrimaryDark));
        return convertView;
    }
}