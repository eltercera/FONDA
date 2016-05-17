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
 * Created by rrodriguez on 5/16/16.
 */
public class RetrofitTokenService implements TokenService{

    private TokenClient tokenClient;

    private Commensal commensal;

    private JsonFile<Token> localFile;

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
    public Token getToken(Context context) throws LocalStorageException {
        return getFile(context).getObj();
    }
}
