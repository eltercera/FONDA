package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.MVPTest;

import android.util.Log;

import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.presenter.FavoritesPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 6/19/2016.
 */

/**
 * Clase De pruebas unitarias de DeleteFavoriteRestaurantMVPTest
 */
public class DeleteFavoriteRestaurantMVPTest extends TestCase implements FavoriteView {



    /**
     * restaurante seleccionado
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
    private String TAG = "DeleteFavoriteRestaurantMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();

        selectedRestaurantAdd = FondaEntityFactory.getInstance().GetRestaurant(2);
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
     *  Metodo para probar que se elimino un restaurant de la lista de favoritos de un comensal
     */
    public void testDeleteFavoriteRestaurant() {

        try {
            favoritesPresenter.findLoggedComensal();
            favoritesPresenter.deleteFavoriteRestaurant(selectedRestaurantAdd);
            listRestaurant = favoritesPresenter.findAllFavoriteRestaurant();
            assertNotSame(selectedRestaurantAdd.getName(), listRestaurant.get(1).getName());
        } catch (Exception e) {
            Log.e(TAG,"Error en testDeleteFavoriteRestaurant al eliminar favorito",e);
        }
    }

    /**
     *  Metodo para probar que existe una referencia nula y no se pudo eliminar el restaurant de la
     *  lista de favoritos de un comensal.
     */
    public void testDeleteFavoriteRestaurantIsNull() {

        try {
            selectedRestaurantAdd = FondaEntityFactory.getInstance().GetRestaurant(9);
            favoritesPresenter.findLoggedComensal();
            favoritesPresenter.deleteFavoriteRestaurant(selectedRestaurantAdd);
            assertNull(selectedRestaurantAdd);
        } catch (Exception e) {
            Log.e(TAG,"Error en testDeleteFavoriteRestaurant al eliminar favorito",e);
        }
    }


     /*Metodos de la interfaz FavoriteView*/

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
