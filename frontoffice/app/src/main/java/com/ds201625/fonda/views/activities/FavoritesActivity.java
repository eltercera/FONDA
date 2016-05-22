package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.logic.SessionData;

public class FavoritesActivity extends BaseNavigationActivity {
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
            });
        }

    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,LoginActivity.class));
    }
}
