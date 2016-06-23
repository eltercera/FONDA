package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.CommensalClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.AddCommensalWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;


import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;

/**
 * Implementacion de la interfaz CommensalService
 */
public class RetrofitCommensalService implements CommensalService {
    private String TAG = "RetrofitCommensalService";
    /**
     * Instancia cliente rest CommensalClient
     */
    private CommensalClient commensalClient =
            RetrofitService.getInstance().createService(CommensalClient.class);

    /**
     * Instancia para los archivos locales de commensal.
     */
    private JsonFile<Commensal> localFile;

    @Override
    public Commensal RegisterCommensal(String user, String password, Context context)
            throws InvalidDataRetrofitException, RestClientException, LocalStorageException {
        Log.d(TAG, "Se registra un commensal");
        if (user.isEmpty() || password.isEmpty())
            throw new InvalidDataRetrofitException("Usuario o password son vacios.");

        Commensal commensal = new Commensal();
        commensal.setEmail(user);
        commensal.setPassword(password);
        Call<Commensal> call = commensalClient.registerCommensal(commensal);
        Commensal rsvCommensal = null;
        Response<Commensal> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                rsvCommensal = response.body();
            } else {
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS "+ error.exceptionType());
                throw new AddCommensalWebApiControllerException(error.exceptionType());
            }
        }  catch (IOException e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en getProfiles", e);
        }
        Log.d(TAG, "Cierre del metodo registrar commensal "+ rsvCommensal.toString());

        getFile(context).save(rsvCommensal);
        return rsvCommensal;
    }




    /**
     * Obtiene una instancia del de JsonFile de tipo Commensal.
     * @param context Contecto de la aplicacion.
     * @return la instancia JsonFile de tipo Commensal.
     */
    private JsonFile<Commensal> getFile(Context context) {

        if (localFile == null)
            localFile = new JsonFile<Commensal>("CommensalLocal", context,Commensal.class);

        return localFile;
    }

    @Override
    public Commensal getCommensal(Context context) throws LocalStorageException {
        return getFile(context).getObj();
    }

    @Override
    public void saveCommensal(Commensal commensal, Context context) throws LocalStorageException {
        if (commensal!= null) {
            getFile(context).save(commensal);
        }
    }

    @Override
    public void deleteCommensal(Context context) throws LocalStorageException {
        Commensal commensal = null;
        getFile(context).save(commensal);
    }
}
