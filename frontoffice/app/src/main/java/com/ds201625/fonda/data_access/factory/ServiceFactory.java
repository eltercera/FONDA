package com.ds201625.fonda.data_access.factory;
import com.ds201625.fonda.data_access.services.*;
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
     * @param
     * @return
     */
    AllRestaurantService getAllRestaurantService();


    /**
     * Obtiene los servicios de todos los restaurantes Favoritos
     * @param
     * @return
     */
    AllFavoriteRestaurantService getAllFavoriteRestaurantsService();

    /**
     * Agrega un restaurante favorito a un comensal logeado
     * @param
     * @return
     */
    AddFavoriteRestaurantService getAddFavoriteRestaurantService();

    /**
     * Elimina un restaurante favorito a un comensal logeado
     * @param
     * @return
     */
    DeleteFavoriteRestaurantService getDeleteFavoriteRestaurantService();

    /**
     * Obtiene el servicio de factura
     * @return
     */
    InvoiceService getInvoiceService();

    ZoneService getZoneService();

    CategoryService getCategoryService();

    /**
     * Obtiene el servicio de pagar
     * @return
     */
    PaymentService setPaymentService();
}


