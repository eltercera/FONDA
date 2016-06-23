package com.ds201625.fonda.domains.factory_entity;

import com.ds201625.fonda.domains.BaseEntity;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Token;

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

    /**
     * Obtiene un comensal
     * @return comensal
     */
    public static Commensal GetCommensal()
    {
        return new Commensal();
    }

    /**
     * Obtiene un comensal por id
     * @param id
     * @return comensal
     */
    public static Commensal GetCommensal(int id)
    {
        return new Commensal(id);
    }

    /**
     * Obtiene un restaurante
     * @return restaurante
     */
    public static Restaurant GetRestaurant()
    {
        return new Restaurant();
    }

    /**
     * Obtiene Restaurante por id
     * @param id
     * @return restaurante
     */
    public static Restaurant GetRestaurant(int id)
    {
        return new Restaurant(id);
    }

    /**
     * Obtiene restaurante y la categoria
     * @param name
     * @param address
     * @param restaurantCategory
     * @return restaurante
     */
    public static Restaurant GetRestaurant(String name,String address, RestaurantCategory restaurantCategory)
    {
        return new Restaurant(name,address,restaurantCategory);
    }

    public Profile GetProfile() { return new Profile();}

    public Token GetToken() {return  new Token();}
}
