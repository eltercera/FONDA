package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.ServiceTests;

import android.content.Entity;
import android.test.MoreAsserts;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import junit.framework.TestCase;

import java.io.IOException;
import java.util.List;

/**
 * Clase De pruebas unitarias del FavoriteRestaurantService
 */
public class FavoriteRestaurantServiceTest extends TestCase {

    /*
        Variable de la clase FavoriteRestaurantService
     */
    private FavoriteRestaurantService favoriteRestaurantService;
    /**
     *  comensal logueado
     */
    private Commensal logedCommensal;

    /**
     * restaurante seleccionado
     */
    private Restaurant selectedRestaurant;

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
     * Variable String que indica la clase actual
     */
    private String TAG = "FavoriteRestaurantServiceTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        favoriteRestaurantService =
                FondaServiceFactory.getInstance().getFavoriteRestaurantService();
        commensal = FondaEntityFactory.getInstance().GetCommensal();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        selectedRestaurant = FondaEntityFactory.getInstance().GetRestaurant(2);
        email = "adri@hotmail.com";
    }


    /**
     *  Metodo para probar que el restaurant es agregado en la lista de favoritos
     */
    public void testAddFavoriteRestaurantServiceIsNotNull() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            assertNotNull(commensal.getId());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceIsNotNull al agregar favorito",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceIsNotNull al agregar favorito",e);
        }
    }


    /**
     *  Metodo para probar que el commensal que retorna no esta vacio
     */
    public void testAddFavoriteRestaurantServiceIsNotEmpty() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            assertEquals(email, commensal.getEmail());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceIsNotEmpty al agregar favorito",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceIsNotEmpty al agregar favorito",e);
        }
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testAddFavoriteRestaurantServiceElements() {

        try {
            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());

            assertEquals(email, commensal.getEmail());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceElements al agregar favorito",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceElements al agregar favorito",e);
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal agrego el restaurant
     */
    public void testAddFavoriteRestaurantServiceList() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(3, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceList al agregar favorito",e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurantServiceList al agregar favorito",e);
        }
    }


    /**
     *  Metodo para probar que el restaurant es eliminado en la lista de favoritos
     */
    public void testDeleteFavoriteRestaurantServiceIsNotNull() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());

            assertNotNull(commensal.getId());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceIsNotNull al" +
                    " eliminar los restaurantes faoritos",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceIsNotNull al" +
                    " eliminar los restaurantes faoritos",e);
        }
    }


    /**
     *  Metodo para probar que el commensal que retorna no esta vacio
     */
    public void testDeleteFavoriteRestaurantServiceIsNotEmpty() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            assertEquals(email, commensal.getEmail());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceIsNotEmpty al" +
                    " eliminar los restaurantes faoritos",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceIsNotEmpty al" +
                    " eliminar los restaurantes faoritos",e);
        }
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testDeleteFavoriteRestaurantServiceElements() {

        try {

            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            assertEquals(email, commensal.getEmail());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
        } catch (RestClientException e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceElements al" +
                    " eliminar los restaurantes faoritos",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestaurantServiceElements al" +
                    " eliminar los restaurantes faoritos",e);
        }
    }

    /**
     *  Metodo para probar que la lista de favoritos del commensal elimino el restaurant
     */
    public void testDeleteFavoriteRestauranServiceList() {

        try {
            commensal = favoriteRestaurantService.AddFavoriteRestaurant(logedCommensal.getId(),
                    selectedRestaurant.getId());
            MoreAsserts.assertNotEmpty(commensal.getFavoritesRestaurants());
            assertEquals(2, commensal.getFavoritesRestaurants().size());

        } catch (RestClientException e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestauranServiceList al" +
                    " eliminar los restaurantes faoritos",e);
        } catch (Exception e) {
            Log.e(TAG, "Error en testDeleteFavoriteRestauranServiceList al" +
                    " eliminar los restaurantes faoritos",e);
        }
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no es nula
     */
    public void testAllFavoriteRestaurantServiceIsNotNull() {

        try {

            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant
                    (logedCommensal.getId());

            assertNotNull(restaurantList.get(0).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceIsNotNull al listar los favoritos",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceIsNotNull al listar los favoritos",
                    e);
        }
    }


    /**
     *  Metodo para probar que la lista de favoritos de un comensal no esta vacia
     */
    public void testAllFavoriteRestaurantServiceIsNotEmpty() {

        try {

            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant
                    (logedCommensal.getId());

            MoreAsserts.assertNotEmpty(restaurantList);
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceIsNotEmpty al listar los favoritos",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceIsNotEmpty al listar los favoritos",
                    e);
        }
    }

    /**
     *  Metodo para probar que los elementos de la lista no estan vacios
     */
    public void testAllFavoriteRestaurantServiceElements() {

        try {
            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant
                    (logedCommensal.getId());

            assertEquals("Pizza Familia", restaurantList.get(2).getName());
        } catch (RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceElements al listar los favoritos",
                    e);
        } catch (Exception e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantServiceElements al listar los favoritos",
                    e);
        }
    }

    /**
     * Metodo para probar que los elementos de la lista no son nulos
     */
    public void testAllFavoriteRestaurantIsNull() {
        try {
            Commensal prueba = FondaEntityFactory.getInstance().GetCommensal(14);
            restaurantList =favoriteRestaurantService.getAllFavoriteRestaurant(prueba.getId());
            assertNull(restaurantList);

        } catch(RestClientException e) {
            Log.e(TAG,"Error en testAllFavoriteRestaurantIsNull al listar los favoritos",
                    e);
        }
          catch(NullPointerException e) {
              Log.e(TAG,"Error en testAllFavoriteRestaurantIsNull al listar los favoritos",
                      e);
          }

    }

    /**
     * Metodo para probar que los elementos favoritos no son nulos
     */
    public void testAddFavoriteRestauranIsNull() {
        try {
            Commensal prueba = FondaEntityFactory.getInstance().GetCommensal(14);
            commensal = favoriteRestaurantService.AddFavoriteRestaurant(prueba.getId(),
                    selectedRestaurant.getId());
            assertNull(commensal);

        } catch(RestClientException e) {
            Log.e(TAG,"Error en testAddFavoriteRestauranIsNull al agregar favoritos",
                    e);
        }
        catch(NullPointerException e) {
            Log.e(TAG,"Error en testAddFavoriteRestauranIsNull al agregar favoritos",
                    e);
        }

    }
    /**
     * Metodo para probar que los elementos eliminados no son nulos
     */
    public void testDeleteFavoriteRestauranIsNull() {
        try {
            Commensal prueba = FondaEntityFactory.getInstance().GetCommensal(14);
            commensal = favoriteRestaurantService.deleteFavoriteRestaurant(prueba.getId(),
                    selectedRestaurant.getId());
            assertNull(commensal);

        } catch(RestClientException e) {
            Log.e(TAG,"Error en testDeleteFavoriteRestauranIsNull al eliminar favoritos",
                    e);
        }
        catch(NullPointerException e) {
            Log.e(TAG,"Error en testDeleteFavoriteRestauranIsNull al eliminar favoritos",
                    e);
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
        logedCommensal = null;
        selectedRestaurant = null;
    }


}
