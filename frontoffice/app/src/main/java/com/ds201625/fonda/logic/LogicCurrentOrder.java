package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicCurrentOrderFondaWebApiControllerException;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Restaurant;

import java.util.List;

/**
 * Created by Jessica on 21/06/2016.
 */

/**
 * clase que controla la logica de la orden actual
 */
public class LogicCurrentOrder {

    /**
     * variable de tipo CurrentOrderService
     */
    private List<DishOrder> listDishOrderService;
    Restaurant idRestaurant;
    DishOrder idOrder;

    /**
     * Metodo que controla la llamada al ws para obtener la lista de platos ordenados
     * @return orden actual
     */
    public List<DishOrder> getCurrentOrderSW() throws RestClientException {

        try {
        listDishOrderService = FondaServiceFactory.getInstance().getCurrentOrderService().getListDishOrder(idRestaurant.getId(), idOrder.getId());

        } catch (RestClientException e) {
            throw new RestClientException("Error de IO", e);
        }
        catch (LogicCurrentOrderFondaWebApiControllerException e) {

        }
        catch (Exception e) {
            e.printStackTrace();
        }

        return listDishOrderService;
    }

}
