package com.ds201625.fonda.tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */
public class HistoryVisitsServiceTest extends TestCase {


    private List<Invoice> listInvoice;
    private HistoryVisitsRestaurantService historyVisitsRestaurantService;


    protected void setUp() throws Exception {
        super.setUp();
        historyVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService();
    }

/*
 *  Metodo para probar que la lista esta vacia cuando no se ha conectado con el WS
 */
    public void testHistoryVisitsIsEmpty() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits();
            MoreAsserts.assertEmpty(listInvoice);
            assertEquals(0, listInvoice.size());
        }
        catch (NullPointerException e){}
    }

/*
 *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
 */
    public void testHistoryVisitsIsNotEmpty() {

        try {
            listInvoice = historyVisitsRestaurantService.getHistoryVisits();
            MoreAsserts.assertNotEmpty(listInvoice);
            assertEquals(3, listInvoice.size());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        }
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        listInvoice = null;
    }

}
