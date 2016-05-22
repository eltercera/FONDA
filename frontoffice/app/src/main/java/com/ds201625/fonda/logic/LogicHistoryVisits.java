package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;

/**
 * Created by Adri on 5/21/2016.
 */

/**
 * clase que controla la logica del historial de pagos de un restaurant
 */
public class LogicHistoryVisits {

    /**
     * variable de tipo HistoryVisitsRestaurantService
     */
    private HistoryVisitsRestaurantService histoyVisitsRestaurantService;

    /**
     * Metodo que controla la llamada al ws para el manejo de pagos del restaurant
     * @return historial de visitas
     */
    public HistoryVisitsRestaurantService algo (){
        histoyVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService();
        return histoyVisitsRestaurantService;
    }

}
