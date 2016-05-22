package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
<<<<<<< HEAD
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.google.gson.Gson;

import java.util.List;
=======
import com.ds201625.fonda.logic.SessionData;
>>>>>>> commensal-profile-management

public class FavoritesActivity extends BaseNavigationActivity {


    private RestaurantList adapter;
    private ListView list;
    private List<Restaurant> restaurantList;
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

<<<<<<< HEAD
        list=(ListView)findViewById(R.id.listViewFavorites);

        AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                getAllFavoriteRestaurantsService();
        restaurantList =allFavoriteRestaurant.getAllFavoriteRestaurant(2);
        /*
        AllRestaurantService allRestaurant = FondaServiceFactory.getInstance().
                getAllRestaurantsService();
        restaurantList = allRestaurant.getAllRestaurant();
        */
/*        for (Restaurant rest : restaurantList){
            Log.v("WEBSERVICE", rest.getId() + "");
            Log.v("WEBSERVICE",rest.getName());
            Log.v("WEBSERVICE",rest.getAddress());
        }*/

        setupListView();

    }

    private void setupListView(){
        RestaurantList adapter = new
                RestaurantList(FavoritesActivity.this, names,location ,shortDescription,imageId,restaurantList);
        //list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
//                Toast.makeText(FavoritesActivity.this, "You Clicked at " + names[+position], Toast.LENGTH_SHORT).show();
                Intent cambio = new Intent(FavoritesActivity.this, DetailRestaurantActivity.class);
                /*
=======
        // si existe un token o lo logra obtener uno nuevo vigente salta
        if (SessionData.getInstance().getToken() == null) {
            skip();
            return;
        }
        else{
            RestaurantList adapter = new
                    RestaurantList(FavoritesActivity.this, names,location ,shortDescription,imageId);
            list=(ListView)findViewById(R.id.listViewFavorites);
            list.setAdapter(adapter);
            list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                @Override
                public void onItemClick(AdapterView<?> parent, View view,
                                        int position, long id) {
                    Toast.makeText(FavoritesActivity.this, "You Clicked at " + names[+position], Toast.LENGTH_SHORT).show();
                    Intent cambio = new Intent (FavoritesActivity.this,DetailRestaurantActivity.class);
>>>>>>> commensal-profile-management
                    String nombreRest = names[+position];
                    String descriptionRest = shortDescription[+position];
                    String locationRest = location[+position];
                    Integer imageRest = imageId[+position];
<<<<<<< HEAD
                    cambio.putExtra("NOMBRE", nombreRest);
                    cambio.putExtra("LOCATION", locationRest);
                    cambio.putExtra("DESCRIPTION", descriptionRest);
                    cambio.putExtra("IMAGE", imageRest);
                */
                Restaurant test = getSelectedRestaurant(position);

                cambio.putExtra("restaurante", new Gson().toJson(test));
                startActivity(cambio);
            }
        });
=======
                    cambio.putExtra("NOMBRE",nombreRest);
                    cambio.putExtra("LOCATION",locationRest);
                    cambio.putExtra("DESCRIPTION",descriptionRest);
                    cambio.putExtra("IMAGE",imageRest);
                    startActivity(cambio);

                }
            });
        }

    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,LoginActivity.class));
>>>>>>> commensal-profile-management
    }

    private Restaurant getSelectedRestaurant(int position){
        int contador =0;
        for (Restaurant rest: this.restaurantList){
            if (contador == position){
                Log.v("WEBSERVICEcanguro", rest.getName());
                return rest;
            }
            contador++;
        }

        return null;
    }
}
