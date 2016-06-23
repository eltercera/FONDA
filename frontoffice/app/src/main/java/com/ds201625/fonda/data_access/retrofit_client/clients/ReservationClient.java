package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.Reservation;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.DELETE;
import retrofit2.http.Path;


public interface ReservationClient {



    @GET("reserve")
    Call<List<Reservation>> getReservation();



}