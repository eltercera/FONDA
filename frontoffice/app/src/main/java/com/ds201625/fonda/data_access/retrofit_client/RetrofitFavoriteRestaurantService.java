package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.clients.FavoriteRestaurantClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.FavoriteRestaurantService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;

/**
 * Implementacion de la interfaz FavoriteRestaurantService
 */
public class RetrofitFavoriteRestaurantService implements FavoriteRestaurantService {
    private String TAG = "RetrofitFavoriteRestaurantService";
    private FavoriteRestaurantClient favoriteRestaurantClient =
            RetrofitService.getInstance().createService(FavoriteRestaurantClient.class);

    /**
     * Agrega un restaurante a favoritos
     *
     * @param idCommensal
     * @param idRestaurant
     * @return
     * @throws RestClientException
     */
    @Override
    public Commensal AddFavoriteRestaurant(int idCommensal, int idRestaurant) throws RestClientException {
        // aqui se supone que debo traerme el comensal Logeado
        Log.d(TAG, "Se agrega el restaurante "+idRestaurant+"a favoritos del comensal "+idCommensal);
        Call<Commensal> call = favoriteRestaurantClient.addfavoriterestaurant(idCommensal,idRestaurant);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en AddFavoriteRestaurant", e);
        }

        return rsvCommensal;
    }

    /**
     * Elimina un restaurante de favoritos
     *
     * @param idCommensal
     * @param idRestaurant
     * @return
     * @throws RestClientException
     */
    @Override
    public Commensal deleteFavoriteRestaurant(int idCommensal, int idRestaurant) throws RestClientException {
        Log.d(TAG, "Se elimina el restaurante "+idRestaurant+" de favoritos del comensal "+idCommensal);
        Call<Commensal> call = favoriteRestaurantClient.removefavoriterestaurant(idCommensal, idRestaurant);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en deleteFavoriteRestaurant", e);
        }

        return rsvCommensal;
    }

    /**
     * Obtiene todos los restaurantes favoritos
     *
     * @param idCommensal
     * @return
     * @throws RestClientException
     */
    @Override
    public List<Restaurant> getAllFavoriteRestaurant(int idCommensal) throws RestClientException {
        Log.d(TAG, "Se obtienen todos los restaurantes favoritos del comensal: "+idCommensal);
        Call<List<Restaurant>> call = favoriteRestaurantClient.getAllFavoriteRestaurant(idCommensal);
        List<Restaurant> test = null;
        try {
            test =call.execute().body();
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getAllFavoriteRestaurant", e);
        }

        return test;
    }

}

