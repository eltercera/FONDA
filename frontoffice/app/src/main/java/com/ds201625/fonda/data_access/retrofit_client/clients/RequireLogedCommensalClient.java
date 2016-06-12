package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Interfaz para ser implementada por retrofit
 * Define los recursos de /api/findCommensalEmail del
 * servicio web REST
 */
public interface RequireLogedCommensalClient {

    /**
     * Get /api/findCommensalEmail/{email}
     * Obtiene el comensal logueado.
     *  @param email del usuario
     * @return
     */
    @GET("findCommensalEmail/{email}")
    Call<Commensal> getAllFavoriteRestaurant(@Path("email") String email);

}
