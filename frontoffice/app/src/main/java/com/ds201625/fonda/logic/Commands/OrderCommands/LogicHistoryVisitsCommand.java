package com.ds201625.fonda.logic.Commands.OrderCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.*;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

import java.util.List;

/**
 * Created by Jessica on 20/6/2016.
 */
public class LogicHistoryVisitsCommand extends BaseCommand {
    private String TAG = "LogicHistoryVisitsCommand";
    /**
     * variable de tipo HistoryVisitsRestaurantService
     */
    private List<Invoice> listVisitsRestaurantService;
    /**
     * variable de tipo Profile
     */
    private Profile idProfile;

    /**
     * Asigna valor a los parametros
     * @return parametro comensal
     */
    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Profile.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para mostrar el historial de pagos
     */
    @Override
    protected void invoke() throws LogicHistoryVisitsWebApiControllerException {

        Log.d(TAG, "Comando para ver el historial de pagos");
        HistoryVisitsRestaurantService serviceHistoryVisits = FondaServiceFactory.getInstance().getHistoryVisitsService();

        idProfile = FondaEntityFactory.getInstance().GetProfile();
        try {

            idProfile = (Profile) this.getParameter(0);
            listVisitsRestaurantService = serviceHistoryVisits.getHistoryVisits(idProfile.getId());

        }catch (LogicHistoryVisitsWebApiControllerException e){
            Log.e(TAG, "Se ha generado un error obteniendo el historial de pagos", e);
            throw new LogicHistoryVisitsWebApiControllerException(e);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado un error obteniendo el historial de pagos", e);
            throw new LogicHistoryVisitsWebApiControllerException(e);
        }catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado un error obteniendo el historial de pagos", e);
            throw new LogicHistoryVisitsWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado un error obteniendo el historial de pagos", e);
            throw new LogicHistoryVisitsWebApiControllerException(e);
        }
    setResult(listVisitsRestaurantService);
    }
}
