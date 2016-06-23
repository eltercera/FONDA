package com.ds201625.fonda.logic.Commands.OrderCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Created by Jessica on 22/6/2016.
 */
public class LogicPaymentCommand {
/*    private String TAG = "LogicPaymentCommand";
    *//**
     * variable de tipo PaymentService
     *//*
    private Invoice payment;
    private Restaurant idRestaurant;
    private DishOrder idOrder;
    private Profile idProfile;


    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[4];
        parameters[0] = new Parameter(Restaurant.class, true);
        parameters[1] = new Parameter(DishOrder.class, true);
        parameters[2] = new Parameter(Profile.class,true);
        parameters[3] = new Parameter(Invoice.class,true);

        return parameters;
    }
    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para realizar el pago");

        try {
            payment = FondaServiceFactory.getInstance().setPaymentService().setPayments(invoice);
        } catch (RestClientException e) {
            throw new RestClientException("Error de IO",e);
        } catch (InvalidDataRetrofitException e) {
            throw new InvalidDataRetrofitException("Invoice es nulo.");
        }
        return payment;

    }*/
}
