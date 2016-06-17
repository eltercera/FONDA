package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.entities.Profile;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.Path;

/**
 * Interfaz para ser implementada por retrofit
 * Define los recursos de /api/profile(s) del
 * servicio web REST
 */
public interface ProfileClient {

    /**
     * Get /api/profiles
     * Obtiene la lista de los pefiles.
     * @return
     */
    @GET("profiles")
    Call<List<Profile>> getProfiles();

    /**
     * Post /api/profile
     * Genera y agrega un profile
     * @param profile Profile a agregar
     * @return
     */
    @POST("profile")
    Call<Profile> postProfile(@Body Profile profile);

    /**
     * Put /api/profile/{id}
     * Modificacion de un profile
     * @param profile Profile a modificar
     * @param id Identificacdor del profile.
     * @return
     */
    @PUT("profile/{id}")
    Call<Profile> putProfile(@Body Profile profile, @Path("id") int id);

    /**
     * Delete /api/profile/{id}
     * Elimina un profile
     * @param id identificador del profile.
     * @return
     */
    @DELETE("profile/{id}")
    Call<String> DeleteProfile(@Path("id") int id);


}
