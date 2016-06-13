package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.ServiceTests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Katherina Molina on 11/06/2016.
 */

/**
 * Clase De pruebas unitarias del FavoriteRestaurantService
 */
public class FavoriteRestaurantServiceTest extends TestCase {

    /*
        Variable de la clase FavoriteRestaurantService
     */
    private FavoriteRestaurantService favoriteRestaurantService;
    /**
     * id de comensal logueado
     */
    private int logedCommensal;

    /**
     * id de restaurante seleccionado
     */
    private int selectedRestaurant;

    /**
     * email de commensal logueado
     */
    private String email;

    /**
     * Variable tipo commensal
     */
    private Commensal commensal;

    private List<Restaurant> restaurantList;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        favoriteRestaurantService = FondaServiceFactory.getInstance().getFavoriteRestaurantService();
        commensal = new Commensal();
        logedCommensal = 13;
        selectedRestaurant = 3;
        email = "adri@hotmail.com";
    }


    /**
     *  Metodo para probar que el restaurant es agregado en la lista de favoritos
     */
    public void testAddFavoriteRestaurantServiceIsNotNull() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);
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
    public void testAddFavoriteRestaurantServiceIsNotEmpty() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);
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
    public void testAddFavoriteRestaurantServiceElements() {

        try {
            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);

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
    public void testAddFavoriteRestaurantServiceList() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(3, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que el restaurant es eliminado en la lista de favoritos
     */
    public void testDeleteFavoriteRestaurantServiceIsNotNull() {

        try {

            commensal = favoriteRestaurantService.deleteFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);

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
    public void testDeleteFavoriteRestaurantServiceIsNotEmpty() {

        try {

            commensal = favoriteRestaurantService.deleteFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);

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
    public void testDeleteFavoriteRestaurantServiceElements() {

        try {

            commensal = favoriteRestaurantService.deleteFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);
            assertEquals(email, commensal.getEmail());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal elimino el restaurant
     */
    public void testDeleteFavoriteRestauranServiceList() {

        try {
            commensal = favoriteRestaurantService.deleteFavoriteRestaurant(logedCommensal,
                    selectedRestaurant);
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(2, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no es nula
     */
    public void testAllFavoriteRestaurantServiceIsNotNull() {

        try {

            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant(logedCommensal);

            assertNotNull(restaurantList);
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no esta vacia
     */
    public void testAllFavoriteRestaurantServiceIsNotEmpty() {

        try {

            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant(logedCommensal);

            MoreAsserts.assertNotEmpty(restaurantList);
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que los elementos de la lista no estan vacios
     */
    public void testAllFavoriteRestaurantServiceElements() {

        try {
            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant(logedCommensal);

            assertEquals("Pizza Familia", restaurantList.get(2).getName());
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
        favoriteRestaurantService = null;
        commensal = null;
        logedCommensal = 0;
        selectedRestaurant = 0;
    }


}
