package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.widget.ListView;

import com.ds201625.fonda.R;

public class RestaurantListActivity extends BaseActivity {

    ListView list;
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
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_restaurants);
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
