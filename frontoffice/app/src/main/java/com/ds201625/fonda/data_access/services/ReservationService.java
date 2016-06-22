package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;

import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 */
public interface ReservationService {
    Reservation AddReservation(int idCommensal, int idRestaurant)  throws RestClientException;;

    List<Reservation> getReservarions(int idCommensal)  throws RestClientException;;

}
