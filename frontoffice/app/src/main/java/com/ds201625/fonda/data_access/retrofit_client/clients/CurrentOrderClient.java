package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by rrodriguez on 5/7/16.
 */
public interface CurrentOrderClient {

    @GET("ListDishOrder")
    Call<List<DishOrder>> getListDishOrder();

}
