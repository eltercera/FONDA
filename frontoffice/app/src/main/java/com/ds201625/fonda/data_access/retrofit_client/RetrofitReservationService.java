package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.ReservationClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Reservation;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 *
 */
public class RetrofitReservationService implements ReservationService {

    private ReservationClient currentReservationClient =
            RetrofitService.getInstance().createService(ReservationClient.class);

    public RetrofitReservationService() {
        super();
    }



    @Override
    public List<Reservation> getReservation() throws RestClientException {
        return null;
    }

    @Override
    public void addReservation(Reservation reserve) throws RestClientException {

    }

    @Override
    public void editReservatio(Reservation reserve) throws RestClientException {

    }
}