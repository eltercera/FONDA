package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
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
    private Context context;
    private Map<String, List<String>> coleccionDevisitas;
    private List<String> visitas;
    private String[] location;
    private String[] shortDescription;


    public ExpandableListAdapter(Context context, List<String> visitas,
                                 Map<String, List<String>> coleccionDevisitas, String[] shortDescription, String[] location) {
        this.context = context;
        this.coleccionDevisitas = coleccionDevisitas;
        this.visitas = visitas;
        this.location = location;
        this.shortDescription = shortDescription;
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
        LayoutInflater inflater =  ((Activity) context).getLayoutInflater();

        if (convertView == null) {
            convertView = inflater.inflate(R.layout.child_item_detail_visit, null);
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
            convertView = infalInflater.inflate(R.layout.group_item_detail_visit,
                    null);
        }

        ImageView icon = (ImageView) convertView.findViewById(R.id.restaurant);
        TextView item = (TextView) convertView.findViewById(R.id.laptop);
        TextView item2 = (TextView) convertView.findViewById(R.id.txt2);

        TextView item3 = (TextView) convertView.findViewById(R.id.txt3);
        if((laptopName).equals("The dining room"))
            icon.setImageResource(R.mipmap.ic_restaurant001);
        if((laptopName).equals("Mogi Mirin"))
            icon.setImageResource(R.mipmap.ic_restaurant002);
        if((laptopName).equals("Gordo & Magro"))
            icon.setImageResource(R.mipmap.ic_restaurant003);
        if((laptopName).equals("La Casona"))
            icon.setImageResource(R.mipmap.ic_restaurant004);
        if((laptopName).equals("Tony's"))
            icon.setImageResource(R.mipmap.ic_restaurant005);

        item.setTypeface(null, Typeface.BOLD);
        item.setText(laptopName);
        item2.setText(location[groupPosition]);
        item3.setText(shortDescription[groupPosition]);
        return convertView;
    }

    public boolean hasStableIds() {
        return true;
    }

    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}
