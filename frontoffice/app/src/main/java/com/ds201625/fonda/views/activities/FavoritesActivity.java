package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.google.gson.Gson;

import java.util.List;

public class FavoritesActivity extends BaseNavigationActivity {


    // UI references.
    private ListView list;

    private RestaurantList adapter;
    private List<Restaurant> restaurantList;
    private Commensal logedComensal;
    private String TAG ="FavoritesActivity";

    //Declaracion de
    String[] names = {
            "The dining room",
            "Mogi Mirin",
            "Gordo & Magro",
            "La Casona",
            "Tony's"} ;
    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;
    String[] shortDescription = {
            "Casual",
            "Romantico",
            "Italiano",
            "Italiano",
            "Americano"} ;
    Integer[] imageId = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002,
            R.mipmap.ic_restaurant003,
            R.mipmap.ic_restaurant004,
            R.mipmap.ic_restaurant005,

    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_favorites);
        super.onCreate(savedInstanceState);
        try {
            Commensal log = SessionData.getInstance().getCommensal();

            String emailToWebService;
            try{
                emailToWebService=log.getEmail()+"/";
                Log.v(TAG,"Email->"+emailToWebService);
                RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().
                        getLogedCommensalService();

//                logedComensal =getComensal.getLogedCommensal(emailToWebService);
             //   Log.v(TAG,logedComensal.getId()+"");


            }catch(NullPointerException nu){
                nu.printStackTrace();
            }


            list=(ListView)findViewById(R.id.listViewFavorites);

            AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                    getAllFavoriteRestaurantsService();

            restaurantList =allFavoriteRestaurant.getAllFavoriteRestaurant(9);

            try {
                for (Restaurant rest : restaurantList) {
                    Log.v("WEBSERVICE", rest.getId() + "");
                    Log.v("WEBSERVICE", rest.getName());
                    Log.v("WEBSERVICE", rest.getAddress());
                }
                setupListView();
            }catch (NullPointerException ex){
               // Log.v(TAG,R.string.favorite_conexion_fail_message );

                Toast.makeText(getApplicationContext(), R.string.favorite_conexion_fail_message,
                        Toast.LENGTH_LONG).show();
            }

        }catch (Exception e){
            e.printStackTrace();
        }
    }

    /**
     * Inicializa el ListView y le asigna valores.
     * @param
     * @return
     */

    private void setupListView(){
        adapter = new
                RestaurantList(FavoritesActivity.this, names,location ,shortDescription,imageId,restaurantList);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                Intent detailActivity = new Intent(FavoritesActivity.this, DetailRestaurantActivity.class);
                Restaurant test = getSelectedRestaurant(position);
                detailActivity.putExtra("restaurant", new Gson().toJson(test));
                startActivity(detailActivity);
            }
        });
    }


    /**
     * Devuelve el restaurante Seleccionado por el usuario.
     * @param position
     * @return Restaurant.
     */
    private Restaurant getSelectedRestaurant(int position){
        int contador =0;
        for (Restaurant restaurant: this.restaurantList){
            if (contador == position){
                Log.v(TAG, restaurant.getName());
                return restaurant;
            }
            contador++;
        }
        return null;
    }
}
