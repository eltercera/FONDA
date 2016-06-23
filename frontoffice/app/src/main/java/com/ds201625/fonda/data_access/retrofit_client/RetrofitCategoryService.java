package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.CategoryClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.CategoryService;
import com.ds201625.fonda.domains.RestaurantCategory;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;


/**
 * Clase que implementa el servicio
 */
public class RetrofitCategoryService implements CategoryService {

    /**
     * Se crea el servicio de RestaurantCategory
     */
    private CategoryClient categoryClient =
            RetrofitService.getInstance().createService(CategoryClient.class);

    /**
     * Constructor de RetrofitCategoryService
     */
    public RetrofitCategoryService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<RestaurantCategory> getRestaurantCategory() {
        Call<List<RestaurantCategory>> call = categoryClient.getCategoryFilter();
        List<RestaurantCategory> calling = null;
        try{
            calling = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return calling;
    }


}
