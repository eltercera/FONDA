package com.ds201625.fonda.data_access.factory;

import com.ds201625.fonda.data_access.retrofit_client.RetroditServiceFactory;
import com.ds201625.fonda.data_access.services.AddFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.DeleteFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.data_access.services.ZoneService;

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
     *
     * @return
     */
    public static FondaServiceFactory getInstance() {
        if (instance == null)
            instance = new FondaServiceFactory();

        return instance;
    }

    /**
     * Obtiene el servicio de Perfiles
     *
     * @return
     */
    public ProfileService getProfileService(Token token) {
        return serviceFactory.getProfileService(token);
    }

    /**
     * Obtiene ser servicio de comensal
     *
     * @return
     */
    public CommensalService getCommensalService() {
        return serviceFactory.getCommensalService();
    }


    public CurrentOrderService getCurrentOrderService() {
        return serviceFactory.getCurrentOrderService();

    }

    public HistoryVisitsRestaurantService getHistoryVisitsService() {
        return serviceFactory.getHistoryVisitsService();
    }

    /**
     * Obtiene os servicios de token
     *
     * @param commensal
     * @return
     */
    public TokenService getTokenService(Commensal commensal) {
        return serviceFactory.getTokenService(commensal);
    }


    /**
     * Obtiene los servicios de Comensal
     *
     * @param
     * @return
     */
    public AllRestaurantService getAllRestaurantsService() {
        return serviceFactory.getAllRestaurantService();
    }

    /**
     * Obtiene los servicios de Comensal
     *
     * @param
     * @return
     */
    public AllFavoriteRestaurantService getAllFavoriteRestaurantsService() {
        return serviceFactory.getAllFavoriteRestaurantsService();
    }

    /**
     * Obtiene los servicios de Comensal
     *
     * @param
     * @return
     */
    public AddFavoriteRestaurantService getAddFavortieRestaurantService() {
        return serviceFactory.getAddFavoriteRestaurantService();
    }

    /**
     * Obtiene los servicios de Comensal
     *
     * @param
     * @return
     */
    public DeleteFavoriteRestaurantService getDeleteFavoriteRestaurantService() {
        return serviceFactory.getDeleteFavoriteRestaurantService();
    }


    public InvoiceService getInvoiceService() {
        return serviceFactory.getInvoiceService();
    }

    public ZoneService getZoneService() {
        return serviceFactory.getZoneService();
    }

    public PaymentService setPaymentService(){
        return serviceFactory.setPaymentService();
    }
}

