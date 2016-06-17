package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.entities.Zone;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

/**
 * Interfaz para los metodos del servicio de ZoneClient
 */
public interface ZoneClient {

    @GET("zoneFilter")
    Call<List<Zone>> getZoneFilter();


}
