package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.factory.ServiceFactory;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;


public class RetroditServiceFactory implements ServiceFactory {

    @Override
    public ProfileService getProfileService() {
        return new RetrofitProfileService();
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
}
