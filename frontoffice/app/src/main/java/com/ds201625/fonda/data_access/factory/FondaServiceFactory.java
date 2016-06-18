package com.ds201625.fonda.data_access.factory;

import com.ds201625.fonda.data_access.retrofit_client.RetroditServiceFactory;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.CategoryService;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.FilterByCategoryService;
import com.ds201625.fonda.data_access.services.FilterByZoneService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.data_access.services.ZoneService;
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

    /**
     * Obtiene ser servicio de orden actual
     * @return
     */
    public CurrentOrderService getCurrentOrderService(){
        return serviceFactory.getCurrentOrderService();

	}

    /**
     * Obtiene ser servicio de historial de visitas
     * @return
     */
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
     * Obtiene los servicios de restaurantes
     * @param
     */
    public AllRestaurantService getAllRestaurantsService(){
        return serviceFactory.getAllRestaurantService();
    }


    /**
     * Obtiene los servicios de restaurantes favoritos
     * @param
     */
    public FavoriteRestaurantService getFavoriteRestaurantService(){
        return serviceFactory.getFavoriteRestaurantService();
    }

    /**
     * Obtiene ser servicio de factura
     * @return
     */
    public InvoiceService getInvoiceService(){
        return serviceFactory.getInvoiceService();
    }

    /**
     * Obtiene las zonas
     * @return
     */
    public ZoneService getZoneService() {
        return serviceFactory.getZoneService();
    }

    /**
     * Obtiene ser servicio de pago
     * @return
     */
    public PaymentService setPaymentService() {
        return serviceFactory.setPaymentService();
    }

    /**
     * Obtiene las categorias
     * @return
     */
    public CategoryService getCategoryService(){
        return serviceFactory.getCategoryService();
    }

    /**
     * Obtiene los restaurantes filtrados por zona
     * @return
     */
    public FilterByZoneService getFilterByZoneService(){
        return serviceFactory.getFilterByZoneService();
    }

    public FilterByCategoryService getFilterByCategoryService(){
        return serviceFactory.getFilterByCategoryService();
    }

    /**
     * Obtiene los servicios de Comensal
     * @param
     * @return
     */
    public ReservationService getAllReservesService(){
        return serviceFactory.getAllReservesService();
    }

    /**
     * Obtiene los servicios de commensal logueado
     * @return
     */
    public RequireLogedCommensalService getLogedCommensalService(){
      return  serviceFactory.getLogedCommensalService();
    };
}

