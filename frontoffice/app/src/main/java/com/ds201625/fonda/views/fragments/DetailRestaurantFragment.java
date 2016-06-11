package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Person;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;


/**
 * Fragment que contiene el formulario de para un perfil
 */
public class DetailRestaurantFragment extends BaseFragment {

    //Elementos de la vista
    private Restaurant restaurant;
    private TextView tvRestName;
    private TextView tvNames;
    private TextView tvOther;
    private TextView tvType;
    private TextView tvZone;
    private TextView tvAvPr;
    private View form;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        form = inflater.inflate(R.layout.fragment_detail_restaurants, container, false);
        tvRestName = (TextView) form.findViewById(R.id.text_view_restaurant_name);
        tvNames = (TextView) form.findViewById(R.id.text_view_restaurant);
        tvType = (TextView) form.findViewById(R.id.text_view_restaurant_type);
        tvZone = (TextView) form.findViewById(R.id.text_view_restaurant_zone);
        tvAvPr = (TextView) form.findViewById(R.id.text_view_restaurant_principal_avenue);
        tvOther = (TextView) form.findViewById(R.id.text_view_restaurant_other_avenue);

        //Falta Horario
        return form;
    }

    /**
     * Asigna los valores de un restaurant a los elementos de la vista.
     * @param restaurant restaurant a mostrar
     */
    public void setRestaurant(Restaurant restaurant) {
        tvRestName.setText(restaurant.getName());
        tvNames.setText(restaurant.getRestaurantCategory().getNameCategory());
        tvType.setText(restaurant.getRestaurantCategory().getName());
        tvAvPr.setText(restaurant.getAddress());
        this.restaurant = restaurant;
    }



    public Restaurant getRestaurant() {
        return restaurant;
    }



    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }



}
