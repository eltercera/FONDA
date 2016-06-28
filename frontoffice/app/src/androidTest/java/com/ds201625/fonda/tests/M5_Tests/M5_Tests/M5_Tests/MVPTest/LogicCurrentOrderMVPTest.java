package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M5_Tests.MVPTest;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.views.contracts.LogicCurrentOrderView;
import com.ds201625.fonda.views.presenters.LogicCurrentOrderPresenter;

/**
 * Created by vickinsua on 6/23/2016.
 */
public class LogicCurrentOrderMVPTest {

    /*
       Lista de platos ordenados
    */
    private List<DishOrder> listDishOrder;

    /**
     * variable tipo LogicCurrentOrderPresenter
     */
    private LogicCurrentOrderPresenter logicCurrentOrderPresenter;

    /**
     * id de comensal logueado
     */
    private Commensal logedCommensal;
    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "LogicCurrentOrderMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        logicCurrentOrderPresenter = new LogicCurrentOrderPresenter(this);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listDishOrder = null;
        logicCurrentOrderPresenter = null;
        logedCommensal = null;
    }

    /**
     *  Metodo para probar el login del comensal.
     */
    public void testFindLoggedCommensal() {

        try {

            logicCurrentOrderPresenter.findLoggedComensal();
            assertEquals(logedCommensal, logicCurrentOrderPresenter);
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
            logicCurrentOrderPresenter.findLoggedComensal();
            assertNotSame(logedCommensal, logicCurrentOrderPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }

    }

    /**
     *  Metodo para probar que la consulta del comensal no es nula
     */
    public void testFindLoggedCommensalIsNotNull() {

        try {
            logicCurrentOrderPresenter.findLoggedComensal();
            assertNotNull(logicCurrentOrderPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }

    /**
     * Metodo que prueba que la lista de platos no sea nula
     */
    public void testfindAllDishOrderIsNotNull() {

        try {
            listDishOrder = logicCurrentOrderPresenter.findAllDishOrder();
            assertNotNull(listDishOrder);
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testfindAllDishOrderIsNotNull",e);
        }
    }

    /*
     *  Metodo que prueba que existan elementos en la lista
     */
    public void testfindAllDishOrderElements() {

        try {
            listDishOrder = logicCurrentOrderPresenter.findAllDishOrder();
            MoreAsserts.assertNotEmpty(listDishOrder);
            assertEquals(3, listDishOrder.size());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testfindAllDishOrderElements",e);
        }

    }

    /**
     *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
     */
    public void testfindAllDishOrderIsNotEmpty() {

        try {
            listDishOrder = logicCurrentOrderPresenter.findAllDishOrder();
            assertFalse(listDishOrder.isEmpty());
        } catch (RestClientException e) {
            Log.e(TAG,"testfindAllDishOrderIsNotEmpty",e);
        }

    }

    /**
     * Lista de todas las ordenes actuales
     *
     * @return ordenes actuales
     */
    @Override
    public List<DishOrder> getListSW() {
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {

    }
}
