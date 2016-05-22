package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.Invoice;

import java.util.List;

import retrofit2.Call;

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
    private List<Invoice> listVisitsRestaurantService;

    /**
     * Metodo que controla la llamada al ws para el manejo de pagos del restaurant
     *
     * @return historial de visitas
     */
    public List<Invoice> apihistoryVisits() throws RestClientException {

        try {
            listVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService().getHistoryVisits();
        } catch (RestClientException e) {
            throw new RestClientException("Error de IO", e);
        }

        return listVisitsRestaurantService;
    }
}