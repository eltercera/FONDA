package com.ds201625.fonda.logic.Commands.ReservationCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.factory.ServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Created by Eduardo on 22-06-2016.
 */
public class AddReservationCommand extends BaseCommand {

    private String TAG = "AddReservationCommand";

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Commensal.class, true);
        parameters[1] = new Parameter(Restaurant.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {
        Log.d(TAG, "Comando para agregar una Reservacion");
        ReservationService rs = FondaServiceFactory.getInstance()
                .getReservationService();
        Commensal commensal = FondaEntityFactory.getInstance().GetCommensal();
        Commensal idCommensal;
        Restaurant idRestaurant;
        try {
            idCommensal = (Commensal) getParameter(0);
            idRestaurant = (Restaurant) getParameter(1);
            commensal =  rs.AddReservation(idCommensal.getId(),idRestaurant.getId());
            //AKI IRAN MAS EXCEPCIONES RECIBIDAS D BO
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar una reserva", e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar una reserva", e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar una reserva", e);
        }

        setResult(commensal);

    }
}
