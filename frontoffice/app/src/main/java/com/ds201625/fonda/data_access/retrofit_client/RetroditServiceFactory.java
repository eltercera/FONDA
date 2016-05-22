package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.factory.ServiceFactory;
import com.ds201625.fonda.data_access.services.AddFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.AllRestaurantService;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.DeleteFavoriteRestaurantService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.data_access.services.ZoneService;

/**
 * Implementacion de la fabrica de servicios con el uso de retrofit y localStorage.
 */
public class RetroditServiceFactory implements ServiceFactory {

    @Override
    public ProfileService getProfileService(Token token) {
        return new RetrofitProfileService(token);
    }

    @Override
    public CommensalService getCommensalService() {
        return new RetrofitCommensalService();
    }

    @Override
    public CurrentOrderService getCurrentOrderService() {
        return new RetrofitCurrentOrderService();

	}
	@Override
    public HistoryVisitsRestaurantService  getHistoryVisitsService() {
        return new RetrofitHistoryVisitsService();
    }

    @Override
    public TokenService getTokenService(Commensal commensal) {
        return new RetrofitTokenService(commensal);
    }

    @Override
    public AllRestaurantService getAllRestaurantService() {
        return new RetrofitAllRestaurantService();
    }

    @Override
    public AllFavoriteRestaurantService getAllFavoriteRestaurantsService() {
        return new RetrofitAllFavoriteRestaurantService();
    }

    @Override
    public AddFavoriteRestaurantService getAddFavoriteRestaurantService() {
        return new RetrofitAddFavoriteRestaurantService();
    }

    @Override
    public DeleteFavoriteRestaurantService getDeleteFavoriteRestaurantService() {
        return new RetrofitDeleteFavoriteRestaurant();
    }

    public InvoiceService getInvoiceService() {
        return new RetrofitInvoiceService();
    }

    public ZoneService getZoneService() { return new RetrofitZoneService();}
}
