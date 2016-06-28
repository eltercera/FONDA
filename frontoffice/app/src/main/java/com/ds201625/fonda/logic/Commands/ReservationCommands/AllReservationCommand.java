package com.ds201625.fonda.logic.Commands.ReservationCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetReservationFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Andreina on 22-06-2016.
 */
public class AllReservationCommand extends BaseCommand {

    private String TAG = "AllReservationCommand";
    private List<Reservation> reservationList = null;
    private Commensal idCommensal;

    /**
     * Asigna valor a los parametros
     * @return parametros comensal
     */
    @Override
    protected Parameter[] setParameters() {

        Parameter [] parameters = new Parameter[0];
      //  parameters[0] = new Parameter(Commensal.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para mostrar toda las reservas
     */
    @Override
    protected void invoke() throws GetReservationFondaWebApiControllerException {
        Log.d(TAG, "Comando para obtener las reservas");
        ReservationService serviceReservation = FondaServiceFactory.getInstance()
                .getReservationService(SessionData.getInstance().getToken());
      //  idCommensal = FondaEntityFactory.getInstance().GetCommensal();

        try {
      //      idCommensal = (Commensal) this.getParameter(0);
            reservationList =  serviceReservation.getReservations(0);
        }catch(GetReservationFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al obtener las reservas", e);
            throw  new GetReservationFondaWebApiControllerException(e);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener las reservas", e);
            throw  new GetReservationFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener las reservas", e);
            throw  new GetReservationFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener las reservas", e);
            throw  new GetReservationFondaWebApiControllerException(e);
        }
        setResult(reservationList);
    }

}
