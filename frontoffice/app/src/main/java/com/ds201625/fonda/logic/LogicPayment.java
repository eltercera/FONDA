package com.ds201625.fonda.logic;

import android.content.Context;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.CreditCarPayment;

/**
 * Created by Hp on 22/05/2016.
 */
public class LogicPayment {
    /**
     * Contexto de la aplicacion
     */
    private Context context;
    /**
     * Singelton instance
     */
    private static LogicPayment instance;

    public void registerPayment(int idProfile, float tip, String last4Digits) throws Exception {
        CreditCarPayment newBill;
        newBill = setPaymentService().registerPayment(idProfile, tip, last4Digits,context);
        if (newBill == null) {
           throw new Exception("No se logro crear el usuario");
        }

    }

    private PaymentService setPaymentService(){
        return FondaServiceFactory.getInstance().setPaymentService();
    }

    /**
     * Get the instance
     * @return
     */
    public  static LogicPayment getInstance() {
        return instance;
    }

}
