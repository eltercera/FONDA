package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.MVPTest;

import android.util.Log;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.presenter.FavoritesPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 6/18/2016.
 */
public class AddFavoriteRestaurantMVPTest extends TestCase implements FavoriteView {


    /**
     * id de restaurante seleccionado
     */
    private Restaurant selectedRestaurantAdd;


    /**
     * variable tipo FavoritePresenter
     */
    private FavoritesPresenter favoritesPresenter;

    /**
     * lista de tipo Restaurant
     */
    private List<Restaurant> listRestaurant;
    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "AddFavoriteRestaurantMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();

        selectedRestaurantAdd = FondaEntityFactory.getInstance().GetRestaurant(1);
        favoritesPresenter = new FavoritesPresenter(this);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        favoritesPresenter = null;
        selectedRestaurantAdd = null;
    }

    /**
     *  Metodo para probar el registro de unr restaurant a la lista de favoritos de un comensal
     */
    public void testAddFavoriteRestaurant() {

        try {
            favoritesPresenter.findLoggedComensal();
            favoritesPresenter.addFavoriteRestaurant(selectedRestaurantAdd);
            listRestaurant = favoritesPresenter.findAllFavoriteRestaurant();
            assertEquals(selectedRestaurantAdd.getName(), listRestaurant.get(0).getName());
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurant al agregar favorito",e);
        }
    }



    /**
     *  Metodo para probar que el restaurant fue agregado y la lista no es nula
     */
    public void testAddFavoriteRestaurantIsNull() {

        try {
            selectedRestaurantAdd = FondaEntityFactory.getInstance().GetRestaurant(12);
            favoritesPresenter.findLoggedComensal();
            favoritesPresenter.addFavoriteRestaurant(selectedRestaurantAdd);
            assertNull(selectedRestaurantAdd);
            listRestaurant = favoritesPresenter.findAllFavoriteRestaurant();
            assertNotSame(selectedRestaurantAdd.getName(), listRestaurant.get(4).getName());
            assertNull(listRestaurant.get(4).getName());

        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurant al agregar favorito",e);
        }
    }

    /**
     *  Metodo para probar que el restaurant fue agregado y la lista no es nula
     */
    public void testAddFavoriteRestaurantIsNotNull() {

        try {
            favoritesPresenter.findLoggedComensal();
            favoritesPresenter.addFavoriteRestaurant(selectedRestaurantAdd);
            listRestaurant = favoritesPresenter.findAllFavoriteRestaurant();
            assertNotNull(listRestaurant.get(0));
        } catch (Exception e) {
            Log.e(TAG,"Error en testAddFavoriteRestaurant al agregar favorito",e);
        }
    }


    /**
     * Lista de todos los restaurantes favoritos
     *
     * @return restauraantes favoritos
     */
    @Override
    public List<Restaurant> getListSW() {
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {

    }
}
