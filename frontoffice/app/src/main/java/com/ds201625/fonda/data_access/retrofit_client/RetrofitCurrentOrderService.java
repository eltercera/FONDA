package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.CurrentOrderClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.DishOrder;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by Jessica on 20/06/2016.
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
    public List<DishOrder> getListDishOrder(int idRestaurante, int idOrden) throws RestClientException {
        Call<List<DishOrder>> call = currentOrderClient.getListDishOrder();
        List<DishOrder> listDishOrder = null;
        try{
            listDishOrder = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }

        return listDishOrder;
    }

//    @Override
//    public List<DishOrder> getListDishOrder(int idRestaurante, int idOrden) throws RestClientException {
//        return null;
//    }
}
