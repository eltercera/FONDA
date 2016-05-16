package com.ds201625.fonda.data_access.factory;

import com.ds201625.fonda.data_access.retrofit_client.RetroditServiceFactory;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;

/**
 * Created by rrodriguez on 5/7/16.
 */
public class FondaServiceFactory {

    private static FondaServiceFactory instance;

    private ServiceFactory serviceFactory;

    private FondaServiceFactory() {
        serviceFactory = new RetroditServiceFactory();
    }

    public static FondaServiceFactory getInstance(){
        if (instance == null)
            instance = new FondaServiceFactory();

        return instance;
    }


    public ProfileService getProfileService()
    {
        return serviceFactory.getProfileService();
    }

    public CommensalService getCommensalService(){
        return serviceFactory.getCommensalService();
    }


    public CurrentOrderService getCurrentOrderService(){
        return serviceFactory.getCurrentOrderService();

	}
	
    public HistoryVisitsRestaurantService getHistoryVisitsService(){
        return serviceFactory.getHistoryVisitsService();
    }

    public TokenService getTokenService(Commensal commensal){
        return serviceFactory.getTokenService(commensal);
    }
}
