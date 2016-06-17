package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.entities.Zone;

import java.util.List;


public class FilterZoneList extends ArrayAdapter<Zone> {

    private final Activity context;
    private final List<Zone> listZone;

    public FilterZoneList(Activity context,
                          List<Zone> _listZone) {
        super(context, R.layout.filter_list, _listZone);
        this.context = context;
        this.listZone = _listZone;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_restaurant_filter, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.txt);

        int counter = 0;

        for (Zone zone: this.listZone){
            if (counter == position){
                txtTitle.setText(zone.getName());
            }
            counter++;
        }
        return rowView;
    }
}