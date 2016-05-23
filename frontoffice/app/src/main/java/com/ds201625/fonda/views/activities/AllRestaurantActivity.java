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
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.google.gson.Gson;

import java.util.List;

public class AllRestaurantActivity extends BaseNavigationActivity {

    private RestaurantList adapter;
    private ListView list;
    private List<Restaurant> restaurantList;
    private String TAG = "AllRestaurantActivity";
    private Commensal logedComensal;

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
        setContentView(R.layout.activity_all_restaurant);
        super.onCreate(savedInstanceState);
        list=(ListView)findViewById(R.id.listViewRestaurants);


        try {
            Commensal log = SessionData.getInstance().getCommensal();

            String emailToWebService;
            try{
                emailToWebService=log.getEmail()+"/";
                Log.v(TAG, "Email->" + emailToWebService);
                RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().
                        getLogedCommensalService();
                logedComensal =getComensal.getLogedCommensal(emailToWebService);

                Log.v(TAG,logedComensal.getId()+"");


            }catch(NullPointerException nu){
                nu.printStackTrace();
            }


            list=(ListView)findViewById(R.id.listViewFavorites);

                /*
                    AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                            getAllFavoriteRestaurantsService();

                    restaurantList =allFavoriteRestaurant.getAllFavoriteRestaurant(1);
                 */
            AllRestaurantService allRestaurant = FondaServiceFactory.getInstance().
                    getAllRestaurantsService();
            restaurantList = allRestaurant.getAllRestaurant();


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

    private void setupListView(){
        RestaurantList adapter = new
                RestaurantList(AllRestaurantActivity.this, names,location ,shortDescription,imageId,restaurantList);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
//                Toast.makeText(FavoritesActivity.this, "You Clicked at " + names[+position], Toast.LENGTH_SHORT).show();
                Intent cambio = new Intent(AllRestaurantActivity.this, DetailRestaurantActivity.class);
                /*
                    String nombreRest = names[+position];
                    String descriptionRest = shortDescription[+position];
                    String locationRest = location[+position];
                    Integer imageRest = imageId[+position];
                    cambio.putExtra("NOMBRE", nombreRest);
                    cambio.putExtra("LOCATION", locationRest);
                    cambio.putExtra("DESCRIPTION", descriptionRest);
                    cambio.putExtra("IMAGE", imageRest);
                */
                Restaurant test = getSelectedRestaurant(position);

                cambio.putExtra("restaurant", new Gson().toJson(test));
                startActivity(cambio);
            }
        });
    }
    private Restaurant getSelectedRestaurant(int position){
        int contador =0;
        for (Restaurant rest: this.restaurantList){
            if (contador == position){
//                Log.v("WEBSERVICEcanguro", rest.getName());
                return rest;
            }
            contador++;
        }

        return null;
    }

}
