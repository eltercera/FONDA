package com.ds201625.fonda.tests.M5_Tests.M5_Tests.M2_Tests.MVPTest;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.presenter.FavoritesPresenter;

import junit.framework.TestCase;

import java.util.List;

/**
 * Created by Adri on 6/19/2016.
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
            e.printStackTrace();
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
            e.printStackTrace();
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
