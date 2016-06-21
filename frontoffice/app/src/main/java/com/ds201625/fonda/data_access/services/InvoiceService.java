package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Invoice;

/**
 * Created by Yuneth on 5/15/2016.
 */

/**
 * Interface de InvoiceService
 */
public interface InvoiceService {

    Invoice getCurrentInvoice() throws RestClientException;

}
