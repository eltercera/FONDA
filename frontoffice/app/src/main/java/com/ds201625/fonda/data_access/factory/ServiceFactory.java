package com.ds201625.fonda.data_access.factory;


import com.ds201625.fonda.data_access.services.*;
import com.ds201625.fonda.domains.Commensal;

/**
 * Interfaz para una fabrica de servivios.
 */
public interface ServiceFactory {

    /**
     * Obtiene el servicio de Perfiles
     * @return
     */
    ProfileService getProfileService();

    /**
     * Obtiene ser servicio de comensal
     * @return
     */
    CommensalService getCommensalService();

    CurrentOrderService getCurrentOrderService();

    HistoryVisitsRestaurantService getHistoryVisitsService();

    /**
     * Obtiene os servicios de token
     * @param commensal
     * @return
     */
    TokenService getTokenService(Commensal commensal);
}
