package com.ds201625.fonda.tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */
public class InvoiceServiceTest extends TestCase {


    private Invoice invoice;
    private InvoiceService invoiceService;


    protected void setUp() throws Exception {
        super.setUp();
        invoiceService = FondaServiceFactory.getInstance().getInvoiceService();
    }

    /*
   *  Metodo para probar que la factura no es nula cuando se ha conectado con el WS
   */
    public void testInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
            assertNotNull(invoice);
            assertEquals("The dining room", invoice.getRestaurant().getName());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        }
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
    }

}
