package com.ds201625.fonda.tests.M5_Tests.M5_Tests.Login_Tests;

import android.test.MoreAsserts;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import junit.framework.Assert;
import junit.framework.TestCase;


/**
 * Clase De pruebas unitarias del comando addFavoriteRestaurant
 */
public class AddProfileCommandTest extends TestCase {

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
     * email de commensal logueado
     */
    private String email;

    /**
     * Variable tipo commensal
     */
    private Commensal commensal;
    /**
     * Variable tipo commensal
     */
    private Profile profile;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception {
        super.setUp();
        facCmd = FondaCommandFactory.getInstance();
        commensal = FondaEntityFactory.getInstance().GetCommensal();
        profile = FondaEntityFactory.getInstance().GetProfile();
        logedCommensal = FondaEntityFactory.getInstance().GetCommensal(1);
        email = "adri@hotmail.com";
    }

    /**
     *  Metodo para probar que el commensal que retorna y sus elementos no estan vacios
     */
    public void testAddFavoriteRestaurantCommandElements() {

        try {

            cmd = facCmd.createProfileCommand();
            cmd.setParameter(0,profile);
            cmd.run();
            boolean resp = (boolean)cmd.getResult();

            Assert.assertNotNull(resp);
            Assert.assertTrue(resp);
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
    }


}
