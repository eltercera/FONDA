package com.ds201625.fonda.data_access.factory;

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
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.data_access.services.ZoneService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;

/**
 * Interfaz para una fabrica de servivios.
 */
public interface ServiceFactory {

    /**
     * Obtiene el servicio de Perfiles
     * @return
     */
    ProfileService getProfileService(Token token);

    /**
     * Obtiene ser servicio de comensal
     * @return
     */
    CommensalService getCommensalService();

    /**
     * Obtiene el servicio de platos ordenados
     * @return
     */
    CurrentOrderService getCurrentOrderService();

    /**
     * Obtiene el servicio de historial de visitas
     * @return
     */
    HistoryVisitsRestaurantService getHistoryVisitsService();

    /**
     * Obtiene os servicios de token
     * @param commensal
     * @return
     */
    TokenService getTokenService(Commensal commensal);


    /**
     * Obtiene los servicios de todos los restaurantes
     * @return
     */
    AllRestaurantService getAllRestaurantService();

    /**
     * Agrega un restaurante favorito a un comensal logeado
     * @return
     */
    FavoriteRestaurantService getFavoriteRestaurantService();

    ReservationService getReservesService(Token token);

    /**
     * Devuelve a un comensal logeado
     * @return
     */
    RequireLogedCommensalService getLogedCommensalService();
    /**
     * Obtiene el servicio de factura
     * @return
     */
    InvoiceService getInvoiceService();

    ZoneService getZoneService();

    CategoryService getCategoryService();

    /**
     * Obtiene el servicio de pago
     * @return
     */
    PaymentService setPaymentService();

    FilterByZoneService getFilterByZoneService();

    FilterByCategoryService getFilterByCategoryService();



    /**
     * Obtiene los servicios de los restaurantes
     * @return
     */
    RestaurantService getRestaurantService(Token token);

}

