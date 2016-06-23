package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.retrofit_client.clients.TokenClient;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;

import java.io.IOException;

import retrofit2.Call;

/**
 * Implementacion de la interfaz TokenService
 */
public class RetrofitTokenService implements TokenService{
    private String TAG = "RetrofitTokenService";
    private TokenClient tokenClient;

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

    @Override
    public Token createToken(Context context) throws Exception {
        Call<Token> call = tokenClient.postToken();
        Token token = null;
        try{
             token = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
            throw new Exception("Error al obtener token",e);
        }

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
        Token token = getFile(context).getObj();
        return token;
    }

    @Override
    public void removeToken(Context context) throws LocalStorageException, RestClientException {
        Token localToken = null;
        try {
            localToken = getToken(context);
        }
        catch (Exception e){
            e.printStackTrace();
        }
        Call<Token> call = tokenClient.deleteToken(localToken.getId());

        try{
            call.execute();
            Token token = null;
            getFile(context).save(token);
        } catch (IOException e) {
            throw new RestClientException("Error de IO",e);
        }
    }
}
