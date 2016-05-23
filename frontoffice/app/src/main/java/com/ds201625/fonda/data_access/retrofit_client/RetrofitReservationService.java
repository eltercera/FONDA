package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.AllFavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.ReservationClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Created by Jessica on 22/05/16.
 */
public class RetrofitReservationService implements ReservationService {

    private ReservationClient currentReservationClient =
            RetrofitService.getInstance().createService(ReservationClient.class);

    public RetrofitReservationService() {
        super();
    }

    @Override
    public List<Reservation> getAllReserves(int id) {

        Call<List<Reservation>> call = currentReservationClient.getReservation();
        List<Reservation> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }
}