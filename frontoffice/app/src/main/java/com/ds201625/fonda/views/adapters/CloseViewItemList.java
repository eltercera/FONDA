package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.DishOrder;

import java.util.ArrayList;



public class CloseViewItemList extends BaseArrayAdapter<DishOrder> {

    public CloseViewItemList(Context context) {
        super(context, R.layout.item_close, R.id.txt,new ArrayList<DishOrder>());
    }

    @Override
    public View createView(DishOrder item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_close, null, true);

        TextView txtTitle2 = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtTitle = (TextView) convertView.findViewById(R.id.txt);
        TextView txtTitle3 = (TextView) convertView.findViewById(R.id.txt3);

        txtTitle3.setGravity(Gravity.RIGHT);
        txtTitle2.setGravity(Gravity.CENTER);

        String count = String.valueOf(item.getCount());
        txtTitle2.setText(item.getDish().getDescription());
        txtTitle.setText(count);
        String cost = String.valueOf(item.getDish().getCost());
        txtTitle3.setText(item.getDish().getCurrency().getSymbol()+ " " + cost);

        return convertView;
    }

    @Override
    public View getNotSelectedView(DishOrder item, View convertView) {

        //convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    @Override
    public View getSelectedView(DishOrder item, View convertView) {
        //TODO: Colocar un color desente
      //  convertView.setBackgroundColor(getContext().getResources()
        //        .getColor(R.color.colorPrimaryDark));
        return convertView;
    }
}