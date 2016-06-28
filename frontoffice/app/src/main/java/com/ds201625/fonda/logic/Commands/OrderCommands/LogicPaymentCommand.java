package com.ds201625.fonda.logic.Commands.OrderCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicPaymentWebApiControllerException;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;

/**
 * Created by Jessica on 22/6/2016.
 */
public class LogicPaymentCommand extends BaseCommand{
    private String TAG = "LogicPaymentCommand";

    /**
     * variable de tipo PaymentService
     */
    private Invoice payment;
    private Invoice pay;
    private Restaurant idRestaurant;
    private DishOrder idOrder;
    private Profile idProfile;
    private Payment payment_;

    /**
     * Asigna valor a los parametros
     * @return parametro comensal
     */
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[4];
        parameters[0] = new Parameter(Restaurant.class, true);
        parameters[1] = new Parameter(DishOrder.class, true);
        parameters[2] = new Parameter(Profile.class,true);
        parameters[3] = new Parameter(Payment.class,true);

        return parameters;
    }

    /**
     * Metodo que controla la llamada al ws para el manejo de facturas
     * @param
     * @return
     * @throws RestClientException
     * @throws InvalidDataRetrofitException
     */
    @Override
    protected void invoke() throws LogicPaymentWebApiControllerException {
        Log.d(TAG, "Comando para realizar el pago");
        PaymentService paymentService = FondaServiceFactory.getInstance().setPaymentService();
        idRestaurant = FondaEntityFactory.getInstance().GetRestaurant();
        try {
            idRestaurant = (Restaurant) getParameter(0);
            idOrder = (DishOrder) getParameter(1);
            idProfile = (Profile) getParameter(2);
            payment_ = (Payment) getParameter(3);

            payment = paymentService.setPayments(idRestaurant.getId(), idOrder.getId(), idProfile.getId(), payment_);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicPaymentWebApiControllerException(e);
        }catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicPaymentWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicPaymentWebApiControllerException(e);
        }
        setResult(payment);
    }
}
