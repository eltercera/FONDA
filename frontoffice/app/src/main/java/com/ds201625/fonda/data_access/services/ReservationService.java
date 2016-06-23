package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 */
public interface ReservationService {

    Commensal AddReservation(int idCommensal, int idRestaurant)  throws RestClientException;;

    List<Reservation> getReservesService(int idCommensal)  throws RestClientException;;

}
