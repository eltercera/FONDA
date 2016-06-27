
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
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;
import com.google.android.gms.appdatasearch.GetRecentContextCall;

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
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS ");
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());
                throw new GetProfilesFondaWebApiControllerException(error.exceptionType());
            }

        }  catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
            throw new NullPointerException("Error de conexion");
        }catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
            throw new GetProfilesFondaWebApiControllerException(error.exceptionType());
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
    public void addProfile(Profile profile) throws RestClientException, PostProfileFondaWebApiControllerException {
        Log.d(TAG, "Se Agrega un perfil al commensal logeado");
        Call<Profile> call = profileClient.postProfile(profile);
        Profile profileNew = null;
        Response<Profile> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                profileNew = response.body();
            } else {
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS ");
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());
                throw new PostProfileFondaWebApiControllerException(error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en addProfile", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en addProfile", e);
            throw new PostProfileFondaWebApiControllerException(error.exceptionType());
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
    public void editProfile(Profile profile) throws RestClientException, PutProfileFondaWebApiControllerException {
        Log.d(TAG, "Se Edita un perfil del commensal logeado");
        Call<Profile> call = profileClient.putProfile(profile,profile.getId());
        Profile profileNew = null;
        Response<Profile> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                profileNew = response.body();
            } else {
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS ");
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());
                throw new PutProfileFondaWebApiControllerException(error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en editProfile", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en editProfile", e);
            throw new PutProfileFondaWebApiControllerException(error.exceptionType());
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
    public void deleteProfile(int id) throws RestClientException, DeleteProfileFondaWebApiControllerException {
        Log.d(TAG, "Se Elimina un perfil del commensal logeado");
        Call<String> call = profileClient.DeleteProfile(id);
        String aux = null;
        Response<String> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                aux = response.body();
            } else {
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS ");
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());
                throw new DeleteProfileFondaWebApiControllerException(error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en deleteProfile", e);
            throw new RestClientException("Error de IO",e);
        }
        catch (Exception e) {
            Log.e(TAG, "Se ha generado error en deleteProfile", e);
            throw new DeleteProfileFondaWebApiControllerException(error.exceptionType());
        }
        Log.d(TAG, "Cierre del metodo eliminar perfil del commensal logeado "+ id);

    }
}
