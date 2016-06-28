package com.ds201625.fonda.data_access.retrofit_client;

import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.clients.RestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.UnknownServerErrorException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.ServerErrorException;
import com.ds201625.fonda.data_access.services.RestaurantService;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.domains.Zone;
import java.io.IOException;
import java.util.List;
import retrofit2.Call;
import retrofit2.Response;

/**
 * Implementacion retrofit de RestaurantService
 */
public class RetrofitRestaurantService implements RestaurantService {

    /**
     * Cliente retrofit
     */
    private RestaurantClient resClient;

    public RetrofitRestaurantService(Token token) {
        super();
        resClient = RetrofitService.getInstance()
                .createService(RestaurantClient.class,token.getStrToken());
    }

    @Override
    public List<RestaurantCategory> getCategories(String query, int max, int page)
            throws RestClientException, ServerErrorException, UnknownServerErrorException {
        Call<List<RestaurantCategory>> call = resClient.getCategories(query, max, page);
        List<RestaurantCategory> categories = null;
        Response<List<RestaurantCategory>> respopnce = null;

        try {
            respopnce = call.execute();
        } catch (IOException e) {
            throw new RestClientException(e);
        }

        if (respopnce.isSuccessful()) {
            categories = respopnce.body();
        } else {
            if (respopnce.code() == 500) {
                throw new ServerErrorException();
            } else {
                throw UnknownServerErrorException.generate(respopnce.code(), respopnce.message());
            }
        }

        return categories;
    }

    @Override
    public List<Zone> getZones(String query, int max, int page)
            throws RestClientException, ServerErrorException, UnknownServerErrorException {
        Call<List<Zone>> call = resClient.getZones(query, max, page);
        List<Zone> zones = null;
        Response<List<Zone>> response = null;

        try {
            response = call.execute();
        } catch (IOException e) {
            throw new RestClientException(e);
        }

        if (response.isSuccessful()) {
            zones = response.body();
        } else {
            if (response.code() == 500) {
                throw new ServerErrorException();
            } else {
                throw UnknownServerErrorException.generate(response.code(), response.message());
            }
        }

        return zones;
    }

    @Override
    public List<Restaurant> getRestaurants(String query, int max, int page, int category, int zone)
            throws RestClientException, ServerErrorException, UnknownServerErrorException {
        Call<List<Restaurant>> call = resClient.getRestaurants(query, max, page, category, zone);
        List<Restaurant> restaurants = null;
        Response<List<Restaurant>> response = null;

        try {
            response = call.execute();
        } catch (IOException e) {
            throw new RestClientException(e);
        }

        if (response.isSuccessful()) {
            restaurants = response.body();
        } else {
            if (response.code() == 500) {
                throw new ServerErrorException();
            } else {
                throw UnknownServerErrorException.generate(response.code(), response.message());
            }
        }

        return restaurants;
    }

    @Override
    public void setRestaurantFab(boolean fab, int id)
        throws RestClientException, ServerErrorException, UnknownServerErrorException {
        Call<Void> call = null;
        Response<Void> response = null;

        if (fab)
            call = resClient.postCommensalRestaurants(id);
        else
            call = resClient.deleteCommensalRestaurants(id);

        try {
            response = call.execute();
        } catch (IOException e) {
            throw new RestClientException(e);
        }

        if (!response.isSuccessful()) {
            if (response.code() == 500) {
                throw new ServerErrorException();
            } else {
                throw UnknownServerErrorException.generate(response.code(), response.message());
            }
        }
    }
}