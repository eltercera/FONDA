package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Reservation;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.DELETE;
import retrofit2.http.PUT;
import retrofit2.http.Path;

/**
 * Created by Jessica on 22/05/16.
 */
public interface ReservationClient {

    /**
     * Get /api/profiles
     * Obtiene la lista de las reservaciones.
     *
     * @return
     */

    @GET("reservation")
    Call<List<Reservation>> getReservation();

    /**
     * Post /api/profile
     * Genera y agrega una reservacion
     * @param reservation Reservation a agregar
     * @return
     */
/*    @POST("reservation")
    Call<Reservation> postReservation(@Body Reservation reservation);

    */

    /**
     * Delete /api/profile/{id}
     * Elimina un profile
     *
     * @param id identificador del profile.
     * @return
     */
    @DELETE("reservation/{id}")
    Call<String> deleteReservation(@Path("id") int id);

}