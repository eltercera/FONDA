package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Invoice;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Created by Jessica on 20/06/2016.
 */

/**
 * Interface que contiene los metodos del servicio de InvoiceClient
 */
public interface InvoiceClient {


    /**
     * Get /api/currentInvoice
     * Obtiene la factura de la cuenta cerrada
     * @return
     */
    @GET("currentInvoice/{id}")
    Call<Invoice> getCurrentInvoice(@Path("id") int idProfile);

}
