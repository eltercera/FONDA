package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.ReservationClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 *
 */
public class RetrofitReservationService implements ReservationService {

    private String TAG = "RetrofitReservationService";
    private ReservationClient reservationClient  =
            RetrofitService.getInstance().createService(ReservationClient.class);

    public RetrofitReservationService() {
        super();
    }


    @Override
    public Commensal AddReservation(int idCommensal, int idRestaurant) throws RestClientException {
        // aqui se supone que debo traerme el comensal Logeado
        Log.d(TAG, "Se agrega el restaurante " + idRestaurant + "a favoritos del comensal " + idCommensal);
        Call<Commensal> call = reservationClient.addReservation(idCommensal, idRestaurant);
        Commensal r = null;

        try{
            r = call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en AddFavoriteRestaurant", e);
        }

        return r;
    }

    /**
     * Obtiene toda las reservas  de los comensales
     *
     * @param idCommensal
     * @return
     * @throws RestClientException
     */

    @Override
    public List<Reservation> getReservesService(int idCommensal) throws RestClientException {
        Log.d(TAG, "Se obtienen toda las reservas del comensal: "+idCommensal);
        Call<List<Reservation>> call = reservationClient.getReservations(idCommensal);
        List<Reservation> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getReservarions", e);
        }

        return test;
    }



}