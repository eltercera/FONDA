package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;

import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 */
public interface ReservationService {
    List<Reservation> getReservation() throws RestClientException;
    void addReservation(Reservation reserve) throws RestClientException;
    void editReservatio(Reservation reserve) throws RestClientException;


}
