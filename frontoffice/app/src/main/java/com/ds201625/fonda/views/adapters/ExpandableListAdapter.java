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
import com.ds201625.fonda.domains.Invoice;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Created by Adri on 13/04/2016.
 */
public class ExpandableListAdapter extends BaseExpandableListAdapter {
    private Context context;
    private Map<String, List<String>> collectionVisits;
    private List<String> visits;
    private String[] date;
    private String[] location;
    private String[] shortDescription;



    public ExpandableListAdapter(Context context, List<String> visits,
                                 Map<String, List<String>> collectionVisits, String[] shortDescription, String[] location, String[] date) {
        this.context = context;
        this.collectionVisits = collectionVisits;
        this.date = date;
        this.visits = visits;
        this.location = location;
        this.shortDescription = shortDescription;

    }

    public Object getChild(int groupPosition, int childPosition) {
        return collectionVisits.get(visits.get(groupPosition)).get(childPosition);
    }


    public View getChildView(final int groupPosition, final int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {
        final String detail = (String) getChild(groupPosition, childPosition);
        LayoutInflater inflater =  ((Activity) context).getLayoutInflater();

        if (convertView == null) {
            convertView = inflater.inflate(R.layout.child_item_detail_visit, null);
        }

        TextView item = (TextView) convertView.findViewById(R.id.detail_restaurant);
        item.setText(detail);
        return convertView;
    }

    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        String restaurantList = (String) getGroup(groupPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.group_item_detail_visit,
                    null);
        }

        ImageView icon = (ImageView) convertView.findViewById(R.id.restaurant);
        TextView dateVisit = (TextView) convertView.findViewById(R.id.date_visit);
        TextView nameRestaurant = (TextView) convertView.findViewById(R.id.name_restaurant);
        TextView locationRestaurant = (TextView) convertView.findViewById(R.id.location_restaurant);
        TextView descriptionRestaurant = (TextView) convertView.findViewById(R.id.description_restaurant);
        if((restaurantList).equals("The dining room"))
            icon.setImageResource(R.mipmap.ic_restaurant001);
        if((restaurantList).equals("Mogi Mirin"))
            icon.setImageResource(R.mipmap.ic_restaurant002);
        if((restaurantList).equals("Gordo & Magro"))
            icon.setImageResource(R.mipmap.ic_restaurant003);
        if((restaurantList).equals("La Casona"))
            icon.setImageResource(R.mipmap.ic_restaurant004);
        if((restaurantList).equals("Tony's"))
            icon.setImageResource(R.mipmap.ic_restaurant005);

        nameRestaurant.setTypeface(null, Typeface.BOLD);
        nameRestaurant.setText(restaurantList);
     //   nameRestaurant.setText(name[groupPosition]);
        locationRestaurant.setText(location[groupPosition]);
        descriptionRestaurant.setText(shortDescription[groupPosition]);
        dateVisit.setText(date[groupPosition]);
        return convertView;
    }


    public int getChildrenCount(int groupPosition) {
        return collectionVisits.get(visits.get(groupPosition)).size();
    }

    public Object getGroup(int groupPosition) {
        return visits.get(groupPosition);
    }


    public int getGroupCount() {
        return visits.size();
    }

    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }


    public boolean hasStableIds() {
        return true;
    }

    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}
