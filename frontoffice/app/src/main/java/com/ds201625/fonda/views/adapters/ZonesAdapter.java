package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Zone;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by gbsoj on 6/22/2016.
 */
public class ZonesAdapter extends BaseArrayAdapter<Zone> {
    int currentPage = 0;

    public ZonesAdapter(Context context) {
        super(context, R.layout.fragment_filter,R.id.tvFilter,new ArrayList<Zone>());
        update();
    }

    @Override
    public View createView(Zone item) {
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_filter, null, true);
        TextView tvFilter = (TextView) convertView.findViewById(R.id.tvFilter);
        tvFilter.setText(item.getName());
        return convertView;
    }

    @Override
    public View getSelectedView(Zone item, View convertView) {
        convertView.setBackgroundColor(getContext().getResources()
        .getColor(R.color.creme));
        return convertView;
    }

    @Override
    public View getNotSelectedView(Zone item, View convertView) {
        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    public void update() {
        List<Zone> restaurants = null;

        try {
            Command comando = FondaCommandFactory.getInstance().getZonesCommand();
            comando.setParameter(0,"");
            comando.setParameter(1, 10);
            comando.setParameter(2, currentPage + 1);
            comando.run();
            restaurants = (List<Zone>)comando.getResult();
        }
        catch (Exception e) {
            e.printStackTrace();
        }

        currentPage++;
        if (restaurants != null) {
            clear();
            addAll(restaurants);
        }
        notifyDataSetChanged();
    }
}
