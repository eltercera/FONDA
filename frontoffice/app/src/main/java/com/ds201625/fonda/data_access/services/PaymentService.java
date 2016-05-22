package com.ds201625.fonda.data_access.services;

import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.CreditCarPayment;

/**
 * Created by Hp on 22/05/2016.
 */
public interface PaymentService {

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
    CreditCarPayment registerPayment(int idProfile, float tip, String digits, Context context) throws RestClientException, LocalStorageException;


    }
