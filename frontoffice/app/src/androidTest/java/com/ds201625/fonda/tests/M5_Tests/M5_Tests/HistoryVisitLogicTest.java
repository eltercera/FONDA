package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.LogicHistoryVisits;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 5/21/2016.
 */

/**
 * clase de pruebas de logica de historial de visitas
 */
public class HistoryVisitLogicTest extends TestCase {
    /*
         Lista de Invoice que contiene los pagos de los restaurant
         */
    private List<Invoice> listInvoice;

    /**
     * variable de la clase HistoryVisitsRestaurantService
     */
    private LogicHistoryVisits historyVisitsRestaurantService;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias de la logica de pagos
     *
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        historyVisitsRestaurantService = new LogicHistoryVisits();
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testHistoryVisitsIsNotEmpty() {

        listInvoice =   historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertFalse(listInvoice.isEmpty());
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {

        String nameRestaurant = "The dining room";
        listInvoice = historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertEquals(nameRestaurant, listInvoice.get(0).getRestaurant().getName());

    }

    /**
     * Metodo que prueba que el perfil de la lista de pagos no este vacio
     */
    public void testProfilesInvoiceIsNotEmpty(){

        String nameProfile = "Adriana Da Rocha";
        listInvoice = historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertEquals(nameProfile, listInvoice.get(1).getProfile().getProfileName());

    }

    /**
     * Metodo que prueba que la lista de pagos maneje el total de la factura
     */
    public void testInvoiceIsNotEmpty() {
        float total = 350;
        listInvoice =historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertEquals(total, listInvoice.get(2).getTotal());
    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        listInvoice = historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertNotNull(listInvoice.get(2).getRestaurant());
    }

    /**
     * Metodo que prueba que el objeto Perfil de la lista de pagos no sea nulo
     */
    public void testProfileInvoiceIsNotNull() {

        listInvoice = historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
        assertNotNull(listInvoice.get(2).getProfile());
    }

    /**
     * Metodo que prueba que la lista de pago no sea nula
     */
    public void testHistoryVisitsIsNotNull() {

        try {
            listInvoice = historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
            assertNotNull(listInvoice);
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        }
    }

    /**
     * Metodo que prueba que existan elementos en la lista
     */
    public void testElementLsit() {

        try {
            listInvoice =historyVisitsRestaurantService.apihistoryVisits().getHistoryVisits();
            MoreAsserts.assertNotEmpty(listInvoice );
            assertEquals(6, listInvoice .size());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        }
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listInvoice = null;
    }

}

