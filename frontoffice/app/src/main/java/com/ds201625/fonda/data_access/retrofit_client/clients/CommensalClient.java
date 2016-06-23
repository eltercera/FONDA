package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Interfaz para ser implementada por retrofit
 * Define los recursos de /api/commensal del
 * servicio web REST
 */
public interface CommensalClient {

    /**
     * Post /api/commensal
     * Registro de un commensal.
     * @param commensal Commansal a registrar
     * @return
     */
    @POST("commensal")
    Call<Commensal> registerCommensal(@Body Commensal commensal);

}
