package com.ds201625.fonda.views.contracts;

import com.ds201625.fonda.domains.Reservation;

import java.util.List;

/**
 * Created by Eduardo on 22-06-2016.
 */
public interface ReservationView {

    /**
     * Lista de toda las  reservas
     * @return reservas
     */
    List<Reservation> getListSW();


}
