package com.tests.M5_Tests.M5_Tests.M5_Tests.CommanTest;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.LogicHistoryVisits;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by vickinsua on 6/20/2016.
 */
public class HistoryVisitCommandTest extends TestCase {
    /*
             Lista de Invoice que contiene los pagos de los restaurant
             */
    private List<Invoice> listInvoice;

    /**
     * variable de la clase HistoryVisitsRestaurantService
     */
    private LogicHistoryVisits logicHistoryVisits;

    /*
      fabrica de comandos
   */
    private FondaCommandFactory facCmd;

    /*
    Variable de tipo Command
 */
    private Command cmd;

    /**
     *comensal logeado
     */

    private Commensal logedCommensal;


    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "HistoryVisitLogicCommandTestt";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias de la logica de pagos
     *
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
        //logicHistoryVisits = new LogicHistoryVisits();
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testHistoryVisitsIsNotEmpty() {

        try {
            cmd = facCmd.LogicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertFalse(listInvoice.isEmpty());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty" ,e);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no este vacio
     */
    public void testRestaurantInvoiceIsNotEmpty() {

        String nameRestaurant = "The dining room";
        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertEquals(nameRestaurant, listInvoice.get(0).getRestaurant().getName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty" ,e);
        } catch (Exception e) {
            e.printStackTrace();
        }


    }

    /**
     * Metodo que prueba que el perfil de la lista de pagos no este vacio
     */
    public void testProfilesInvoiceIsNotEmpty(){

        String nameProfile = "Adriana Da Rocha";
        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertEquals(nameProfile, listInvoice.get(1).getProfile().getProfileName());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty" ,e);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que la lista de pagos maneje el total de la factura
     */
    public void testInvoiceIsNotEmpty() {
        float total = 350;
        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertEquals(total, listInvoice.get(2).getTotal());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty ",e);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Restaurant de la lista de pagos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertNotNull(listInvoice.get(2).getRestaurant());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty ",e);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que el objeto Perfil de la lista de pagos no sea nulo
     */
    public void testProfileInvoiceIsNotNull() {

        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertNotNull(listInvoice.get(2).getProfile());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty ",e);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo que prueba que la lista de pago no sea nula
     */
    public void testHistoryVisitsIsNotNull() {

        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            assertNotNull(listInvoice);
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty ",e);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Metodo que prueba que existan elementos en la lista
     */
    public void testElementLsit() {

        try {
            cmd = facCmd.logicHistoryVisitsCommand();
            cmd.run();
            listInvoice = logicHistoryVisits.apihistoryVisits();
            MoreAsserts.assertNotEmpty(listInvoice);
            assertEquals(6, listInvoice .size());
        } catch (RestClientException e) {
            //e.printStackTrace();
            Log.e(TAG,"Error en testHistoryVisitsIsNotEmpty " ,e);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listInvoice = null;
        logicHistoryVisits = null;
        facCmd = null;
        cmd = null;
    }

}
