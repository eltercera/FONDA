package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M5_Tests;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.logic.LogicCurrentOrder;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */

/**
 * Clase De pruebas unitarias de la lista de platos ordenados de una persona en sus visitas a restaurant
 */
public class CurrentOrderLogicCommandTest extends TestCase {

    /*
       Lista de platos ordenados
    */
    private List<DishOrder> listDishOrder;

    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
       Variable de tipo Command
    */
    private Command cmd;

	 /**
     * Variable String que indica la clase actual
     */
    private String TAG = "CurrentOrderLogicCommandTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
    }


    /**
     *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
     */
    public void testListDishOrderIsNotEmpty() {

        try {
            cmd = facCmd.logicCurrentOrderCommand();
            cmd.run();
            listDishOrder = (List<DishOrder>) cmd.getResult();
            MoreAsserts.assertNotEmpty(listDishOrder);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testListDishOrderIsNotEmpty al listar las ordenes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testListDishOrderIsNotEmpty al listar las ordenes",e);
        }

    }

    /*
     *  Metodo que prueba que existan elementos en la lista
     */
    public void testListDishOrderElements() {

        try {
            cmd = facCmd.logicCurrentOrderCommand();
            cmd.run();
            listDishOrder = (List<DishOrder>) cmd.getResult();
            MoreAsserts.assertNotEmpty(listDishOrder);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testListDishOrderElements al listar las ordenes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testListDishOrderElements al listar las ordenes",e);
        }

    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no este vacio
     */
    public void testDishOrderIsNotEmpty() {

        try {
            cmd = facCmd.logicCurrentOrderCommand();
            cmd.run();
            String nameDish = "Pasta";
            listDishOrder = (List<DishOrder>) cmd.getResult();
            assertEquals(nameDish, listDishOrder.get(0).getDish().getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testListDishOrderElements al listar las ordenes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testListDishOrderElements al listar las ordenes",e);
        }
    }

    /**
     * Metodo que prueba que el objeto Dish de la lista de platos no sea nulo
     */
    public void testRestaurantInvoiceIsNotNull() {

        try {
            cmd = facCmd.logicCurrentOrderCommand();
            cmd.run();
            listDishOrder = (List<DishOrder>) cmd.getResult();
            assertNotNull(listDishOrder.get(0).getDish());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testRestaurantInvoiceIsNotNull al listar las ordenes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testRestaurantInvoiceIsNotNull al listar las ordenes",e);
        }
    }

    /**
     * Metodo que prueba que la lista de platos no sea nula
     */
    public void testListDishOrderIsNotNull() {

        try {
            cmd = facCmd.logicCurrentOrderCommand();
            cmd.run();
            listDishOrder = (List<DishOrder>) cmd.getResult();
            assertNotNull(listDishOrder);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testListDishOrderIsNotNull al listar las ordenes",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testListDishOrderIsNotNull al listar las ordenes",e);
        }
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        facCmd = null;
        cmd = null;
        listDishOrder = null;
    }



}