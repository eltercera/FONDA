package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;

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
    private CurrentOrderService currentOrderService;

    /**
     * Metodo que controla la llamada al ws para obtener la lista de platos ordenados
     * @return orden actual
     */
    public CurrentOrderService getCurrentOrderSW(){

        currentOrderService = FondaServiceFactory.getInstance().getCurrentOrderService();
        return currentOrderService;

    }

}
