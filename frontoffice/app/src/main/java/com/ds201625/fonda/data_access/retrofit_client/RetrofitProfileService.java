
package com.ds201625.fonda.data_access.retrofit_client;

import android.util.Log;
import com.ds201625.fonda.data_access.retrofit_client.clients.ProfileClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PutProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.domains.factory_entity.APIError;
import java.io.IOException;
import java.util.List;
import retrofit2.Call;
import retrofit2.Response;

/**
 * Implementacion de la interfaz ProfileService
 */
public class RetrofitProfileService implements ProfileService {
    private String TAG = "RetrofitProfileService";
    /**
     * Instancia cliente rest ProfileClient
     */
    private ProfileClient profileClient;

    private APIError error;

    /**
     * Constructor de RetrofitProfileService
     * @param token
     */
    public RetrofitProfileService(Token token) {
        super();
        profileClient = RetrofitService.getInstance()
                .createService(ProfileClient.class,token.getStrToken());
    }

    /**
     * Busca los perfiles de un commensal
     * @return una lista de perfiles
     * @throws RestClientException
     */
    @Override
    public List<Profile> getProfiles() throws Exception {
        Log.d(TAG, "Se Buscan los perfiles del commensal logeado");
        Call<List<Profile>> call = profileClient.getProfiles();
        List<Profile> profiles = null;
        Response<List<Profile>> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                profiles = response.body();
            } else {
                Log.e(TAG, "Se ha generado error en WS ");
                throw new GetProfilesFondaWebApiControllerException("Error del Servicio Web " +
                        "al buscar los perfiles");
            }

        }  catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
            throw new RestClientException("Error de IO",e);
        }
        Log.d(TAG, "Cierre del metodo buscar perfiles del commensal logeado "+ profiles.toString());
        return profiles;
    }

    /**
     * Agrega un perfil
     * @param profile
     * @throws RestClientException
     * @throws PostProfileFondaWebApiControllerException
     */
    @Override
    public void addProfile(Profile profile) throws Exception {
        Log.d(TAG, "Se Agrega un perfil al commensal logeado");
        if (profile == null) {
            throw new InvalidDataRetrofitException("Perfil Nulo");
        }
        Call<Profile> call = profileClient.postProfile(profile);
        Profile profileNew = null;
        Response<Profile> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                profileNew = response.body();
            } else {
                Log.e(TAG, "Se ha generado error en WS ");
                throw new PostProfileFondaWebApiControllerException("Error del Servicio Web " +
                        "al agregar un perfil");
            }
        }  catch (IOException e) {
            Log.e(TAG, "Se ha generado error en addProfile", e);
            throw new RestClientException("Error de IO",e);
        }
        Log.d(TAG, "Cierre del metodo agregar perfil al commensal logeado "+ profile.toString());
    }

    /**
     * Edita un perfil
     * @param profile
     * @throws RestClientException
     * @throws PutProfileFondaWebApiControllerException
     */
    @Override
    public void editProfile(Profile profile) throws Exception {
        Log.d(TAG, "Se Edita un perfil del commensal logeado");
        if (profile == null) {
            throw new InvalidDataRetrofitException("Perfil Nulo");
        }
        Call<Profile> call = profileClient.putProfile(profile,profile.getId());
        Profile profileNew = null;
        Response<Profile> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                profileNew = response.body();
            } else {
                Log.e(TAG, "Se ha generado error en WS ");
                throw new PutProfileFondaWebApiControllerException("Error del Servicio Web " +
                        "al editar un perfil");
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en editProfile", e);
            throw new RestClientException("Error de IO",e);
        }
        Log.d(TAG, "Cierre del metodo editar perfil del commensal logeado "+ profile.toString());
    }

    /**
     * Elimina un perfil
     * @param id
     * @throws RestClientException
     * @throws DeleteProfileFondaWebApiControllerException
     */
    @Override
    public void deleteProfile(int id) throws Exception {
        Log.d(TAG, "Se Elimina un perfil del commensal logeado");
        if (id <= 0) {
            throw new InvalidDataRetrofitException("Id de Perfil Erroneo.");
        }
        Call<String> call = profileClient.DeleteProfile(id);
        String aux = null;
        Response<String> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                aux = response.body();
            } else {
                Log.e(TAG, "Se ha generado error en WS ");
                throw new DeleteProfileFondaWebApiControllerException("Error del Servicio Web " +
                        "al eliminar un perfil");
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en deleteProfile", e);
            throw new RestClientException("Error de IO",e);
        }
        Log.d(TAG, "Cierre del metodo eliminar perfil del commensal logeado "+ id);

    }
}
