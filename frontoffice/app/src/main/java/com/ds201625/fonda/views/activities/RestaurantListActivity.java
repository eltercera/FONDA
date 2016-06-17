package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.services.FilterByZoneService;
import com.ds201625.fonda.domains.entities.Restaurant;
import com.ds201625.fonda.domains.entities.Zone;
import com.google.gson.Gson;

import java.util.Iterator;
import java.util.List;

public class RestaurantListActivity extends BaseActivity {

    private RestaurantList adapter;
    private ListView list;
    /**
     * Lista para guardar los restaurantes ya filtrados
     */
    private List<Restaurant> restaurantList;
    /**
     * Selección de la zona del fragmento anterior
     */
    private Zone selectedZone;
    /**
     * Servicio para filtrar por zona
     */
    private FilterByZoneService filterByZoneService;
    /**
     * Iterador
     */
    private Iterator iterator;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_restaurants);
        list=(ListView)findViewById(R.id.listViewRestaurants);

        String jsonMyObject = null;
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            jsonMyObject = extras.getString("zona");
        }
        selectedZone = new Gson().fromJson(jsonMyObject, Zone.class);
        System.out.println("LA ZONAA: "+selectedZone.getName());
       /* try{

            filterByZoneService = FondaServiceFactory.getInstance().getFilterByZoneService();
            restaurantList = filterByZoneService.getRestaurant(selectedZone);
            iterator = restaurantList.listIterator();

            while (iterator.hasNext()) {
                Restaurant restaurant = (Restaurant) iterator.next();
                String nameRestaurant = restaurant.getName();

            }
            
           // Log.v("DETAIL", selectedZone.getName());
        }catch (Exception e){
            e.printStackTrace();
        }*/

      /*  if (extras.getString("zona").equals("zona")){
        }*/


       /* AllRestaurantService allRestaurant = FondaServiceFactory.getInstance().
                getAllRestaurantsService();
        restaurantList = allRestaurant.getAllRestaurant();*/
/*
        RestaurantList adapter = new
                RestaurantList(RestaurantListActivity.this, names,location ,shortDescription,imageId);
        list=(ListView)findViewById(R.id.listViewRest);
        list.setAdapter(adapter);
*/
        /*list.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                Toast.makeText(RestaurantListActivity.this, "You Clicked at " + names[+position], Toast.LENGTH_SHORT).show();
                Intent cambio = new Intent (RestaurantListActivity.this,DetailRestaurantActivity.class);
                String nombreRest = names[+position];
                String descriptionRest = shortDescription[+position];
                String locationRest = location[+position];
                Integer imageRest = imageId[+position];
                cambio.putExtra("NOMBRE",nombreRest);
                cambio.putExtra("LOCATION",locationRest);
                cambio.putExtra("DESCRIPTION",descriptionRest);
                cambio.putExtra("IMAGE",imageRest);
                startActivity(cambio);

            }
        });*/
    }
}
