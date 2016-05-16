package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
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
    }

    @Override
    public Token createToken(Context context) {
        Call<Token> call = tokenClient.postToken();
        Token token = null;
        try{
             token = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
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
    public Token getToken(Context context) {
        return getFile(context).getObj();
    }
}
