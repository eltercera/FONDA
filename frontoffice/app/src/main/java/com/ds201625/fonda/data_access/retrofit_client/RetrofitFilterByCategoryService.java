package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.FilterByCategoryClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.FilterByCategoryService;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;


/**
 * Clase que implementa el servicio
 */
public class RetrofitFilterByCategoryService implements FilterByCategoryService {

    /**
     * Se crea el servicio de filtrar por Zona FilterByZoneService
     */
    private FilterByCategoryClient filterByCategoryClient =
            RetrofitService.getInstance().createService(FilterByCategoryClient.class);

    /**
     * Constructor de RetrofitFilterByZoneService
     */
    public RetrofitFilterByCategoryService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<Restaurant> getCategoryRestaurant() {
        Call<List<Restaurant>> call = filterByCategoryClient.getRestaurantCategoryFilter();
        List<Restaurant> calling = null;
        try{
            calling = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return calling;
    }


}
