package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.graphics.drawable.Drawable;
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
import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapView;
import com.google.android.gms.maps.MapsInitializer;
import com.google.android.gms.maps.model.LatLng;

import org.w3c.dom.Text;

import java.io.InputStream;
import java.net.URL;


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
    MapView mapView;
    GoogleMap map;
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
        logo = (ImageView) form.findViewById(R.id.imageview_logo);

        //Codigo del Mapa
        mapView = (MapView) form.findViewById(R.id.mapview);
        mapView.onCreate(savedInstanceState);

        // Gets to GoogleMap from the MapView and does initialization stuff
        map = mapView.getMap();
        map.getUiSettings().setMyLocationButtonEnabled(false);
        map.setMyLocationEnabled(true);

        // Needs to call MapsInitializer before doing any CameraUpdateFactory calls
        MapsInitializer.initialize(this.getActivity());

        setInfo();
        return form;
    }

    private void setInfo() {
        if (restaurant == null || tvRestName == null)
            return;
        tvRestName.setText(restaurant.getName());
        tvType.setText(restaurant.getRestaurantCategory().getName());
        tvZone.setText(restaurant.getZone().getName());
        tvAddress.setText(restaurant.getAddress());
        tvHours.setText("8:00am a 7:00 pm"); //No hay horas
        tvDays.setText("Martes a Domingo"); //No hay dias
        Drawable image = loadImageFromWebOperations(restaurant.getLogo());
        if (image == null) logo.setImageResource(R.mipmap.ic_launcher);
        else logo.setImageDrawable(image);
        // Updates the location and zoom of the MapView
        CameraUpdate cameraUpdate = CameraUpdateFactory.newLatLngZoom(new LatLng(40.7484, 73.9857), 10);
        map.animateCamera(cameraUpdate);
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

    public Drawable loadImageFromWebOperations(String url) {
        try {
            InputStream is = (InputStream) new URL(url).getContent();
            Drawable d = Drawable.createFromStream(is, "logo");
            return d;
        } catch (Exception e) {
            return null;
        }
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
