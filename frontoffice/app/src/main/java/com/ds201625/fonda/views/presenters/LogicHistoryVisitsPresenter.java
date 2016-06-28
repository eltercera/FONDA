package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsView;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Jessica on 22/6/2016.
 */
public class LogicHistoryVisitsPresenter implements LogicHistoryVisitsViewPresenter {

    private LogicHistoryVisitsView logicHistoryVisitsView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private List<Invoice> listHistoryVisitsWS;
    private String TAG = "LogicHistoryVisitsPresenter";

    /**
     * Constructor
     * @param view
     */
    public LogicHistoryVisitsPresenter(LogicHistoryVisitsView view){
        logicHistoryVisitsView = view;
    }

    /**
     * Encuentra historial de pagos
     *
     * @return
     */

    @Override
    public List<Invoice> findAllHistoryVisits() {
        Log.d(TAG,"Ha entrado en findAllHistoryVisits");
        Command cmdAllHistoryVisits = facCmd.logicHistoryVisitsCommand();
        try {
            cmdAllHistoryVisits.setParameter(0,logedComensal);
            cmdAllHistoryVisits.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllHistoryVisits al buscar el historial de pagos", e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en findAllHistoryVisits al buscar el historial de pagos", e);
        }
        listHistoryVisitsWS = (List<Invoice>) cmdAllHistoryVisits.getResult();
        Log.d(TAG,"Se retorna la lista de historial de pagos");
        Log.d(TAG,"Ha finalizado findAllHistoryVisits");
        return listHistoryVisitsWS;
    }

    /**
     * Encuentra el comensal logueado
     */
    @Override
    public void findLoggedComensal() {
        Log.d(TAG,"Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();

        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }

        logedComensal = (Commensal) cmdRequireLoged.getResult();
        Log.d(TAG,"Se obtiene el comensal logueado "+logedComensal.getId());
        Log.d(TAG,"Ha finalizado findLoggedComensal");
    }
}
