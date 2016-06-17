package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.entities.Account;
import com.ds201625.fonda.domains.entities.DishOrder;
import com.ds201625.fonda.domains.entities.Invoice;
import com.ds201625.fonda.domains.entities.Payment;
import com.ds201625.fonda.domains.entities.Profile;
import com.ds201625.fonda.domains.entities.Restaurant;
import com.ds201625.fonda.domains.entities.RestaurantCategory;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 21/05/2016.
 */

/**
 * Clase De pruebas unitarias del registro de la factura
 */
public class RegisterInvoiceTest extends TestCase {

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
    private List<DishOrder> listDish;

    /*
   Variable de tipo PaymentService
 */
    private PaymentService paymentService;

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
        payment = new Payment();
        paymentService = FondaServiceFactory.getInstance().setPaymentService();
    }

    /**
     *  Metodo que prueba que una factura se registra
     */
   public void testInvoice() {
       try {
           float a = 150;
       invoice.setTax(a);
           invoicePayment =  paymentService.setPayments(invoice);
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
            invoicePayment=  paymentService.setPayments(invoice);
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
            invoicePayment=  paymentService.setPayments(invoice);
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
            invoicePayment =  paymentService.setPayments(invoice);
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
            invoicePayment =  paymentService.setPayments(invoice);
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
            invoicePayment =  paymentService.setPayments(invoice);
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
            invoicePayment=  paymentService.setPayments(invoice);
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
            invoicePayment=  paymentService.setPayments(invoice);
            assertNotNull(invoicePayment);
        } catch (InvalidDataRetrofitException e) {
            e.printStackTrace();
        } catch (RestClientException e1) {
            e1.printStackTrace();
        }
    }

    /**
     *  Metodo que prueba que el Account en la factura no es nulo
     */
    public void testAccountInvoiceIsNotNull() {
        try {
            float amount = 80;
            invoice.setPayment(payment);
            invoice.getPayment().setAmount(amount);
            invoicePayment=  paymentService.setPayments(invoice);
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
