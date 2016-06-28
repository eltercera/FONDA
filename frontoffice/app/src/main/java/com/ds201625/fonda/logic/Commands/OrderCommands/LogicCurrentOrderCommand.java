package com.ds201625.fonda.logic.Commands.OrderCommands;

/**
 * Created by Jessica on 20/6/2016.
 */

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicCurrentOrderFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;

import java.util.List;

/**
 * Comando que controla la logica de la orden actual
 */
public class LogicCurrentOrderCommand extends BaseCommand {
    private String TAG = "LogicCurrentOrderCommand";
    /**
     * variable de tipo CurrentOrderService
     */
    private List<DishOrder> listDishOrderService;

    private Restaurant idRestaurant;
    private DishOrder idOrder;
    /**
     * Asigna valor a los parametros
     * @return parametro comensal
     */
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Restaurant.class, true);
        parameters[1] = new Parameter(DishOrder.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para mostrar la orden actual
     */
    @Override
    protected void invoke() throws LogicCurrentOrderFondaWebApiControllerException{

        Log.d(TAG, "Comando para ver la orden actual");
        CurrentOrderService serviceCurrentOrder = FondaServiceFactory.getInstance().getCurrentOrderService();

        idRestaurant = FondaEntityFactory.getInstance().GetRestaurant();

        try {
            idRestaurant = (Restaurant) getParameter(0);
            idOrder = (DishOrder) getParameter(1);

            listDishOrderService = serviceCurrentOrder.getListDishOrder(idRestaurant.getId(), idOrder.getId());
        }catch (LogicCurrentOrderFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado un error obteniendo la orden actual", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(e);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la orden actual", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la orden actual", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado un error obteniendo la orden actual", e);
            throw new LogicCurrentOrderFondaWebApiControllerException(e);
        }
    setResult(listDishOrderService);
    }
}