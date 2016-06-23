package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Invoice;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Created by Jessica 21/06/16.
 */

/**
 * Interface que contiene los metodos del servicio de HistoryVisitsClient
 */
public interface HistoryVisitsClient {

    /**
     * Obtiene la lista del historial de visitas o pagos a restaurant
     * @return
     */
    @GET("GetPaymentHistory")
    Call<List<Invoice>> getHistoryVisits();
}
