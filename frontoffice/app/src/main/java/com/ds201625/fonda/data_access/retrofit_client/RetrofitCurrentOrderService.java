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
 * Created by rrodriguez on 5/7/16.
 */
public class RetrofitCurrentOrderService implements CurrentOrderService {

    private CurrentOrderClient currentOrderClient =
            RetrofitService.getInstance().createService(CurrentOrderClient.class);

    public RetrofitCurrentOrderService() {
        super();
    }

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
