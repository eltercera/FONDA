package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 * Created by Jessica on 21/05/16.
 */
public interface ReservationService {
    List<Reservation> getAllReserves (int fk1);

}
