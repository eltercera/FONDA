package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.DishOrder;


/**
 *  Clase para llenar la lista del cierre de cuenta
 */
public class CloseViewItemList extends BaseArrayAdapter<DishOrder> {



    /**
     *Constructor de la clase CloseViewItemList
     * @param context  Context que define los recursos especificos de la aplicacion
     */
    public CloseViewItemList(Context context) {
        super(context, R.layout.item_close, R.id.txt);
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
        convertView = inflater.inflate(R.layout.item_close, null, true);

        TextView txtDescripcion = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtCount = (TextView) convertView.findViewById(R.id.txt);
        TextView txtCost = (TextView) convertView.findViewById(R.id.txt3);

        txtCost.setGravity(Gravity.RIGHT);
        txtDescripcion.setGravity(Gravity.CENTER);

        String count = String.valueOf(item.getCount());
        txtDescripcion.setText(item.getDish().getDescription());
        txtCount.setText(count);
        String cost = String.valueOf(item.getDish().getCost());
        txtCost.setText(cost);

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