package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicHistoryVisitsWebApiControllerException;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;

import java.util.List;

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

    private Profile idProfile;

    /**
     * Metodo que controla la llamada al ws para el manejo de pagos del restaurant
     *
     * @return historial de visitas
     */
    public List<Invoice> apihistoryVisits() throws RestClientException {

        try {
            listVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService().getHistoryVisits(idProfile.getId());
        } catch (RestClientException e) {
            throw new RestClientException("Error de IO", e);
        } catch (LogicHistoryVisitsWebApiControllerException e) {
            e.printStackTrace();
        }
        catch (Exception e ){
            e.printStackTrace();
        }

        return listVisitsRestaurantService;
    }
}