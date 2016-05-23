package com.ds201625.fonda.views.activities;
import android.content.Intent;
import android.os.Bundle;
import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.AllReservesService;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.logic.SessionData;
import com.google.gson.Gson;

import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.List;

/**
 * Created by Jessica on 18/4/2016.
 */

public class ReserveActivity extends BaseNavigationActivity {
    private ListView list;
    private List<Reservation> reserveList;
    String[] restaurants = {
            "The dining room",
            "Mogi Mirin"};
    String[] date = {
            "15/09/2016",
            "27/09/2016"};
/*    String[] time = {
            "8:00 p.m.",
            "6:00 p.m."};*/
    String[] dinners = {
            "3 comensales",
            "2 comensales" };
    Integer[] picture = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_reserve);

        /**
         * Esta es la validacion de si el usuario ya esta loggeado o no.
         */
        // para saltar o no
        boolean skp = false;

        // inicializa los datos de la sesion
        if (SessionData.getInstance() == null)
            try {
                SessionData.initInstance(getApplicationContext());
            } catch (Exception e) {
                e.printStackTrace();
            }
        super.onCreate(savedInstanceState);

        if (SessionData.getInstance().getToken() == null) {
            skip();
            return;
        }
        else {
            /**
             * Esto es lo que tenia el Modulo de Reservas en principio.
             */
            list = (ListView) findViewById(R.id.listOfReservations);

            AllReservesService allReserves = FondaServiceFactory.getInstance().
                    getAllReservesService();
            reserveList = allReserves.getAllReserves(2);

            setupListView();
        }
    }

    private void skip() { startActivity(new Intent(this,ReserveActivity.class));}

    private void setupListView(){
        ReserveList adapter = new
                ReserveList (ReserveActivity.this,restaurants,date,dinners, picture,reserveList);
        list = (ListView)findViewById(R.id.listOfReservations);
        // list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                // Toast.makeText(ReserveActivity.this, "You Clicked at " + restaurants[+position], Toast.LENGTH_SHORT).show();
                Intent change = new Intent (ReserveActivity.this,CancelReserveActivity.class);
                Reservation test = getSelectedReservation(position);
                change.putExtra("reservacion", new Gson().toJson(test));
                startActivity(change);
            }
        });
    }

    private Reservation getSelectedReservation(int position){
        int contador = 0;
        for (Reservation reservation: this.reserveList){
            if (contador == position){
                Log.v("WEBSERVICEcanguro", reservation.getRestaurant().getName());
                return reservation;
            }
            contador ++;
        }
        return null;
    }
}