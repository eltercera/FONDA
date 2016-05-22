package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Typeface;
import android.graphics.drawable.Drawable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Invoice;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

/**
 * Created by Adri on 13/04/2016.
 */

/**
 *  Clase para llenar la lista expandible del historial de visitas de restaurant
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
     * @param context               Context que define los recursos especificos de la aplicacion
     * @param nameRestaurant        Lista de String que define el nombre del restaurant
     * @param collectionVisits      Lista de String que define todos los datos del restaurant
     * @param categoryRestaurant    Lista de string que define la categoria del restaurant
     * @param addressRestaurant     Lista de string que define la direccion del Restaurant
     * @param datePaymentRestaurant Lista de string que define la fecha de pago de una visita a un restaurant
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
     * @param groupPosition    Entero que define la posicion del grupo padre de la lista expandible
     * @param childPosition    Entero que define la posicion del grupo hijo de la lista expandible
     * @return Lista de String con el nombre del restaurant
     */
    public Object getChild(int groupPosition, int childPosition) {
        return collectionVisits.get(nameRestaurant.get(groupPosition)).get(childPosition);
    }

    /**
     * Metodo que pinta la lista expandible de la vista de los hijos
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @param childPosition Entero que define la posicion del grupo hijo de la lista expandible
     * @param isLastChild   Boolean que define el estado de la posicion del grupo hijo de la lista expandible
     * @param convertView   Vista que define la vista del grupo hijo de la lista expandible
     * @param parent        Vista que define el grupo de vistas de la lista expandible
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
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @param isExpanded    Boolean que define el estado de la expansion de la lista.
     * @param convertView   Vista que define la vista del grupo hijo de la lista expandible
     * @param parent        Vista que define el grupo de vistas de la lista expandible
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
        if((restaurantList).equals("The dining room")) {
            icon.setImageResource(R.mipmap.ic_restaurant003);
           /* Context context = icon.getContext();
            int id = context.getResources().getIdentifier("ic_restaurant001", "mipmap", context.getPackageName());
            icon.setImageResource(id);*/
        }
        if((restaurantList).equals("Mogi Mirin")) {
            icon.setImageResource(R.mipmap.ic_restaurant003);
          /*  Context context = icon.getContext();
            int id = context.getResources().getIdentifier("ic_restaurant002", "mipmap", context.getPackageName());
            icon.setImageResource(id);*/
        }
        if((restaurantList).equals("Gordo & Magro")) {
            icon.setImageResource(R.mipmap.ic_restaurant003);
        }
        if((restaurantList).equals("La Casona")) {
            icon.setImageResource(R.mipmap.ic_restaurant004);
        }
        if((restaurantList).equals("Tony's")) {
            icon.setImageResource(R.mipmap.ic_restaurant005);
        }
        nameRestaurant.setTypeface(null, Typeface.BOLD);
        nameRestaurant.setText(restaurantList);
        locationRestaurant.setText(addressList);
        descriptionRestaurant.setText(categoryList);
        dateVisit.setText(datePaymentList);

        return convertView;
    }

    /**
     * Metodo qe obtiene el numero de hijos de la lista expandible
     * @param groupPosition  Entero que define la posicion del grupo padre de la lista expandible
     * @return entero con la cantidad de hijos de la lista.
     */
    public int getChildrenCount(int groupPosition) {
        return collectionVisits.get(nameRestaurant.get(groupPosition)).size();
    }

    /**
     * Metodo que obtiene el grupo la lista expandible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @return nombre de restaurant
     */
    public Object getGroup(int groupPosition) {
        return nameRestaurant.get(groupPosition);
    }

    /**
     * Metodo que obtiene el grupo la lista expandible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @return direccion de Restaurant
     */
    public Object getGroupAddress(int groupPosition) {
        return addressRestaurant.get(groupPosition);
    }

    /**
     * Metodo que obtiene el grupo la lista expandible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @return categoria de Restaurant
     */
    public Object getGroupCategory(int groupPosition) {
        return categoryRestaurant.get(groupPosition);
    }

    /**
     * Metodo que obtiene el grupo la lista expandible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @return fecha de Restaurant
     */
    public Object getGroupDate(int groupPosition) {
        return datePaymentRestaurant.get(groupPosition);
    }

    /**
     * Metodo que obtiene la cantidad de elementos del grupo padre de la lista expandible
     * @return numero de elementos
     */
    public int getGroupCount() {
        return nameRestaurant.size();
    }

    /**
     * Metodo que obtiene el id del grupo padre de la lista expadible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @return variable long que indica el id del grupo
     */
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    /**
     * Metodo que obtiene el id del grupo de hijos de la lista expadible
     * @param groupPosition Entero que define la posicion del grupo padre de la lista expandible
     * @param childPosition Entero que define la posicion del grupo hijo de la lista expandible
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
