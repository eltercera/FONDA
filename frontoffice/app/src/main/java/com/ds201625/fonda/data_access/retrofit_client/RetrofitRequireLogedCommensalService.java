package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.RequireLogedCommensalClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.RequireLogedCommensalService;
import com.ds201625.fonda.domains.Commensal;

import java.io.IOException;

import retrofit2.Call;

/**
 * Created by jesus on 21/05/16.
 */
public class RetrofitRequireLogedCommensalService implements RequireLogedCommensalService {
    private RequireLogedCommensalClient currentLogedCommensal = RetrofitService.getInstance().
            createService(RequireLogedCommensalClient.class);

    public RetrofitRequireLogedCommensalService() {
        super();
    }

    @Override
    public Commensal getLogedCommensal(String fk1) {
        Call<Commensal> call = currentLogedCommensal.getAllFavoriteRestaurant(fk1);
        Commensal test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }
}

/*
*
*     private AllFavoriteRestaurantClient currentAllFavoriteRestaurantClient =
            RetrofitService.getInstance().createService(AllFavoriteRestaurantClient.class);

    public RetrofitAllFavoriteRestaurantService() {
        super();
    }

    @Override
    public List<Restaurant> getAllFavoriteRestaurant(int fk1) {

        Call<List<Restaurant>> call = currentAllFavoriteRestaurantClient.getAllFavoriteRestaurant(fk1);
        List<Restaurant> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return test;
    }
*
* */