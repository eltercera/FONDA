package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.DishOrder;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by Jessica on 21/06/2016.
 */

/**
 * Interface que contiene los metodos del servicio de CurrentOrderClient
 */
public interface CurrentOrderClient {


    /**
     * Get /api/listDishOrder
     * Obtiene la lista de los platos ordenados.
     * @return
     */
    @GET("GetOrderDetail")
    Call<List<DishOrder>> getListDishOrder();

}