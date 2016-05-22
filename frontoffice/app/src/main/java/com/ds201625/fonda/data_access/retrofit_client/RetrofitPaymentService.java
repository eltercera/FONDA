package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.PaymentClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.CreditCarPayment;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by Hp on 22/05/2016.
 */
public class RetrofitPaymentService implements PaymentService {

    /**
     * Instance for Credit card local files
     */
    private JsonFile<CreditCarPayment> localFile;
    /**
     * Instance rest cliente PaymentClient
     */
    private PaymentClient paymentClient = RetrofitService.getInstance().createService(PaymentClient.class);

    /**
     *
     * @param idProfile
     * @param tip
     * @param digits
     * @param context
     * @return
     * @throws RestClientException
     * @throws LocalStorageException
     */
    public CreditCarPayment registerPayment(int idProfile, float tip, String digits, Context context) throws RestClientException, LocalStorageException {

        CreditCarPayment creditCarP = new CreditCarPayment();
        String lastDigits = digits.substring(16,20);
        int last4Digits = Integer.parseInt(lastDigits);
        creditCarP.setLastCardDigits(last4Digits);
        Call<CreditCarPayment> call = paymentClient.requestClosedOrder(idProfile,tip,creditCarP);
        CreditCarPayment rsvPayment = null;
        try{
            rsvPayment = call.execute().body();
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }

        getFile(context).save(rsvPayment);

        return rsvPayment;
    }
    /**
     * Gets an instamce of Json File of type CreditCardPayment
     * @param context Context of aplication
     * @return the instance of json of type CreditCardPayment.
     */
    private JsonFile<CreditCarPayment> getFile(Context context) {

        if (localFile == null)
            localFile = new JsonFile<>("Paymentlocal", context,CreditCarPayment.class);

        return localFile;
    }


}


