package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.MVPTest;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.presenter.FavoritesPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 6/19/2016.
 */
public class FavoriteRestaurantMVPTest extends TestCase implements FavoriteView {

    /**
     * Variable lista de restaurantes favoritos
     */
    private List<Restaurant> restaurantList;

    /**
     * variable tipo FavoritePresenter
     */
    private FavoritesPresenter favoritesPresenter;

    private Restaurant restaurant;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        favoritesPresenter = new FavoritesPresenter(this);
        restaurant = FondaEntityFactory.getInstance().GetRestaurant();;
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        favoritesPresenter = null;
        restaurant = null;
    }


    /**
     *  Metodo para probar el consultar la lista de restaurant favoritos de un commensal.
     */
    public void testFindFavoriteRestaurants() {

        try {
            restaurant.setName("El Mundo del Pollo");
            favoritesPresenter.findLoggedComensal();
            restaurantList = favoritesPresenter.findAllFavoriteRestaurant();
            assertEquals(restaurant.getName(), restaurantList.get(1).getName());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar
     */
    public void testFindFavoriteRestaurant() {

        try {
            restaurant.getRestaurantCategory().setNameCategory("Chatarra");
            favoritesPresenter.findLoggedComensal();
            restaurantList = favoritesPresenter.findAllFavoriteRestaurant();
            assertEquals(restaurant.getRestaurantCategory().getNameCategory(),
                    restaurantList.get(1).getRestaurantCategory().getNameCategory());
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que no se pudo consultar la lista de favoritos por existencia dde una
     *  referencia nula.
     */
    public void testAddFavoriteRestaurantIsNull() {

        try {
            favoritesPresenter.findLoggedComensal();
            restaurantList = favoritesPresenter.findAllFavoriteRestaurant();
            assertNull(restaurantList.get(6));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *  Metodo para probar que la consulta de la lista de favoritos no es nula
     */
    public void testAdddFavoriteRestaurantIsNotNull() {

        try {
            favoritesPresenter.findLoggedComensal();
            restaurantList = favoritesPresenter.findAllFavoriteRestaurant();
            assertNotNull(restaurantList.get(3));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }




    @Override
    public List<Restaurant> getListSW() {
        return null;
    }

    @Override
    public void updateList() {

    }
}
