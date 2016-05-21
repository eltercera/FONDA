package com.ds201625.fonda.data_access.factory;

import com.ds201625.fonda.data_access.retrofit_client.RetroditServiceFactory;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;

/**
 * Singelton de fabrica de servicios
 */
public class FondaServiceFactory {

    /**
     * Instancia
     */
    private static FondaServiceFactory instance;

    /**
     * La fabrica implementada
     */
    private ServiceFactory serviceFactory;

    /**
     * Constructor
     * Usando Retrofit
     */
    private FondaServiceFactory() {
        serviceFactory = new RetroditServiceFactory();
    }

    /**
     * Obtiene la instancia
     * @return
     */
    public static FondaServiceFactory getInstance(){
        if (instance == null)
            instance = new FondaServiceFactory();

        return instance;
    }

    /**
     * Obtiene el servicio de Perfiles
     * @return
     */
    public ProfileService getProfileService(Token token)
    {
        return serviceFactory.getProfileService(token);
    }

    /**
     * Obtiene ser servicio de comensal
     * @return
     */
    public CommensalService getCommensalService(){
        return serviceFactory.getCommensalService();
    }


    public CurrentOrderService getCurrentOrderService(){
        return serviceFactory.getCurrentOrderService();

	}
	
    public HistoryVisitsRestaurantService getHistoryVisitsService(){
        return serviceFactory.getHistoryVisitsService();
    }

    /**
     * Obtiene os servicios de token
     * @param commensal
     * @return
     */
    public TokenService getTokenService(Commensal commensal){
        return serviceFactory.getTokenService(commensal);
    }


    /**
     * Obtiene los servicios de Comensal
     * @param
     * @return
     */
    public AllRestaurantService getAllFavoriteRestaurantsService(){
        return serviceFactory.getAllRestaurantService();
    }



}
