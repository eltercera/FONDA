package com.tests.M5_Tests.M5_Tests.M5_Tests.MVPTest;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsView;
import com.ds201625.fonda.views.presenters.LogicHistoryVisitsPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by vickinsua on 6/23/2016.
 */
public class LogicHistoryVisitsMVPTest extends TestCase implements LogicHistoryVisitsView {

    /*
       Lista de Invoice que contiene los pagos de los restaurant

       */
    private List<Invoice> listInvoice;

    /**
     * variable tipo LogicHistoryVisitsPresenter
     */
    private LogicHistoryVisitsPresenter logicHistoryVisitsPresenter;
    /**
     * id de comensal logueado
     */
    private Commensal logedCommensal;
    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "LogicHistoryVisitsMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        logicHistoryVisitsPresenter = new LogicHistoryVisitsPresenter(this);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        logicHistoryVisitsPresenter = null;
        logedCommensal = null;
        listInvoice = null;
    }

    /**
     *  Metodo para probar el login del comensal.
     */
    public void testFindLoggedCommensal() {

        try {

            logicHistoryVisitsPresenter.findLoggedComensal();
            assertEquals(logedCommensal, logicHistoryVisitsPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }

    /**
     *  Metodo para probar que no se pudo consultar el logged del commensal por existencia de una
     *  referencia nula.
     */
    public void testFindLoggedCommensalIsNull() {

        try {
            logedCommensal = FondaEntityFactory.getInstance().GetCommensal(6);
            logicHistoryVisitsPresenter.findLoggedComensal();
            assertNotSame(logedCommensal, logicHistoryVisitsPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }

    }

    /**
     *  Metodo para probar que la consulta del comensal no es nula
     */
    public void testFindLoggedCommensalIsNotNull() {

        try {
            logicHistoryVisitsPresenter.findLoggedComensal();
            assertNotNull(logicHistoryVisitsPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia
     */

    public void testFindAllHistoryVisitsIsNotEmpty() {

        try {
            listInvoice = logicHistoryVisitsPresenter.findAllHistoryVisits();
            assertFalse(listInvoice.isEmpty());
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindAllHistoryVisitsIsNotEmpty ",e);
        }

    }

    /**
     * Metodo que prueba que la lista no sea nula
     */
    public void testFindAllHistoryVisitsIsNotNull() {

        try {
            listInvoice = logicHistoryVisitsPresenter.findAllHistoryVisits();
            assertNotNull(listInvoice);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindAllHistoryVisitsIsNotNull ",e);
        }
    }

    /**
     * Metodo que prueba que existan elementos en la lista
     */
    public void testFindAllHistoryVisitsElementLsit() {

        try {
            listInvoice = logicHistoryVisitsPresenter.findAllHistoryVisits();
            MoreAsserts.assertNotEmpty(listInvoice);
            assertEquals(6, listInvoice .size());
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindAllHistoryVisitsElementLsit ",e);
        }

    }

    /**
     * Lista de todas las facturas
     *
     * @return facturas
     */


    @Override
    public List<Invoice> getHistoryVisitsSW() {
        return null;
    }
}
