package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.HistoryVisitsClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by Adriana on 5/7/16.
 */

/**
 * Clase que implementa el servicio
 */
public class RetrofitHistoryVisitsService implements HistoryVisitsRestaurantService {

    private HistoryVisitsClient historyVisitsClient =
            RetrofitService.getInstance().createService(HistoryVisitsClient.class);

    public RetrofitHistoryVisitsService() {
        super();
    }

    @Override
    public List<Invoice> getHistoryVisits() {
        Call<List<Invoice>> call = historyVisitsClient.getHistoryVisits();
        List<Invoice> calling = null;
        try{
            calling = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return calling;
    }


}
