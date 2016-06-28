package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.contracts.LogicInvoiceView;
import com.ds201625.fonda.views.contracts.LogicInvoiceViewPresenter;
import com.ds201625.fonda.views.contracts.LogicPaymentView;
import com.ds201625.fonda.views.contracts.LogicPaymentViewPresenter;

/**
 * Created by Jessica on 22/6/2016.
 */

public class LogicPaymentPresenter implements LogicPaymentViewPresenter {

    private LogicPaymentView logicPaymentView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private Payment paymentWS;
    private String TAG = "LogicPaymentPresenter";

    /**
     * Constructor
     * @param view
     */
    public LogicPaymentPresenter(LogicPaymentView view){
        logicPaymentView = view;
    }

    /**
     * Encuentra los pagos
     *
     * @return
     */
    @Override
    public Payment findAllPayments() {
        Log.d(TAG,"Ha entrado en findAllPayments");
        Command cmdAllPayment = facCmd.logicPaymentCommand();
        try {
            cmdAllPayment.setParameter(0,logedComensal);
            cmdAllPayment.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllPayments al buscar pagos", e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en findAllPayments al buscar pagos", e);
        }
        paymentWS = (Payment) cmdAllPayment.getResult();
        Log.d(TAG,"Se retorna el pago");
        Log.d(TAG,"Ha finalizado findAllPayments");
        return paymentWS;
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
