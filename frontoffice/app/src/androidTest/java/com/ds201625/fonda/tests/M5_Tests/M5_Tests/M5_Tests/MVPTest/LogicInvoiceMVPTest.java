package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M5_Tests.MVPTest;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.views.contracts.LogicInvoiceView;
import com.ds201625.fonda.views.contracts.LogicInvoiceViewPresenter;
import com.ds201625.fonda.views.presenters.LogicInvoicePresenter;

/**
 * Created by vickinsua on 6/23/2016.
        */
public class LogicInvoiceMVPTest extends TestCase implements LogicInvoiceView {
    /*
      Lista de Invoice que contiene los pagos de los restaurant

      */
    private List<Invoice> listInvoice;

    /**
     * variable tipo LogicInvoicePresenter
     */
    private LogicInvoicePresenter logicInvoicePresenter;

    /**
     * id de comensal logueado
     */
    private Commensal logedCommensal;

    private String TAG = "LogicInvoiceMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        logicInvoicePresenter = new LogicInvoicePresenter(this);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        logicInvoicePresenter = null;
        logedCommensal = null;
        listInvoice = null;
    }

    /**
     *  Metodo para probar el login del comensal.
     */
    public void testfindLoggedCommensal() {

        try {

            logicInvoicePresenter.findLoggedComensal();
            assertEquals(logedCommensal, logicInvoicePresenter);
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
            logicInvoicePresenter.findLoggedComensal();
            assertNotSame(logedCommensal, logicInvoicePresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }

    }

    /**
     *  Metodo para probar que la consulta del comensal no es nula
     */
    public void testFindLoggedCommensalIsNotNull() {

        try {
            logicInvoicePresenter.findLoggedComensal();
            assertNotNull(logicInvoicePresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia
     */

    public void testfindAllInvoiceIsNotEmpty() {

        try {
            listInvoice = logicInvoicePresenter.findAllInvoice();
            assertFalse(listInvoice.isEmpty());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testfindAllInvoiceIsNotEmpty ",e);
        }

    }


    /**
     * Metodo que prueba que la lista no sea nula
     */
    public void testfindAllInvoiceIsNotNull() {

        try {
            listInvoice = logicInvoicePresenter.findAllInvoice();
            assertNotNull(listInvoice);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testfindAllInvoiceIsNotNull ",e);
        }
    }

    /**
     * Metodo que prueba que existan elementos en la lista
     */
    public void testfindAllInvoiceElementLsit() {

        try {
            listInvoice = logicInvoicePresenter.findAllInvoice();
            MoreAsserts.assertNotEmpty(listInvoice);
            assertEquals(6, listInvoice .size());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testfindAllInvoiceElementLsit ",e);
        }

    }

    /**
     * Lista de todas las facturas
     *
     * @return facturas
     */
    @Override
    public List<Invoice> getListSW() {
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {

    }

}
