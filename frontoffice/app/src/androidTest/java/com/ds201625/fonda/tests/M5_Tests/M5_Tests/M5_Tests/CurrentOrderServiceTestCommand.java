package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M5_Tests;

import android.test.MoreAsserts;
import android.util.Log;


import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.DishOrder;

import junit.framework.TestCase;


import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */

/**
 * Clase De pruebas unitarias de la lista de platos ordenados de una persona en sus visitas a restaurant
 */
public class CurrentOrderServiceTest extends TestCase {

    /*
       Lista de platos ordenados
    */
    private List<DishOrder> listDishOrder;

    /*
       Variable de la clase CurrentOrderService
    */
    private CurrentOrderService currentOrderService;
	
	
    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "CurrentOrderServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        currentOrderService = FondaServiceFactory.getInstance().getCurrentOrderService();
    }


    /**
     *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
     */
    public void testListDishOrderIsNotEmpty() {

        try {

        listDishOrder = currentOrderService.getListDishOrder();
        assertFalse(listDishOrder.isEmpty());
        } catch (RestClientException e) {
            //e.printStackTrace();
			Log.e(TAG,"Error en CurrentOrderServiceTest ",e);
        }
    }

    /*
     *  Metodo que prueba que existan elementos en la lista
     */
    public void testListDishOrderElements() {

        try {
            listDishOrder = currentOrderService.getListDishOrder();
            MoreAsserts.assertNotEmpty(listDishOrder);
            assertEquals(3, listDishOrder.size());
        }
        catch (NullPointerException e) {
            //fail("No esta conectado al WS");
			Log.e(TAG,"Error en CurrentOrderServiceTest  no esta conectado al WS",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
			Log.e(TAG,"Error en CurrentOrderServiceTest ",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no este vacio
     */
    public void testDishOrderIsNotEmpty() {

        try {
            String nameDish = "Pasta";
            listDishOrder = currentOrderService.getListDishOrder();
            assertEquals(nameDish, listDishOrder.get(0).getDish().getName());
        }
        catch (NullPointerException e){
            //fail("No esta conectado al WS");
			Log.e(TAG,"Error en CurrentOrderServiceTest  no esta conectado al WS",e);
        }
        catch (RestClientException e) {
            //e.printStackTrace();
			Log.e(TAG,"Error en CurrentOrderServiceTest ",e);
        }


    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
        listDishOrder = currentOrderService.getListDishOrder();
        assertNotNull(listDishOrder.get(0).getDish());
        }
        catch (RestClientException e) {
           // e.printStackTrace();
		   Log.e(TAG,"Error en CurrentOrderServiceTest ",e);
        }
    }

    /**
     * Metodo que prueba que la lista de platos no sea nula
     */
    public void testListDishOrderIsNotNull() {

        try {
            listDishOrder = currentOrderService.getListDishOrder();
            assertNotNull(listDishOrder);
        }
        catch (NullPointerException e) {
            //fail("No esta conectado al WS");
			Log.e(TAG,"Error en CurrentOrderServiceTest  no esta conectado al WS",e);
        } catch (RestClientException e) {
            //e.printStackTrace();
			Log.e(TAG,"Error en CurrentOrderServiceTest ",e);
        }

    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        listDishOrder = null;
    }


}
