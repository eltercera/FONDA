package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.AddFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.DeleteFavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.google.gson.Gson;

import java.util.List;

/**
 * Created by jesus on 20/04/16.
 */
public class DetailRestaurantActivity extends BaseNavigationActivity{

    //Variables Declaration
    private MenuItem setAsFavorite;
    private Toolbar tb;
    private Restaurant selectedRestaurant;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_detail_restaurant);
        super.onCreate(savedInstanceState);
        String jsonMyObject = null;
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            jsonMyObject = extras.getString("restaurante");
        }
        selectedRestaurant = new Gson().fromJson(jsonMyObject, Restaurant.class);
        try{
            Log.v("DETAIL", selectedRestaurant.getName());
        }catch (Exception e){
            e.printStackTrace();
            //hubo un fallo al acceder al restaurante.
        }

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

        Log.v("detail","creandomenuoption con"+selectedRestaurant.getName());

        if (isFavorite()){
            setAsFavorite.setIcon(R.drawable.ic_clear_creme_24dp);
        }else {
            setAsFavorite.setIcon(R.drawable.ic_add_creme_24dp);
        }
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        setAsFavorite.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {


                if (isFavorite()){

                    DeleteFavoriteRestaurantService deleteFavoriteRestaurantServ = FondaServiceFactory.getInstance().
                            getDeleteFavoriteRestaurantService();
                    Commensal comensal = deleteFavoriteRestaurantServ.deleteFavoriteRestaurant(2, selectedRestaurant.getId());

                    try {
                        Log.v("WEBSERVICE", comensal.getId() + "");
                    } catch (Exception e) {
                        e.printStackTrace();
                    }

                }else{

                    AddFavoriteRestaurantService addFavoriteRestaurant = FondaServiceFactory.getInstance().
                            getAddFavortieRestaurantService();

                    Commensal comensal = addFavoriteRestaurant.AddFavoriteRestaurant(2, selectedRestaurant.getId());

                    try {
                        Log.v("WEBSERVICE", comensal.getId() + "");
                    } catch (Exception e) {
                        e.printStackTrace();
                    }

                }

                /*
                MALO
                DeleteFavoriteRestaurantService removeFavoriteRestaurant = FondaServiceFactory.getInstance().
                        getRemoveFavoriteRestaurantService();

                Commensal comensal = removeFavoriteRestaurant.RemoveFavoriteRestaurant(2, selectedRestaurant.getId());
                */
         /*       try {
                    Log.v("WEBSERVICE", comensal.getId() + "");
                } catch (Exception ex) {
                    ex.printStackTrace();
                    Log.v("WEBSERVICE", "ERRROROOOOOOOOOOOOOOOOOOOOOOOOOR");
                }
           */     /*
                Log.v("CLICK", "le di clicksito");
                //if (isFavorite()){
                Log.v("WEBSERVICE", "Entrando en Is Favorite");
                Log.v("WEBSERVICE", "EL ID DEL RESTAURANTE ES: " + selectedRestaurant.getId());

                DeleteFavoriteRestaurantService removeFavoriteRestaurant = FondaServiceFactory.getInstance().
                        getRemoveFavoriteRestaurantService();
                Commensal comensal = removeFavoriteRestaurant.RemoveFavoriteRestaurant(2,1);
                try {

                    Log.v("WEBSERVICE", "EL WEBSERVICE RESPONDIO");
                    Log.v("WEBSERVICE", comensal.getId() + "");

                } catch (Exception e) {
                    e.printStackTrace();
                }
                */
            /*
            }else{
                    Log.v("WEBSERVICE","Entrando en Is NOT Favorite");
*/
            /*    AddFavoriteRestaurantService addFavoriteRestaurant = FondaServiceFactory.getInstance().
                        getAddFavortieRestaurantService();

                Commensal comensal = addFavoriteRestaurant.AddFavoriteRestaurant(1, selectedRestaurant.getId());

                try {
                    Log.v("WEBSERVICE", comensal.getId() + "");
                } catch (Exception e) {
                    e.printStackTrace();
                }*/
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

    private boolean isFavorite(){

        AllFavoriteRestaurantService allFavoriteRestaurant = FondaServiceFactory.getInstance().
                getAllFavoriteRestaurantsService();
        List<Restaurant> restaurantList = allFavoriteRestaurant.getAllFavoriteRestaurant(2);

        for(Restaurant restaurant : restaurantList){
            if (restaurant.getId() == selectedRestaurant.getId()){
                return true;
            }
        }

        return false;
    }

}
