package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.CommandTests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias del comando RequireLogedCommensal
 */
public class RequireLogedCommensalCommandTest extends TestCase {

    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
       Variable de tipo Command
    */
    private Command cmd;


    /**
     * email de commensal logueado
     */
    private String email;

    /**
     * Variable tipo commensal
     */
    private Commensal commensal;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
        commensal = new Commensal();
        email = "adri@hotmail.com";
    }


    /**
     *  Metodo para probar que el comensal logueado no sea nulo
     */
    public void testLogedCommensalCommandIsNotNull() {

        try {

            cmd = facCmd.requireLogedCommensalCommand();
            cmd.setParameter(0,email);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertNotNull(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que el commensal que retorna no esta vacio
     */
    public void testLogedCommensalCommandIsNotEmpty() {

        try {

            cmd = facCmd.requireLogedCommensalCommand();
            cmd.setParameter(0,email);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertEquals(13, commensal.getId());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testLogedCommensalCommandElements() {

        try {

            cmd = facCmd.requireLogedCommensalCommand();
            cmd.setParameter(0,email);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertEquals(email, commensal.getEmail());
            assertEquals(13, commensal.getId());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal logueado no este vacia
     */
    public void testLogedCommensalCommandList() {

        try {

            cmd = facCmd.requireLogedCommensalCommand();
            cmd.setParameter(0,email);
            cmd.run();
            commensal = (Commensal) cmd.getResult();
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(3, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
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
        commensal = null;
    }


}
