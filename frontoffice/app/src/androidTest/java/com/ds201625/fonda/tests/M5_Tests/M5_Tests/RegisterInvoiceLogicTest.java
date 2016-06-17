package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Account;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.logic.LogicPayment;

import junit.framework.TestCase;

/**
 * Created by Adri 5/22/2016.
 */

/**
 * Clase De pruebas unitarias del registro de la factura en logic
 */
public class RegisterInvoiceLogicTest extends TestCase {


    /*
     Variable de tipo Invoice
    */
    private Invoice invoice;

    /*
      Variable de tipo Restaurant
     */
    private Restaurant restaurant;

    /*
     Variable de tipo Profile
   */
    private Profile profile;

    /*
     Variable de tipo Account
   */
    private Account account;

    /*
    Variable de tipo RestaurantCategory
  */
    private RestaurantCategory category;

    /*
    Variable de tipo Payment
  */
    private Payment payment;

    /*
   Variable de tipo lista de DishOrder
 */
    private DishOrder dishOrder;

    /*
   Variable de tipo PaymentService
 */
    private LogicPayment logicPayment;

    /*
   Variable de tipo Invoice para comparar
 */
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
     *  Metodo que prueba que una factura se registra
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
     *  Metodo que prueba que la factura al registrarse no sea nula
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

    /**
     *  Metodo que prueba que el restaurant en la factura se registra
     */
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
     *  Metodo que prueba que el restaurant en la factura no es nulo
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

    /**
     *  Metodo que prueba que el Profile en la factura se registra
     */
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
     *  Metodo que prueba que el Profile en la factura no es nulo
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

    /**
     *  Metodo que prueba que la CategoryRestaurant en el restaurant en la factura se registra
     */
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
     *  Metodo que prueba que la CategoryRestaurant en el restaurant en la factura no es nulo
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
     *  Metodo que prueba que el pago de la factura no sea nulo
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
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        invoice = null;
    }
}
