package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.clients.ZoneClient;
import com.ds201625.fonda.data_access.services.ZoneService;
import com.ds201625.fonda.domains.entities.Zone;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;


/**
 * Clase que implementa el servicio
 */
public class RetrofitZoneService implements ZoneService {

    /**
     * Se crea el servicio de Zona
     */
    private ZoneClient zoneClient =
            RetrofitService.getInstance().createService(ZoneClient.class);

    /**
     * Constructor de RetrofitZoneService
     */
    public RetrofitZoneService() {
        super();
    }

    /**
     * Metodo que hace la llamada al servicio
     * @return llamada
     */
    @Override
    public List<Zone> getZone() {
        Call<List<Zone>> call = zoneClient.getZoneFilter();
        List<Zone> calling = null;
        try{
            calling = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        return calling;
    }


}
