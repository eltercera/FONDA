package com.ds201625.fonda.activities;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Typeface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;

import java.util.List;
import java.util.Map;

/**
 * Created by Adri on 13/04/2016.
 */
public class ExpandableListAdapter extends BaseExpandableListAdapter {
    private Activity context;
    private Map<String, List<String>> coleccionDevisitas;
    private List<String> visitas;

    public ExpandableListAdapter(Activity context, List<String> visitas,
                                 Map<String, List<String>> coleccionDevisitas) {
        this.context = context;
        this.coleccionDevisitas = coleccionDevisitas;
        this.visitas = visitas;
    }

    public Object getChild(int groupPosition, int childPosition) {
        return coleccionDevisitas.get(visitas.get(groupPosition)).get(childPosition);
    }

    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }


    public View getChildView(final int groupPosition, final int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {
        final String detalle = (String) getChild(groupPosition, childPosition);
        LayoutInflater inflater = context.getLayoutInflater();

        if (convertView == null) {
            convertView = inflater.inflate(R.layout.child_item, null);
        }

        TextView item = (TextView) convertView.findViewById(R.id.laptop);
        item.setText(detalle);
        return convertView;
    }

    public int getChildrenCount(int groupPosition) {
        return coleccionDevisitas.get(visitas.get(groupPosition)).size();
    }

    public Object getGroup(int groupPosition) {
        return visitas.get(groupPosition);
    }


    public int getGroupCount() {
        return visitas.size();
    }

    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        String laptopName = (String) getGroup(groupPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.group_item,
                    null);
        }
        TextView item = (TextView) convertView.findViewById(R.id.laptop);
        ImageView icon = (ImageView) convertView.findViewById(R.id.restaurant);
        if((laptopName).equals("RESTAURANTE: Moute Grill                                12/10/15"))
            icon.setImageResource(R.drawable.calendar_24);
        if((laptopName).equals("RESTAURANTE: La Castanuela                              12/10/15"))
            icon.setImageResource(R.drawable.calendar_24);
        if((laptopName).equals("RESTAURANTE: Chino                                      12/10/15"))
            icon.setImageResource(R.drawable.nav_order);
        if((laptopName).equals("RESTAURANTE: Loreto                                     12/10/15"))
            icon.setImageResource(R.drawable.nav_rest);
        if((laptopName).equals("RESTAURANTE: El tinajero                                12/10/15"))
            icon.setImageResource(R.drawable.nav_rest);

        item.setTypeface(null, Typeface.BOLD);
        item.setText(laptopName);
        return convertView;
    }

    public boolean hasStableIds() {
        return true;
    }

    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}
