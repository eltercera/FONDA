package com.ds201625.fonda.domains.factory_entity;

import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.entities.*;

import java.util.List;

/**
 * Created by Katherina Molina on 16/06/2016.
 */

/* Fabrica que instancia las entidades del dominio*/

public class FondaEntityFactory {


    /**
     * Instancia Singelton de la fabrica
     */
    private static FondaEntityFactory instance;

    /**
     * Obtiene la instancio singelton de la fabrica
     * @return instancio singelton de la fabrica
     */
    public static FondaEntityFactory getInstance() {
        if (instance == null)
            instance = new FondaEntityFactory();

        return instance;
    }

    public FondaEntityFactory() {  }


    //Instancia los objetos del dominio invocando al constructor(es) de la entidad


    public BaseEntity GetCommensal()
    {
        return new Commensal();
    }

    public BaseEntity GetCommensal(int id)
    {
        return new Commensal(id);
    }

    public BaseEntity GetRestaurant()
    {
        return new Restaurant();
    }

    public BaseEntity GetRestaurant(int id)
    {
        return new Restaurant(id);
    }

    public BaseEntity GetRestaurant(String name,String address, RestaurantCategory restaurantCategory)
    {
        return new Restaurant(name,address,restaurantCategory);
    }


}
