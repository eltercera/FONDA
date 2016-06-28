package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.InvoiceClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicInvoiceWebApiControllerException;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;

import retrofit2.Call;
import retrofit2.Response;

/**
 * Created by Jessica on 21/06/2016.
 */

/**
 * Clase que implementa el servicio
 */
public class RetrofitInvoiceService implements InvoiceService {

    /**
     * InvoiceClient que crea el servicio
     */
    private InvoiceClient invoiceClient =
            RetrofitService.getInstance().createService(InvoiceClient.class);
    private String TAG = "RetrofitInvoiceService";
    private APIError error;

    /**
     * Constructor de RetrofitInvoiceService
     */
    public RetrofitInvoiceService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     *
     * @return llamada
     */
    @Override
    public Invoice getCurrentInvoice(int idProfile) throws LogicInvoiceWebApiControllerException {
        Log.d(TAG, "Se obtiene factura de " + idProfile);
        //  Call<List<Invoice>> call = historyVisitsClient.getHistoryVisits(idProfile);
        Call<Invoice> call = invoiceClient.getCurrentInvoice(idProfile);
        Invoice test = null;
        Response<Invoice> response;
        try {
            response = call.execute();
            if (response.isSuccessful()) {
                test = response.body();
            } else {
                error = ErrorUtils.parseError(response);
                Log.d(TAG, "Se obtiene la excepcion del WS");
                // usar error para disparar exception
                Log.e(TAG, "error message " + error.message());
                Log.e(TAG, "error message " + error.exceptionType());
                throw new LogicInvoiceWebApiControllerException
                        (error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant1", e);
            throw new LogicInvoiceWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant2", e);
            throw new LogicInvoiceWebApiControllerException(error.exceptionType());
        }
        return test;
    }
}
