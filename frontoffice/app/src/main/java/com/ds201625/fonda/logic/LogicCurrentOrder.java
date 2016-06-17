package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.entities.DishOrder;

import java.util.List;

/**
 * Created by Katherina Molina on 5/21/2016.
 */

/**
 * clase que controla la logica de la orden actual
 */
public class LogicCurrentOrder {

    /**
     * variable de tipo CurrentOrderService
     */
    private List<DishOrder> listDishOrderService;

    /**
     * Metodo que controla la llamada al ws para obtener la lista de platos ordenados
     * @return orden actual
     */
    public List<DishOrder> getCurrentOrderSW() throws RestClientException {

        try {
        listDishOrderService = FondaServiceFactory.getInstance().getCurrentOrderService().getListDishOrder();

        } catch (RestClientException e) {
            throw new RestClientException("Error de IO", e);
        }

        return listDishOrderService;
    }

}
