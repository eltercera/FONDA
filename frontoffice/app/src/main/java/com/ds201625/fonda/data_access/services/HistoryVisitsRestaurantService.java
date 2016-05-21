package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Invoice;


import java.util.List;

/**
 * Created by Adri on 5/15/2016.
 */

/**
 * Interface de HistoryVisitsRestaurantService
 */
public  interface HistoryVisitsRestaurantService {

    List<Invoice> getHistoryVisits();

}
