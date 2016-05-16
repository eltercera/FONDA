package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by Yuneth on 5/15/2016.
 */
public interface CurrentOrderClient {

    @GET("listDishOrder")
    Call<List<DishOrder>> getListDishOrder();

}
