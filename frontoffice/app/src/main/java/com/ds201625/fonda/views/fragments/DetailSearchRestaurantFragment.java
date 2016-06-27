package com.ds201625.fonda.views.fragments;

import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.FragmentTransaction;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Coordinate;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.DetailRestaurantContract;
import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

import java.io.InputStream;
import java.net.URL;


/**
 * Fragment que contiene los detalles de un restaurante
 */
public class DetailSearchRestaurantFragment extends BaseFragment
        implements DetailRestaurantContract, OnMapReadyCallback{

    //Elementos de la vista
    private Restaurant restaurant;
    private ImageView logo;
    private TextView tvRestName;
    private TextView tvType;
    private TextView tvZone;
    private TextView tvAddress;
    private TextView tvHours;
    private TextView tvDays;
    private GoogleMap map;
    private SupportMapFragment mMapFragment;

    private View form;


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
        form = inflater.inflate(R.layout.fragment_detail_search_restaurants, container, false);
        tvRestName = (TextView) form.findViewById(R.id.text_view_restaurant_name);
        tvType = (TextView) form.findViewById(R.id.text_view_restaurant_type);
        tvZone = (TextView) form.findViewById(R.id.text_view_restaurant_zone);
        tvAddress = (TextView) form.findViewById(R.id.text_view_restaurant_address);
        tvHours = (TextView) form.findViewById(R.id.text_view_restaurant_hours);
        tvDays = (TextView) form.findViewById(R.id.text_view_restaurant_days);
        logo = (ImageView) form.findViewById(R.id.imageview_logo);

        this.mMapFragment = SupportMapFragment.newInstance();
        this.mMapFragment.getMapAsync(this);
        FragmentTransaction fragmentTransaction =
                getFragmentManager().beginTransaction();
        fragmentTransaction.add(R.id.mapview, mMapFragment);
        fragmentTransaction.commit();

        setInfo();
        return form;
    }

    @Override
    public void onMapReady(GoogleMap map) {
        this.map = map;
        Coordinate coordinate = restaurant.getCoordinate();
        if (coordinate != null ) {
            LatLng ling = new LatLng(coordinate.getLatitude(),coordinate.getLongitude());
            mMapFragment.setUserVisibleHint(true);
            map.setMapType(GoogleMap.MAP_TYPE_NORMAL);
            CameraUpdate cameraUpdate = CameraUpdateFactory.newLatLngZoom(ling,17);
            map.animateCamera(cameraUpdate);
            map.addMarker(new MarkerOptions()
                    .position(ling )
                    .title(restaurant.getName()));
        } else {
            mMapFragment.setUserVisibleHint(false);
        }
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
        if (image == null)
            logo.setImageResource(R.mipmap.ic_launcher);
        else
            logo.setImageDrawable(image);
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

}
