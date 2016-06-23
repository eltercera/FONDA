package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.DELETE;
import retrofit2.http.Path;


public interface ReservationClient {



    /**
     * Add /api/addreservation/{idcommensal}/{idrestaurant}
     * Agrega una reserva de la lista de comensales
     * @param idCommensal identificador del comensal.
     * @param idRestaurant identificador del restaurante.
     * @return
     */
    @GET("addreservation/{idcommensal}/{idrestaurant}")
    Call<Commensal> addReservation(@Path("idcommensal") int idCommensal , @Path("idrestaurant") int idRestaurant);

    /**
     * Find /api/findReservation/{id}
     * Obtiene la lista de las reservas de los comensales.
     * @param idCommensal identificador del comensal.
     * @return
     */
    @GET("allreservation/{id}")
    Call<List<Reservation>> getReservations(@Path("id") int idCommensal);


}