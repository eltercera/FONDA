
package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.clients.TokenClient;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteTokenFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetTokenFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.domains.factory_entity.APIError;
import com.ds201625.fonda.logic.ExceptionHandler.ErrorUtils;

import java.io.IOException;
import java.util.List;

import retrofit2.Call;
import retrofit2.Response;

/**
 * Implementacion de la interfaz TokenService
 */
public class RetrofitTokenService implements TokenService{
    private String TAG = "RetrofitTokenService";
    private TokenClient tokenClient;
    private APIError error;
    private Commensal commensal;

    private JsonFile<Token> localFile;

    /**
     * Instancia cliente rest TokenClient
     * @param commensal
     */
    public RetrofitTokenService(Commensal commensal) {
        tokenClient = RetrofitService.getInstance().createService(
                TokenClient.class,commensal.getEmail(), commensal.getPassword());
        this.commensal = commensal;
        Log.v("Fonda",this.commensal.getEmail());
    }

    /**
     * Crea un token
     * @param context
     * @return
     * @throws Exception
     */
    @Override
    public Token createToken(Context context) throws Exception {
        Log.d(TAG, "Se crear Token");
        Call<Token> call = tokenClient.postToken();
        Token token = null;
        Response<Token> response;
        try{
            response = call.execute();
            if (response.isSuccessful()) {
                token = response.body();
            } else {
                APIError error = ErrorUtils.parseError(response);
                Log.e(TAG, "Se ha generado error en WS ");
                Log.e(TAG,"error message " + error.message());
                Log.e(TAG,"error message " +error.exceptionType());
                throw new GetTokenFondaWebApiControllerException(error.exceptionType());
            }
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en createToken", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en createToken", e);
            throw new GetTokenFondaWebApiControllerException(error.exceptionType());
        }
        Log.d(TAG, "Cierre del metodo crear Token"+ token.toString());

        getFile(context).save(token);

        return token;
    }

    private JsonFile<Token> getFile(Context context) {

        if (localFile == null)
            localFile = new JsonFile<Token>("TokenLocal", context,Token.class);

        return localFile;
    }

    @Override
    public Token getToken(Context context) throws Exception {
        Token token = null;
        try {
            token = getFile(context).getObj();
        } catch (LocalStorageException e) {
            // Deverias solo hacer log de esto.
        }
        return token;
    }

    /**
     * Elimina un token
     * @param context
     * @throws LocalStorageException
     * @throws RestClientException
     * @throws DeleteTokenFondaWebApiControllerException
     */
    @Override
    public void removeToken(Context context) throws LocalStorageException, RestClientException, DeleteTokenFondaWebApiControllerException {
        Log.d(TAG, "Se Elimina un Token");
        Token localToken = null;
        Token aux = null;
        Response<Token> response;
        try{
            localToken = getToken(context);
            Call<Token> call = tokenClient.deleteToken(localToken.getId());

                response = call.execute();
                if (response.isSuccessful()) {
                    aux = response.body();
                } else {
                    APIError error = ErrorUtils.parseError(response);
                    Log.e(TAG, "Se ha generado error en WS ");
                    Log.e(TAG,"error message " + error.message());
                    Log.e(TAG,"error message " +error.exceptionType());
                    throw new DeleteTokenFondaWebApiControllerException(error.exceptionType());
                }
            Token token = null;
            getFile(context).save(token);
        } catch (IOException e) {
            Log.e(TAG, "Se ha generado error en removeToken", e);
            throw new RestClientException("Error de IO",e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en removeToken", e);
            throw new DeleteTokenFondaWebApiControllerException(error.exceptionType());
        }
        Log.d(TAG, "Cierre del metodo eliminar Token"+ context.toString());

    }
}
