package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.Account;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.logic.LogicPayment;

import junit.framework.TestCase;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Adri 5/22/2016.
 */
public class RegisterInvoiceLogicTest extends TestCase {


    /*
     Lista de Invoice que contiene los pagos de los restaurant
     */
    private Invoice invoice;

    private Restaurant restaurant;

    private Profile profile;

    private Account account;

    private RestaurantCategory category;

    private Payment payment;

    private DishOrder dishOrder;

    private LogicPayment logicPayment;

    private Invoice invoicePayment;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        invoice = new Invoice();
        restaurant = new Restaurant();
        category = new RestaurantCategory();
        account = new Account();
        profile= new Profile();
        dishOrder= new DishOrder();
        payment = new Payment();
        logicPayment = new LogicPayment();

    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testInvoice() {
        try {
            float a = 150;
            invoice.setTax(a);
            invoicePayment =  logicPayment.paymentService(invoice);
            assertEquals(invoicePayment.getTax(), invoice.getTax());
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testInvoiceIsNotNull() {
        try {
            float a = 150;
            invoice.setTax(a);
            invoicePayment =  logicPayment.paymentService(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    public void testRestaurantInvoice() {
        try {

            invoice.setRestaurant(restaurant);
            invoice.getRestaurant().setName("The dining room");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertEquals(invoicePayment.getRestaurant().getName(), invoice.getRestaurant().getName());
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testRestaurantInvoiceNotNull() {
        try {
            invoice.setRestaurant(restaurant);
            invoice.getRestaurant().setName("The dining room");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }


    public void testProfileInvoice() {
        try {

            invoice.setProfile(profile);
            invoice.getProfile().setProfileName("Adriana Da Rocha");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertEquals(invoicePayment.getProfile().getProfileName(), invoice.getProfile().getProfileName());
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testProfileInvoiceNotNull() {
        try {
            invoice.setProfile(profile);
            invoice.getProfile().setProfileName("Adriana Da Rocha");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    public void testCategoryRestaurantInvoice() {
        try {

            restaurant.setRestaurantCategory(category);
            invoice.setRestaurant(restaurant);
            invoice.getRestaurant().getRestaurantCategory().setNameCategory("Romantico");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertEquals(invoicePayment.getRestaurant().getRestaurantCategory().getNameCategory(),
                    invoice.getRestaurant().getRestaurantCategory().getNameCategory());
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testCategoryRestaurantInvoiceIsNotNull() {
        try {
            restaurant.setRestaurantCategory(category);
            invoice.setRestaurant(restaurant);
            invoice.getRestaurant().getRestaurantCategory().setNameCategory("Romantico");
            invoicePayment =  logicPayment.paymentService(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }


    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */
    public void testPaymentInvoiceIsNotNull() {
        try {
            float amount = 80;
            invoice.setPayment(payment);
            invoice.getPayment().setAmount(amount);
            invoicePayment =  logicPayment.paymentService(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que la lista de pagos no esta vacia cuando  se conecta con el WS
     */




    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
    }
}
