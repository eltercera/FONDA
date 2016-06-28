package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.PaymentClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicPaymentWebApiControllerException;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;

import retrofit2.Call;
import retrofit2.Response;


/**
 * Implementacion de la interfaz
 */
public class RetrofitPaymentService implements PaymentService {

    /**
     * Instancia rest del cliente PaymentCLient
     */
    private PaymentClient paymentClient = RetrofitService.getInstance().createService(PaymentClient.class);
    private String TAG = "RetrofitHistoryVisitsService";
    private APIError error;

    /**
     * Constructor de RetrofitCurrentOrderService
     */
    public RetrofitPaymentService() {
        super();
    }

    /**
     * Envia el pago para hacer la factura
     * @return
     * @throws com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicPaymentWebApiControllerException
     */

    @Override
    public Invoice setPayments(int idRestaurant, int idOrder, int idProfile, Payment payment)
            throws LogicPaymentWebApiControllerException {

        Call<Invoice> call = paymentClient.setPayments(idRestaurant,idOrder,idProfile,payment);
        Invoice test = null;
        Response<Invoice> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                test = response.body();
            } else {
                error = ErrorUtils.parseError(response);
                Log.d(TAG, "Se obtiene la excepcion del WS");
                // usar error para disparar exception
                Log.e(TAG, "error message " + error.message());
                Log.e(TAG, "error message " + error.exceptionType());

                throw new LogicPaymentWebApiControllerException
                        (error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant1", e);
            throw new LogicPaymentWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant2", e);
            throw new LogicPaymentWebApiControllerException(error.exceptionType());
        }

        return test;
    }
}


