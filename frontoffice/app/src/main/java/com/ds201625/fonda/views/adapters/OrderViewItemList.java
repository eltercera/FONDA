package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.DishOrder;

import java.util.ArrayList;


public class OrderViewItemList extends BaseArrayAdapter<DishOrder> {

    public OrderViewItemList(Context context) {
        super(context, R.layout.list_current_order, R.id.txt,new ArrayList<DishOrder>());

    }

    @Override
    public View createView(DishOrder item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_current_order, null, true);
        TextView txtTitle = (TextView) convertView.findViewById(R.id.txt);
        TextView txtTitle2 = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtTitle3 = (TextView) convertView.findViewById(R.id.txt3);
        TextView txtTitle4 = (TextView) convertView.findViewById(R.id.txt4);
        ImageView imageView = (ImageView) convertView.findViewById(R.id.img);

        txtTitle.setText(item.getDish().getDescription());
        txtTitle2.setText(item.getDish().getName());
        String cost = String.valueOf(item.getDish().getCost());
        txtTitle3.setText(item.getDish().getCurrency().getSymbol()+ " " + cost);
        String count = String.valueOf(item.getCount());
        txtTitle4.setText("Cant: " + count);
        imageView.setImageResource(Integer.parseInt(item.getDish().getImage()));


        return convertView;

    }

    @Override
    public View getNotSelectedView(DishOrder item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    @Override
    public View getSelectedView(DishOrder item, View convertView) {
        //TODO: Colocar un color desente
        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.colorPrimaryDark));
        return convertView;
    }
}