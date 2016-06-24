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
     * No es una lista multi-select
     */
    @Override
    public View getSelectedView(NounBaseEntity item, View convertView) {
        return null;
    }

    /**
     * No es una lista multi-select
     */
    @Override
    public View getNotSelectedView(NounBaseEntity item, View convertView) {
        return null;
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
