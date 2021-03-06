package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.ServiceTests;

import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;

import junit.framework.TestCase;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias de RequireLogedService
 */
public class RequireLogedCommensalServiceTest extends TestCase {

    /*
        Variable de la clase AllRestaurantService
     */
    private RequireLogedCommensalService requireLogedCommensal;

    /**
     * email de commensal logueado
     */
    private String email;

    /**
     * Variable tipo commensal
     */
    private Commensal commensal;
    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "RequireLogedCommensalServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        requireLogedCommensal = FondaServiceFactory.getInstance().getLogedCommensalService();
        commensal = FondaEntityFactory.getInstance().GetCommensal();
        email = "adri@hotmail.com";
    }


    /**
     *  Metodo para probar que el comensal logueado no sea nulo
     */
    public void testLogedCommensalServiceIsNotNull() {

        try {

            commensal = requireLogedCommensal.getLogedCommensal(email);

            assertNotNull(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testLogedCommensalServiceIsNotNull al" +
                    " obtener el comensal logueado",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testLogedCommensalServiceIsNotNull al" +
                    " obtener el comensal logueado",e);
        }
    }


    /**
     *  Metodo para probar que el commensal que retorna no esta vacio
     */
    public void testLogedCommensalServiceIsNotEmpty() {

        try {

            commensal = requireLogedCommensal.getLogedCommensal(email);

            assertEquals(13, commensal.getId());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testLogedCommensalServiceIsNotEmpty al" +
                    " obtener el comensal logueado",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testLogedCommensalServiceIsNotEmpty al" +
                    " obtener el comensal logueado",e);
        }
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testLogedCommensalServiceElements() {

        try {

            commensal = requireLogedCommensal.getLogedCommensal(email);

            assertEquals(email, commensal.getEmail());
            assertEquals(13, commensal.getId());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testLogedCommensalServiceElements al" +
                    " obtener el comensal logueado",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testLogedCommensalServiceElements al" +
                    " obtener el comensal logueado",e);
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal logueado no este vacia
     */
    public void testLogedCommensalServiceList() {

        try {
            commensal = requireLogedCommensal.getLogedCommensal(email);
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(3, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            Log.e(TAG, "Error en testLogedCommensalServiceList al" +
                    " obtener el comensal logueado",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testLogedCommensalServiceList al" +
                    " obtener el comensal logueado",e);
        }
    }

    /**
     *  Metodo para probar que el commensal que se loguea es nulo
     */
    public void testtLogedCommensalIsNull() {
        try {

            commensal = requireLogedCommensal.getLogedCommensal("yuneth@gmail.com");
            assertNull(commensal);

        }  catch(NullPointerException e) {
            Log.e(TAG, "Error en testtLogedCommensalIsNull al" +
                    " obtener el comensal logueado",e);
        }
        catch(Exception e) {
            Log.e(TAG, "Error en testtLogedCommensalIsNull al" +
                    " obtener el comensal logueado",e);
        }
        }


    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        requireLogedCommensal = null;
        commensal = null;
    }


}
