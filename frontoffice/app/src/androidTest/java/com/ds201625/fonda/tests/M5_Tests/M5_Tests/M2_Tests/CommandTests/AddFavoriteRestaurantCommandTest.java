package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.CommandTests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias del comando addFavoriteRestaurant
 */
public class AddFavoriteRestaurantCommandTest extends TestCase {

    /*
       fabrica de comandos
    */
    private FondaCommandFactory facCmd;

    /*
       Variable de tipo Command
    */
    private Command cmd;

    /**
     * id de comensal logueado
     */
    private Commensal logedCommensal;

    /**
     * id de restaurante seleccionado
     */
    private Restaurant selectedRestaurantAdd;

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
        commensal = FondaEntityFactory.getInstance().GetCommensal();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        selectedRestaurantAdd = FondaEntityFactory.getInstance().GetRestaurant(4);
        email = "adri@hotmail.com";
    }


    /**
     *  Metodo para probar que el restaurant es agregado en la lista de favoritos
     */
    public void testAddFavoriteRestaurantCommandIsNotNull() {

        try {

            cmd = facCmd.addFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.setParameter(1,selectedRestaurantAdd);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertNotNull(commensal);
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que el commensal que retorna no esta vacio
     */
    public void testAddFavoriteRestaurantCommandIsNotEmpty() {

        try {

            cmd = facCmd.addFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.setParameter(1,selectedRestaurantAdd);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertEquals(email, commensal.getEmail());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testAddFavoriteRestaurantCommandElements() {

        try {

            cmd = facCmd.addFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.setParameter(1,selectedRestaurantAdd);
            cmd.run();
            commensal = (Commensal) cmd.getResult();

            assertEquals(email, commensal.getEmail());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal agrego el restaurant
     */
    public void testAddFavoriteRestaurantCommandList() {

        try {

            cmd = facCmd.addFavoriteRestaurantCommand();
            cmd.setParameter(0,logedCommensal);
            cmd.setParameter(1,selectedRestaurantAdd);
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
        logedCommensal = null;
        selectedRestaurantAdd = null;
    }


}
