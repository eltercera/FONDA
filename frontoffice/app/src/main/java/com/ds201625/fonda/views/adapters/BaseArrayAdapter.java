package com.ds201625.fonda.views.adapters;

import android.content.Context;
import android.util.SparseBooleanArray;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import java.util.ArrayList;
import java.util.List;

/**
 * ArrayAdapter Base para la integracion con listviews
 * @param <T>
 */
public abstract class BaseArrayAdapter<T> extends ArrayAdapter<T> {

    /**
     * Para el control de los Items seleccionados
     */
    private SparseBooleanArray mSelectedItemsIds = new SparseBooleanArray();

    // Constructores

    public BaseArrayAdapter(Context context, int resource) {
        super(context, resource);
    }

    public BaseArrayAdapter(Context context, int resource, int textViewResourceId) {
        super(context, resource, textViewResourceId);
    }

    public BaseArrayAdapter(Context context, int resource, int textViewResourceId, T[] objects) {
        super(context, resource, textViewResourceId, objects);
    }

    public BaseArrayAdapter(Context context, int resource, int textViewResourceId, List<T> objects) {
        super(context, resource, textViewResourceId, objects);
    }

    @Override
    public void remove(T object) {
        mSelectedItemsIds.delete(getPosition(object));
        super.remove(object);
    }

    @Override
    public void clear() {
        mSelectedItemsIds.clear();
        super.clear();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        T item = getItem(position);
        if (convertView == null) {
            convertView = createView(item);
        }
        if (mSelectedItemsIds.get(position))
            return getSelectedView(item,convertView);
        return getNotSelectedView(item,convertView);
    }

    /**
     * Cambia el estado de seleccion de un elemento.
     * @param position posicion del elemento
     * @param value true Seleccionado, False no seleccionado.
     */
    public void setSelectedItem(int position, boolean value) {
        if (value)
            mSelectedItemsIds.put(position,value);
        else
            mSelectedItemsIds.delete(position);
        notifyDataSetChanged();
    }

    /**
     * Cuenta los elementos seleccionados
     * @return int cantidad de elementos seleccionados actualemente
     */
    public int countSelected() {
        return mSelectedItemsIds.size();
    }

    /**
     * Obtiele todos los items seleccionados.
     * @return Items seleccionados actualmente.
     */
    public ArrayList<T> getAllSeletedItems() {
        ArrayList<T> ret = new ArrayList<T>();
        for (int i = 0; i < getCount(); i++) {
            if (mSelectedItemsIds.get(i)) {
                ret.add(getItem(i));
            }
        }
        return ret;
    }

    /**
     * Reinicia la seleccion de los items
     */
    public void cleanSelected() {
        mSelectedItemsIds.clear();
    }

    /**
     * Para implementar cambios en una vista de un item que este seleccionado
     * @param item item seleccionado
     * @param convertView vista ya creada
     * @return vista del item modificada
     */
    public abstract View getSelectedView(T item, View convertView);

    /**
     * Para implementar cambios en una vista de un item que no este seleccionado
     * @param item item no seleccionado
     * @param convertView vista ya creada
     * @return vista del item modificada
     */
    public abstract View getNotSelectedView(T item, View convertView);

    /**
     * Para implementar la creación de la vista de un Item
     * @param item elemento a construir la vista
     * @return Vista del elemento creada.
     */
    public abstract View createView(T item);

}
