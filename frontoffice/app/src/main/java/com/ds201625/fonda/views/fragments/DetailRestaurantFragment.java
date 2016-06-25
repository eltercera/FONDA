package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.DetailRestaurantContract;
import org.w3c.dom.Text;


/**
 * Fragment que contiene los detalles de un restaurante
 */
public class DetailRestaurantFragment extends BaseFragment implements DetailRestaurantContract {

    //Elementos de la vista
    private Restaurant restaurant;
    private ImageView logo;
    private TextView tvRestName;
    private TextView tvType;
    private TextView tvZone;
    private TextView tvAddress;
    private TextView tvHours;
    private TextView tvDays;
    private View form;

    /**
     * Crea el fragment
     * @param savedInstanceState
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    /**
     * Crea la actividad
     * @param savedInstanceState
     */
    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
    }

    /**
     * Crea la vista
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        form = inflater.inflate(R.layout.fragment_detail_restaurants, container, false);
        tvRestName = (TextView) form.findViewById(R.id.text_view_restaurant_name);
        tvType = (TextView) form.findViewById(R.id.text_view_restaurant_type);
        tvZone = (TextView) form.findViewById(R.id.text_view_restaurant_zone);
        tvAddress = (TextView) form.findViewById(R.id.text_view_restaurant_address);
        tvHours = (TextView) form.findViewById(R.id.text_view_restaurant_hours);
        tvDays = (TextView) form.findViewById(R.id.text_view_restaurant_days);

        setInfo();
        return form;
    }

    private void setInfo() {
        if (restaurant == null || tvRestName == null)
            return;
        tvRestName.setText(restaurant.getName());
        tvType.setText(restaurant.getRestaurantCategory().getName());
        tvZone.setText(""); //No hay zona en el rest?
        tvAddress.setText(restaurant.getAddress());
        tvHours.setText(""); //No hay horas
        tvDays.setText(""); //No hay dias
    }

    /**
     * Asigna los valores de un restaurant a los elementos de la vista.
     * @param restaurant restaurant a mostrar
     */
    public void setRestaurant(Restaurant restaurant) {
        this.restaurant = restaurant;
        setInfo();
    }


    /**
     * Obtiene el restaurante seleccionado
     * @return restuarant
     */
    public Restaurant getRestaurant() {
        return restaurant;
    }


    /**
     * Cuando se une
     * @param context

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    } */

    /**
     * Cuando se desune

    @Override
    public void onDetach() {
        super.onDetach();
    }*/



}
