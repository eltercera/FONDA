package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.FilterByZoneClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.FilterByZoneService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.Zone;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;


/**
 * Clase que implementa el servicio
 */
public class RetrofitFilterByZoneService implements FilterByZoneService {

    /**
     * Se crea el servicio de filtrar por Zona FilterByZoneService
     */
    private FilterByZoneClient filterByZoneClient =
            RetrofitService.getInstance().createService(FilterByZoneClient.class);

    /**
     * Constructor de RetrofitFilterByZoneService
     */
    public RetrofitFilterByZoneService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<Restaurant> getRestaurant(Zone zone) {
        Call<List<Restaurant>> call = filterByZoneClient.getRestaurantFilter(zone);
        List<Restaurant> calling = null;
        try{
            calling = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return calling;
    }


}
