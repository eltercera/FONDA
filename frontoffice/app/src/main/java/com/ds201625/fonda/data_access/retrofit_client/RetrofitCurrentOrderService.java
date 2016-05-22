package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.CurrentOrderClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Profile;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by Yuneth on 5/15/2016.
 */

/**
 * Clase que implementa el servicio
 */
public class RetrofitCurrentOrderService implements CurrentOrderService {

    /**
     * CurrentOrderClient que crea el servicio
     */
    private CurrentOrderClient currentOrderClient =
            RetrofitService.getInstance().createService(CurrentOrderClient.class);

    /**
     * Constructor de RetrofitCurrentOrderService
     */
    public RetrofitCurrentOrderService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<DishOrder> getListDishOrder() {
        Call<List<DishOrder>> call = currentOrderClient.getListDishOrder();
        List<DishOrder> a = null;
        try{
            a = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return a;
    }
}
