package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Invoice;


import java.util.List;

/**
 * Created by Jessica on 20/06/2016.
 */

/**
 * Interface de HistoryVisitsRestaurantService
 */
public  interface HistoryVisitsRestaurantService {

    List<Invoice> getHistoryVisits(int idProfile) throws RestClientException;
}
