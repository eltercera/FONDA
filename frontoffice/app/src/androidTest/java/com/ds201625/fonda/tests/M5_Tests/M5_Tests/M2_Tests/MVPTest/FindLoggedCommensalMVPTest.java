package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.MVPTest;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.views.contracts.FavoriteView;
import com.ds201625.fonda.views.presenters.FavoritesPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 6/19/2016.
 */
/**
 * Clase De pruebas unitarias de FindLoggedCommensalMVPTest
 */
public class FindLoggedCommensalMVPTest extends TestCase implements FavoriteView {

    /**
     * variable tipo FavoritePresenter
     */
    private FavoritesPresenter favoritesPresenter;

    /**
     * id de comensal logueado
     */
    private Commensal logedCommensal;

    /**
     * Variable String que indica la clase actual
     */
    private String TAG = "FindLoggedCommensalMVPTest";

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(13);
        favoritesPresenter = new FavoritesPresenter(this);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void tearDown() throws Exception {
        super.tearDown();
        favoritesPresenter = null;
        logedCommensal = null;
    }

    /**
     *  Metodo para probar el login del comensal.
     */
    public void testFindLoggedCommensal() {

        try {

            favoritesPresenter.findLoggedComensal();
            assertEquals(logedCommensal, favoritesPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }


    /**
     *  Metodo para probar que no se pudo consultar el logged del commensal por existencia de una
     *  referencia nula.
     */
    public void testFindLoggedCommensalIsNull() {

        try {
            logedCommensal = FondaEntityFactory.getInstance().GetCommensal(6);
            favoritesPresenter.findLoggedComensal();
            assertNotSame(logedCommensal, favoritesPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
        }
    }

    /**
     *  Metodo para probar que la consulta del comensal no es nnula
     */
   public void testFindLoggedCommensalIsNotNull() {

        try {
            favoritesPresenter.findLoggedComensal();
            assertNotNull(favoritesPresenter);
        } catch (Exception e) {
            Log.e(TAG,"Error en testFindLoggedCommensal al buscar el comensal logueado",e);
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
