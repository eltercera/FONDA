package com.ds201625.fonda.data_access.retrofit_client.clients;

import com.ds201625.fonda.domains.entities.Commensal;
import com.ds201625.fonda.domains.entities.Restaurant;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
/**
 * Interfaz para ser implementada por retrofit
 * Define los recursos de /api/favorite(s) del
 * servicio web REST
 */
public interface FavoriteRestaurantClient {

    /**
     * Add /api/addfavorite/{idcommensal}/{idrestaurant}
     * Agrega un restaurante de la lista de favoritos
     * @param idCommensal identificador del comensal.
     * @param idRestaurant identificador del restaurante.
     * @return
     */
    @GET("addfavorite/{idcommensal}/{idrestaurant}")
    Call<Commensal> addfavoriterestaurant(@Path("idcommensal") int idCommensal ,@Path("idrestaurant") int idRestaurant);

    /**
     * Find /api/findRestaurantFavorites/{id}
     * Obtiene la lista de los restaurantes favoritos.
     * @param idCommensal identificador del comensal.
     * @return
     */
    @GET("findRestaurantFavorites/{id}")
    Call<List<Restaurant>> getAllFavoriteRestaurant(@Path("id") int idCommensal);

    /**
     * Delete /api/deletefavorite/{idcommensal}/{idrestaurant}
     * Elimina un restaurante de la lista de favoritos
     * @param idCommensal identificador del comensal.
     * @param idRestaurant identificador del restaurante.
     * @return
     */
    @GET("deletefavorite/{idcommensal}/{idrestaurant}")
    Call<Commensal> removefavoriterestaurant(@Path("idcommensal") int idCommensal, @Path("idrestaurant") int idRestaurant);
}
