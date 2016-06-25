package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.DetailRestaurantActivityContract;
import com.ds201625.fonda.views.fragments.DetailRestaurantFragment;
import com.ds201625.fonda.views.presenters.DetailRestaurantActivityPresenter;


public class DetailRestaurantActivity extends BaseNavigationActivity
    implements DetailRestaurantActivityContract{

    /*private MenuItem setAsFavorite;
    private MenuItem makeReserve;
    private Toolbar tb;
    private Restaurant selectedRestaurant;
    private TextView tvRestaurantName;
    private String TAG = "DetailRestaurantActivity";
    private Commensal logedCommensal;*/

    /**
     * Componentes de vista
     */
    private View mainContent;
    private MenuItem favoriteMenuItem;
    private MenuItem reserveMenuItem;
    private DetailRestaurantFragment restaurantFragment;
    private Toolbar tb;
    private FragmentManager fm;

    private DetailRestaurantActivityPresenter presenter;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_detail_restaurant);
        super.onCreate(savedInstanceState);

        //obtencion de componentes
        this.mainContent = findViewById(R.id.fragment_container);
        this.tb = (Toolbar)findViewById(R.id.toolbar);
        this.fm = getSupportFragmentManager();
        tb.setVisibility(View.VISIBLE);

        this.presenter = new DetailRestaurantActivityPresenter
                ((Restaurant) getIntent().getSerializableExtra("restaurant"),this);

        this.presenter.onCreate();
        /*setContentView(R.layout.activity_detail_restaurant);
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

        setupDataOfView();*/
    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);

        //obtencion de componenes
        this.favoriteMenuItem = menu.findItem(R.id.action_set_favorite);
        this.reserveMenuItem = menu.findItem(R.id.action_make_order);

        this.favoriteMenuItem.setVisible(true);
        this.reserveMenuItem.setVisible(true);
        return true;

        /*Log.d(TAG,"Esta en onCreateOptionsMenu");
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
                    } catch (DeleteFavoriteRestaurantFondaWebApiControllerException e) {
                        Toast.makeText(getApplicationContext(),
                                "Ha ocurrido un error al eliminar los restaurantes del WS",
                                Toast.LENGTH_LONG).show();
                        Log.e(TAG, "Error Proveniente del WEB SERVICE al eliminar favoritos", e);
                    }
                } else {
                    try{
                    FavoriteRestaurantService addFavoriteRestaurant = FondaServiceFactory.getInstance().
                            getFavoriteRestaurantService();

                    Commensal comensal = addFavoriteRestaurant.AddFavoriteRestaurant(logedCommensal.getId(), selectedRestaurant.getId());

                        Log.v(TAG, comensal.getId() + "");

                    Toast.makeText(getApplicationContext(), R.string.favorite_add_success_meessage,
                            Toast.LENGTH_LONG).show();
                    setAsFavorite.setIcon(R.drawable.ic_star_yellow);
                    } catch (RestClientException e) {
                        e.printStackTrace();
                    } catch (AddFavoriteRestaurantFondaWebApiControllerException e) {
                    Toast.makeText(getApplicationContext(),
                            "Ha ocurrido un error al agregar los restaurantes del WS",
                            Toast.LENGTH_LONG).show();
                    Log.e(TAG, "Error Proveniente del WEB SERVICE al agregar favoritos", e);
                    }catch (Exception e) {
                        Log.e(TAG, "Error Proveniente del WEB SERVICE al agregar favoritos", e);
                        Toast.makeText(getApplicationContext(), R.string.favorite_add_fail_meessage,
                                Toast.LENGTH_LONG).show();

                    }
                }

                return false;
            }

        });
        return true;*/
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                presenter.setFavorite();
                break;

            case R.id.action_make_order:
                presenter.goToReserve();
                break;

            default:

                break;
        }
        return true;
    }

    @Override
    public void setDetailsViewOf(Restaurant restaurant) {
        if (this.restaurantFragment == null)
            this.restaurantFragment = new DetailRestaurantFragment();

        this.restaurantFragment.setRestaurant(restaurant);

        fm.beginTransaction()
            .replace(R.id.fragment_container,this.restaurantFragment)
                .addToBackStack(null)
            .commit();
        fm.executePendingTransactions();

    }



    /*public boolean isFavorite(){
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
    }*/


    /*private Commensal getLogedCommensal(){
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
    }*/

}

