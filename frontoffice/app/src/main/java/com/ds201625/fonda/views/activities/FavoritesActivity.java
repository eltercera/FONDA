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
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
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
        /**
         * Esta es la validacion de si el usuario ya esta loggeado o no.
         */
        // para saltar o no
        boolean skp = false;

        // inicializa los datos de la sesion
        if (SessionData.getInstance() == null) {
            try {
                SessionData.initInstance(getApplicationContext());
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        super.onCreate(savedInstanceState);

        if (SessionData.getInstance().getToken() == null) {
            skip();
            return;
        }
        else {
            try {
                Commensal log = SessionData.getInstance().getCommensal();

                String emailToWebService;
                try{
                /*    emailToWebService=log.getEmail()+"/";
                    Log.v(TAG,"Email->"+emailToWebService);
                    RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().
                            getLogedCommensalService();
                    logedComensal =getComensal.getLogedCommensal(emailToWebService);
                    Log.v(TAG,logedComensal.getId()+"");
*/
                    emailToWebService=log.getEmail()+"/";
                    Log.v(TAG,"Email->"+emailToWebService);
                    FondaCommandFactory facCmd = FondaCommandFactory.getInstance();

                    Command cmd = facCmd.requireLogedCommensalCommand();

                        cmd.setParameter(0,emailToWebService);
                        cmd.run();

                        logedComensal = (Commensal) cmd.getResult();

                    Log.v(TAG,logedComensal.getId()+"");

                }catch(RestClientException nu){
                    nu.printStackTrace();
                }
                catch(NullPointerException nu){
                    nu.printStackTrace();
                }


                list=(ListView)findViewById(R.id.listViewFavorites);
              /*  FavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                        getFavoriteRestaurantService();

                restaurantList =allFavoriteRestaurant.getAllFavoriteRestaurant(logedComensal.getId());
*/
                FondaCommandFactory facCmd = FondaCommandFactory.getInstance();

                Command cmd = facCmd.allFavoriteRestaurantCommand();


                try {
                    cmd.setParameter(0,logedComensal.getId());
                    cmd.run();

                    restaurantList = (List<Restaurant>) cmd.getResult();


                } catch (Exception e) {
                    e.printStackTrace();
                }


        /*        AllRestaurantService allRestaurant = FondaServiceFactory.getInstance().
                        getAllRestaurantsService();
                restaurantList = allRestaurant.getAllRestaurant();
*/


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







            /**
             * Esto es lo que tenia el Modulo de Favoritos en principio.
             */

         /*
            list = (ListView) findViewById(R.id.listViewFavorites);

            AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                    getAllFavoriteRestaurantsService();
            restaurantList = allFavoriteRestaurant.getAllFavoriteRestaurant(2);
        */
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
        }
    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,LoginActivity.class));
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
                detailActivity.putExtra("commensal", new Gson().toJson(logedComensal));
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
