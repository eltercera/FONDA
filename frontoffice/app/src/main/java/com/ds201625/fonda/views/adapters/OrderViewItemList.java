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
import java.util.List;

/**
 *  Clase para llenar la lista de los platos ordenados
 */
public class OrderViewItemList extends BaseArrayAdapter<DishOrder> {

    /**
     *Constructor de la clase OrderViewItemList
     * @param context               Context que define los recursos especificos de la aplicacion
     */
    public OrderViewItemList(Context context) {
        super(context, R.layout.list_current_order, R.id.txt);

    }

    /**
     * Metodo que pinta la lista de platos
     * @param item Objeto de tipo DishOrder que define lo que va dentro de la lista
     * @return la vista  del converView del grupo
     */
    @Override
    public View createView(DishOrder item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_current_order, null, true);
        TextView txtDescripcion = (TextView) convertView.findViewById(R.id.txt);
        TextView txtName = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtCost = (TextView) convertView.findViewById(R.id.txt3);
        TextView txtCount = (TextView) convertView.findViewById(R.id.txt4);
        ImageView icon = (ImageView) convertView.findViewById(R.id.img);

        txtDescripcion.setText(item.getDish().getDescription());
        txtName.setText(item.getDish().getName());
        String cost = String.valueOf(item.getDish().getCost());
        txtCost.setText(cost);
        String count = String.valueOf(item.getCount());
        txtCount.setText("Cant: " + count);

        if((item.getDish().getDescription()).equals("Pasta Con Salmon")) {
            icon.setImageResource(R.drawable.salmonpasta);
        }
        if((item.getDish().getDescription()).equals("Coca-Cola")) {
            icon.setImageResource(R.drawable.refresco);
        }
        if((item.getDish().getDescription()).equals("Terciopelo Rojo")) {
            icon.setImageResource(R.drawable.redv2);
        }

//        icon.setImageResource(Integer.parseInt(item.getDish().getImage()));


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