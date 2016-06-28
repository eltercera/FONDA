package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.ReservationClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetReservationFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;

/**
 *
 */
public class RetrofitReservationService implements ReservationService {


    private ReservationClient reserveClient;

    private String TAG = "RetrofitReservationService";


    private APIError error;


        public RetrofitReservationService(Token token) {
            super();
            reserveClient = RetrofitService.getInstance()
                    .createService(ReservationClient.class,token.getStrToken());
        }


    @Override
    public Commensal AddReservation(int idCommensal, int idRestaurant) throws RestClientException {
        // aqui se supone que debo traerme el comensal Logeado
        Call<Commensal> call = reserveClient.addReservation(idCommensal, idRestaurant);
        Commensal r = null;

        try{
            r = call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en AddReservation", e);
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
    public List<Reservation> getReservations(int idCommensal) throws
            GetReservationFondaWebApiControllerException {
        Log.d(TAG, "Se obtienen toda las reservas del comensal: "+idCommensal);
        Call<List<Reservation>> call = reserveClient.getReservations();
        List<Reservation> test = null;
        Response <List<Reservation>> response;
        try {
            Log.d(TAG, "Ejecutando <-------------------------------");
            response =call.execute();
            //if (response.isSuccessful()){
            Log.d(TAG, "Obteniendo Body <-------------------------------");
                test = response.body();//}

            Log.d(TAG,(test == null ? "Es nulo <---- y retorno codigo :" + response.code() : "Tienen " + test.size() +"<----------------------------------"));
            /*else{

                error = ErrorUtils.parseError(response);
                Log.d(TAG, "Se obtiene la excepcion del WS");
                // usar error para disparar exception
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());

                throw  new GetReservationFondaWebApiControllerException
                        (error.exceptionType());
            }*/

        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getReservations", e);
            throw  new GetReservationFondaWebApiControllerException(error.exceptionType());
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getReservations", e);
            throw  new GetReservationFondaWebApiControllerException(error.exceptionType());

        }

        return test;
    }



}