package com.ds201625.fonda.domains.factory_entity;

import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;

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


    public Commensal GetCommensal()
    {
        return new Commensal();
    }

    public Commensal GetCommensal(int id)
    {
        return new Commensal(id);
    }

    public Restaurant GetRestaurant()
    {
        return new Restaurant();
    }

    public Restaurant GetRestaurant(int id)
    {
        return new Restaurant(id);
    }

    public Restaurant GetRestaurant(String name,String address, RestaurantCategory restaurantCategory)
    {
        return new Restaurant(name,address,restaurantCategory);
    }


}
