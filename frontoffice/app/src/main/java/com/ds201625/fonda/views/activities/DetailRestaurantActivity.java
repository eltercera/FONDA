package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.SessionData;
import com.google.gson.Gson;

import java.util.List;

/**
 * Created by jesus on 20/04/16.
 */
public class DetailRestaurantActivity extends BaseNavigationActivity{

    //Declaracion de varialbes globales de la clase

    private MenuItem setAsFavorite;
    private MenuItem makeReserve;
    private Toolbar tb;
    private Restaurant selectedRestaurant;
    private TextView tvRestaurantName;
    private String TAG = "DetailRestaurantActivity";
    private Commensal logedCommensal;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_detail_restaurant);
        super.onCreate(savedInstanceState);
        String jsonMyObject = null;
        String jsonMyOtherObject = null;
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            jsonMyObject = extras.getString("restaurant");
            jsonMyOtherObject = extras.getString("commensal");
        }
        try{
            selectedRestaurant = new Gson().fromJson(jsonMyObject, Restaurant.class);
            logedCommensal= new Gson().fromJson(jsonMyOtherObject, Commensal.class);
            Log.v(TAG, logedCommensal.getId() + "");
            Log.v(TAG, selectedRestaurant.getName());
        }catch (Exception e){
            e.printStackTrace();
        }



        tvRestaurantName = (TextView)findViewById(R.id.text_view_restaurant_name);

        setupDataOfView();
    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        Log.d(TAG,"ESTAAAAAAAASSSS EEENNN onCreateOptionsMenu");
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);
        makeReserve = menu.findItem(R.id.action_make_order);

        setAsFavorite = menu.findItem(R.id.action_set_favorite);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

       makeReserve.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {
                Intent cambio = new Intent(DetailRestaurantActivity.this, DetailRestaurantActivity.class);
                cambio.putExtra("restaurant", new Gson().toJson(selectedRestaurant));
                startActivity(cambio);

                return false;
            }
        });


        if (isFavorite()){
            setAsFavorite.setIcon(R.drawable.ic_star_yellow);
        }else {
            setAsFavorite.setIcon(R.drawable.ic_star_border_creme_24dp);
        }

        setAsFavorite.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {


                if (isFavorite()) {
                    try{
                        FavoriteRestaurantService deleteFavorite = FondaServiceFactory.getInstance().getFavoriteRestaurantService();
                    Commensal comensal = deleteFavorite.deleteFavoriteRestaurant(logedCommensal.getId()
                            , selectedRestaurant.getId());

                    try {
                        Log.v(TAG, comensal.getId() + "");
                    } catch (Exception e) {
                        e.printStackTrace();
                        Toast.makeText(getApplicationContext(), R.string.favorite_remove_fail_meessage,
                                Toast.LENGTH_LONG).show();

                    }
                    Toast.makeText(getApplicationContext(), R.string.favorite_remove_success_meessage,
                            Toast.LENGTH_LONG).show();
                    setAsFavorite.setIcon(R.drawable.ic_star_border_creme_24dp);
                    } catch (RestClientException e) {
                        e.printStackTrace();
                    }
                } else {
                    try{
                    FavoriteRestaurantService addFavoriteRestaurant = FondaServiceFactory.getInstance().
                            getFavoriteRestaurantService();

                    Commensal comensal = addFavoriteRestaurant.AddFavoriteRestaurant(logedCommensal.getId(), selectedRestaurant.getId());


                    try {
                        Log.v(TAG, comensal.getId() + "");
                    } catch (Exception e) {
                        e.printStackTrace();
                        Toast.makeText(getApplicationContext(), R.string.favorite_add_fail_meessage,
                                Toast.LENGTH_LONG).show();

                    }
                    Toast.makeText(getApplicationContext(), R.string.favorite_add_success_meessage,
                            Toast.LENGTH_LONG).show();
                    setAsFavorite.setIcon(R.drawable.ic_star_yellow);
                    } catch (RestClientException e) {
                        e.printStackTrace();
                    }
                }

                return false;
            }

        });
        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                break;
        }
        return true;
    }

    /**
     * Le asigna los valores del restaurante seleccionado a la vista..
     * @param
     * @return
     */
    private void setupDataOfView(){

        try {
            tvRestaurantName.setText(selectedRestaurant.getName());
        }catch (NullPointerException e){
            e.printStackTrace();
        }
    };

    /**
     * Devuelve el estado del restaurante seleccionado (si es favorito) con respecto al usuario.
     * @param
     * @return Boolean.
     */
    public boolean isFavorite(){
    try{
        FavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                getFavoriteRestaurantService();
        List<Restaurant> restaurantList = allFavoriteRestaurant.getAllFavoriteRestaurant(logedCommensal.getId());

        for(Restaurant restaurant : restaurantList){
            if (restaurant.getId() == selectedRestaurant.getId()){
                return true;
            }
        }
    } catch (RestClientException e) {
        e.printStackTrace();
    } catch (Exception e) {
        e.printStackTrace();
    }
        return false;
    }


    /**
     * Devuelve el Commensal logeado.
     * @param
     * @return Commensal.
     */
    private Commensal getLogedCommensal(){
        Commensal log= SessionData.getInstance().getCommensal();
        String emailToWebService;
        Commensal toReturn = null;
        try{
            emailToWebService=log.getEmail()+"/";
            RequireLogedCommensalService getComensal = FondaServiceFactory.getInstance().
                    getLogedCommensalService();

            toReturn =getComensal.getLogedCommensal(emailToWebService);
            Log.v(TAG,toReturn.getId()+"");


        } catch (RestClientException e) {
            e.printStackTrace();
        }
        catch(NullPointerException nu){
            nu.printStackTrace();
            Toast.makeText(getApplicationContext(), R.string.favorite_conexion_fail_message,
                    Toast.LENGTH_LONG).show();

        }
        return toReturn;
    }

    private void CallReserveActivity(){

    }
}
