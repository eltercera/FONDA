package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.contracts.LogicInvoiceView;
import com.ds201625.fonda.views.contracts.LogicInvoiceViewPresenter;

import java.util.List;

/**
 * Created by Jessica on 22/6/2016.
 */

public class LogicInvoicePresenter implements LogicInvoiceViewPresenter {

    private LogicInvoiceView logicInvoiceView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private Invoice invoiceWS;
    private String TAG = "LogicInvoicePresenter";

    /**
     * Constructor
     * @param view
     */
    public LogicInvoicePresenter(LogicInvoiceView view){
        logicInvoiceView = view;
    }

    /**
     * Encuentra los platos ordenados
     *
     * @return
     */
    @Override
    public Invoice findAllInvoice() {
        Log.d(TAG,"Ha entrado en findAllInvoice");
        Command cmdAllInvoice = facCmd.logicInvoiceCommand();
        try {
            cmdAllInvoice.setParameter(0,logedComensal);
            cmdAllInvoice.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllInvoice al buscar facturas", e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en findAllInvoice al buscar facturas", e);
        }
        invoiceWS = (Invoice) cmdAllInvoice.getResult();
        Log.d(TAG,"Se retorna la factura");
        Log.d(TAG,"Ha finalizado findAllInvoice");
        return invoiceWS;
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
