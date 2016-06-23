package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.interfaces.ReservationView;
import com.ds201625.fonda.interfaces.ReservationViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Andreina on 22-06-2016.
 */
public class ReservationPresenter implements ReservationViewPresenter {


    private ReservationView iReservationView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private List<Reservation> listReserWS;
    private String TAG = "ReservationPresenter";

    /**
     * Constructor
     *
     * @param view
     */

    public ReservationPresenter(ReservationView view) {
        iReservationView = view;
    }


    /**
     * Encuentra el comensal logueado
     */

    @Override
    public void findLoggedComensal() {
        Log.d(TAG, "Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();

        emailToWebService = log.getEmail() + "/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0, emailToWebService);
            cmdRequireLoged.run();
        } catch (NullPointerException e) {
            Log.e(TAG, "Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        } catch (Exception e) {
            Log.e(TAG, "Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }

        logedComensal = (Commensal) cmdRequireLoged.getResult();
        Log.d(TAG, "Se obtiene el comensal logueado " + logedComensal.getId());
        Log.d(TAG, "Ha finalizado findLoggedComensal");
    }

    /**
     * Agrega una Reserva
     *
     * @param reservation
     *
     */

   @Override
    public void addReservation(Reservation reservation) {
        Log.d(TAG, "Ha entrado en addReservation");
       Command cmdAddReservation = facCmd.AddReservationCommand();
        try {
           cmdAddReservation.setParameter(0, logedComensal);
            cmdAddReservation.setParameter(1, reservation);
            cmdAddReservation.run();

        } catch (NullPointerException e) {
            Log.e(TAG, "Error en addReservation",
                    e);
        } catch (Exception e) {
            Log.e(TAG, "Error en addReservation",
                    e);
        }
        Log.d(TAG, "Se agrega la reservacion " + reservation.getReserveDate());
        Log.d(TAG, "Ha finalizado addReservation");
    }

    /**
     * Encuentra las reservaciones
     *
     * @return listReserWS
     */
    @Override
    public List<Reservation> AllReservation() {
        Log.d(TAG,"Ha entrado en AllReservation");
        Command cmdAllReservation = facCmd.AllReservationCommand();
        try {
            cmdAllReservation.setParameter(0,logedComensal);
            cmdAllReservation.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en cmdAllReservation",
                    e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en cmdAllReservation ",
                    e);
        }
        listReserWS = (List<Reservation>) cmdAllReservation.getResult();
        Log.d(TAG,"Se retorna la lista de Restaurantes Favoritos");
        Log.d(TAG,"Ha finalizado findAllFavoriteRestaurant");
        return listReserWS;
    }
}
