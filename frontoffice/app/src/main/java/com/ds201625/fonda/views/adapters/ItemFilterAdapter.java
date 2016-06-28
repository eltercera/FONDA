package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.NounBaseEntity;
import java.util.ArrayList;

/**
 * Adaptador para lista de filtros de busqueda
 */
public class ItemFilterAdapter extends BaseArrayAdapter<NounBaseEntity> {

    public ItemFilterAdapter(Context context) {
        super(context, R.layout.fragment_filter,R.id.tvFilter,new ArrayList<NounBaseEntity>());
    }


    /**
     * Vista de un item Seleccionado
     * @param item item seleccionado
     * @param convertView vista ya creada
     * @return Vista de item Seleccionado
     */
    @Override
    public View getSelectedView(NounBaseEntity item, View convertView) {
        convertView.setBackgroundColor(getContext().getResources().
                getColor(R.color.creme));
        return convertView;
    }

    /**
     * Vista de un item no Seleccionado
     * @param item item no seleccionado
     * @param convertView vista ya creada
     * @return Vista de item no Seleccionado
     */
    @Override
    public View getNotSelectedView(NounBaseEntity item, View convertView) {
        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }


    /**
     * Creacion de vista para un item
     * @param item elemento a construir la vista
     * @return vista contruida
     */
    @Override
    public View createView(NounBaseEntity item) {
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_filter, null, true);
        TextView tvFilter = (TextView) convertView.findViewById(R.id.tvFilter);
        tvFilter.setText(item.getName());
        return convertView;
    }
}
