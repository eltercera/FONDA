package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.InvoiceClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.Invoice;

import java.io.IOException;

import retrofit2.Call;

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

    /**
     * Constructor de RetrofitInvoiceService
     */
    public RetrofitInvoiceService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public Invoice getCurrentInvoice(int idProfile) throws RestClientException {
        Call<Invoice> call = invoiceClient.getCurrentInvoice();
        Invoice invoiceNew = null;
        try{
            invoiceNew = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }

        return invoiceNew;
    }
}
