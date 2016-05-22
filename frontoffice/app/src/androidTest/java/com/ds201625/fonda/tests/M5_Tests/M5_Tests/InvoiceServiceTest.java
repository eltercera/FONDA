package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */

/**
 * Clase De pruebas unitarias de la factura al cerrar la cuenta de una persona en su visita a restaurant
 */
public class InvoiceServiceTest extends TestCase {

    /*
         Objeto Invoice que contiene el pago de la cuenta
     */
    private Invoice invoice;

    /**
     * variable de la clase InvoiceService
     */
    private InvoiceService invoiceService;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        invoiceService = FondaServiceFactory.getInstance().getInvoiceService();
    }


    /*
     *  Metodo que prueba que la factura no es nula cuando  se conecta con el WS
     */
    public void testInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
            assertNotNull(invoice);
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            e.printStackTrace();
        }
    }


    /*
     *  Metodo que prueba que existan elementos en la factura
     */
    public void testInvoiceElements() {

        try {
            invoice = invoiceService.getCurrentInvoice();
            assertNotNull(invoice);
            assertEquals("The dining room", invoice.getRestaurant().getName());
            assertEquals("Adriana", invoice.getProfile().getProfileName());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {

        String nameRestaurant = "The dining room";
        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertEquals(nameRestaurant, invoice.getRestaurant().getName());

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la factura no es nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertNotNull(invoice.getRestaurant());
    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no este vacio
     */
    public void testProfileInvoiceIsNotEmpty() {

        String nameProfile = "Adriana";
        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertEquals(nameProfile, invoice.getProfile().getProfileName());

    }

    /**
     * Metodo que prueba que el objeto Profile de la factura no es nulo
     */
    public void testProfileInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertNotNull(invoice.getProfile());
    }


    /**
     * Metodo que prueba que el objeto Account de la factura no este vacio
     */
    public void testAccountInvoiceIsNotEmpty() {


        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertEquals(3, invoice.getAccount().getListDish().size());

    }

    /**
     * Metodo que prueba que el objeto Account de la factura no es nulo
     */
    public void testAccountInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertNotNull(invoice.getAccount());
    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no este vacio
     */
    public void testCurrencyInvoiceIsNotEmpty() {

        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertEquals("Bolivar", invoice.getCurrency().getName());

    }

    /**
     * Metodo que prueba que el objeto Currency de la factura no es nulo
     */
    public void testCurrencyInvoiceIsNotNull() {

        try {
            invoice = invoiceService.getCurrentInvoice();
        } catch (RestClientException e) {
            e.printStackTrace();
        }
        assertNotNull(invoice.getCurrency());
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
    }

}
