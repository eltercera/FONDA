package com.ds201625.fonda.tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.DishOrder;

import junit.framework.TestCase;


import java.util.List;

/**
 * Created by Katherina Molina on 19/05/2016.
 */
public class CurrentOrderServiceTest extends TestCase {


    private List<DishOrder> listDishOrder;
    private CurrentOrderService currentOrderService;


    protected void setUp() throws Exception {
        super.setUp();
        currentOrderService = FondaServiceFactory.getInstance().getCurrentOrderService();
    }

/*
 *  Metodo para probar que la lista esta vacia cuando no se ha conectado con el WS
 */
    public void testListDishOrderIsEmpty() {

        try {
            listDishOrder = currentOrderService.getListDishOrder();
            MoreAsserts.assertEmpty(listDishOrder);
            assertEquals(0, listDishOrder.size());
        }
        catch (NullPointerException e){}
    }

/*
 *  Metodo para probar que la lista no esta vacia cuando se conecta con el WS
 */
    public void testListDishOrderIsNotEmpty() {

        try {
            listDishOrder = currentOrderService.getListDishOrder();
            MoreAsserts.assertNotEmpty(listDishOrder);
            assertEquals(3, listDishOrder.size());
        }
        catch (NullPointerException e){
            fail("No esta conectado al WS");
        }
    }

    protected void tearDown() throws Exception {
        super.tearDown();
        listDishOrder = null;
    }

}
