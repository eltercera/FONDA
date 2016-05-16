package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.InvoiceClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.Invoice;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by Yuneth on 5/15/2016.
 */
public class RetrofitInvoiceService implements InvoiceService {

    private InvoiceClient invoiceClient =
            RetrofitService.getInstance().createService(InvoiceClient.class);

    public RetrofitInvoiceService() {
        super();
    }

    @Override
    public Invoice getInvoice() {
        Call<Invoice> call = invoiceClient.getInvoice();
        Invoice a = null;
        try{
            a = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return a;
    }
}
