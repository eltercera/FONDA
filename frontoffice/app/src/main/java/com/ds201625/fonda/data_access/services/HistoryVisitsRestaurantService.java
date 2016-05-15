package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.domains.Invoice;


import java.util.List;

/**
 * Created by Adriana on 5/15/2016.
 */
public  interface HistoryVisitsRestaurantService {

    List<Invoice> getHistoryVisits();

}
