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
import java.util.Date;
import java.util.List;
import java.util.Map;

/**
 * Created by Adri on 13/04/2016.
 */

/**
 *  Clase para llenar la lista expandible de el historial de visitas de restaurant
 */
public class ExpandableListAdapter extends BaseExpandableListAdapter {
    private Context context;
    private Map<String, List<String>> collectionVisits;
    private List<String> nameRestaurant;
    private List<String> categoryRestaurant;
    private List<String> addressRestaurant;
    private List<String> datePaymentRestaurant;

    /**
     *Constructor de la clase ExpandableListAdapter
     * @param context
     * @param nameRestaurant
     * @param collectionVisits
     * @param categoryRestaurant
     * @param addressRestaurant
     * @param datePaymentRestaurant
     */
    public ExpandableListAdapter(Context context, List<String> nameRestaurant,
                                 Map<String, List<String>> collectionVisits, List<String> categoryRestaurant, List<String> addressRestaurant, List<String> datePaymentRestaurant) {
        this.context = context;
        this.collectionVisits = collectionVisits;
        this.nameRestaurant = nameRestaurant;
        this.datePaymentRestaurant = datePaymentRestaurant;
        this.categoryRestaurant = categoryRestaurant;
        this.addressRestaurant = addressRestaurant;
    }

    /**
     * Metodo para obtener el hijo de la lista expandible
     * @param groupPosition
     * @param childPosition
     * @return Lista de String con el nombre del Restaurant
     */
    public Object getChild(int groupPosition, int childPosition) {
        return collectionVisits.get(nameRestaurant.get(groupPosition)).get(childPosition);
    }

    /**
     * Metodo que pinta la lista expandible de la vista de los hijos
     * @param groupPosition
     * @param childPosition
     * @param isLastChild
     * @param convertView
     * @param parent
     * @return la vista del ConverView de los hijos
     */
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

    /**
     * Metodo que pinta la lista expandible de los padres
     * @param groupPosition
     * @param isExpanded
     * @param convertView
     * @param parent
     * @return la vista  del converView del grupo
     */
    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        String restaurantList = (String) getGroup(groupPosition);
        String addressList = (String) getGroupAddress(groupPosition);
        String categoryList = (String) getGroupCategory(groupPosition);
        String datePaymentList =(String) getGroupDate(groupPosition);

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
        locationRestaurant.setText(addressList);
        descriptionRestaurant.setText(categoryList);
        dateVisit.setText(datePaymentList);
        return convertView;
    }

    /**
     * metodo qe obtiene el numero de hijos de la lista expandible
     * @param groupPosition
     * @return entero con la cantidad de hijos de la lista.
     */
    public int getChildrenCount(int groupPosition) {
        return collectionVisits.get(nameRestaurant.get(groupPosition)).size();
    }

    /**
     * metodo que obtiene el grupo la lista expandible
     * @param groupPosition
     * @return nombre de restaurant
     */
    public Object getGroup(int groupPosition) {
        return nameRestaurant.get(groupPosition);
    }

    /**
     * metodo que obtiene el grupo la lista expandible
     * @param groupPosition
     * @return direccion de Restaurant
     */
    public Object getGroupAddress(int groupPosition) {
        return addressRestaurant.get(groupPosition);
    }

    /**
     * metodo que obtiene el grupo la lista expandible
     * @param groupPosition
     * @return categoria de Restaurant
     */
    public Object getGroupCategory(int groupPosition) {
        return categoryRestaurant.get(groupPosition);
    }

    /**
     * metodo que obtiene el grupo la lista expandible
     * @param groupPosition
     * @return fecha de Restaurant
     */
    public Object getGroupDate(int groupPosition) {
        return datePaymentRestaurant.get(groupPosition);
    }

    /**
     * metodo que obtiene la cantidad de elementos del grupo padre de la lista expandible
     * @return numero de elementos
     */
    public int getGroupCount() {
        return nameRestaurant.size();
    }

    /**
     * Metodo que obtiene el id del grupo padre de la lista expadible
     * @param groupPosition
     * @return variable long que indica el id del grupo
     */
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    /**
     * Metodo que obtiene el id del grupo de hijos de la lista expadible
     * @param groupPosition
     * @param childPosition
     * @return variable long que indica el id del grupo
     */
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    /**
     * Metodo que verica el estado de los id de la lista expandible
     * @return variable boolean
     */
    public boolean hasStableIds() {
        return true;
    }

    /**
     * Metodo que verifica la seleccion de los hijos de la lista expandible
     * @return variable boolean
     */
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}
