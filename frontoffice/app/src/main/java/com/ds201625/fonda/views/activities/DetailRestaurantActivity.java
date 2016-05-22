package com.ds201625.fonda.views.activities;

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
import com.ds201625.fonda.data_access.services.AddFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.DeleteFavoriteRestaurantService;
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
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            jsonMyObject = extras.getString("restaurant");
        }
        selectedRestaurant = new Gson().fromJson(jsonMyObject, Restaurant.class);
        try{
            Log.v(TAG, selectedRestaurant.getName());
        }catch (Exception e){
            e.printStackTrace();
        }

       // logedCommensal= getLogedCommensal();


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
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);

        setAsFavorite = menu.findItem(R.id.action_favorite_save);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        setAsFavorite = menu.findItem(R.id.action_set_favorite);


        if (isFavorite()){
            setAsFavorite.setIcon(R.drawable.ic_star_yellow);
        }else {
            setAsFavorite.setIcon(R.drawable.ic_full_star_24dp);
        }
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        setAsFavorite.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {


                if (isFavorite()) {

                    DeleteFavoriteRestaurantService deleteFavoriteRestaurantServ = FondaServiceFactory.getInstance().
                            getDeleteFavoriteRestaurantService();
                    Commensal comensal = deleteFavoriteRestaurantServ.deleteFavoriteRestaurant(9
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
                    setAsFavorite.setIcon(R.drawable.ic_full_star_24dp);
                } else {

                    AddFavoriteRestaurantService addFavoriteRestaurant = FondaServiceFactory.getInstance().
                            getAddFavortieRestaurantService();

                    Commensal comensal = addFavoriteRestaurant.AddFavoriteRestaurant(9, selectedRestaurant.getId());

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
    private boolean isFavorite(){

        AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                getAllFavoriteRestaurantsService();
        List<Restaurant> restaurantList = allFavoriteRestaurant.getAllFavoriteRestaurant(9);

        for(Restaurant restaurant : restaurantList){
            if (restaurant.getId() == selectedRestaurant.getId()){
                return true;
            }
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


        }catch(NullPointerException nu){
            nu.printStackTrace();
            Toast.makeText(getApplicationContext(), R.string.favorite_conexion_fail_message,
                    Toast.LENGTH_LONG).show();

        }
        return toReturn;
    }
}
