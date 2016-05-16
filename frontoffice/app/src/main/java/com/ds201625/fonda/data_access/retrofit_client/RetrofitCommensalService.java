package com.ds201625.fonda.data_access.retrofit_client;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.local_storage.JsonFile;
import com.ds201625.fonda.data_access.retrofit_client.clients.CommensalClient;
import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.domains.Commensal;


import java.io.IOException;

import retrofit2.Call;

/**
 * Created by rrodriguez on 5/12/16.
 */
public class RetrofitCommensalService implements CommensalService {

    private CommensalClient commensalClient =
            RetrofitService.getInstance().createService(CommensalClient.class);

    private JsonFile<Commensal> localFile;

    @Override
    public Commensal RegisterCommensal(String user, String password, Context context) {

        if (user.isEmpty() || password.isEmpty()) {
            // TODO: Exeption
            return null;
        }

        Commensal commensal = new Commensal();
        commensal.setEmail(user);
        commensal.setPassword(password);
        Call<Commensal> call = commensalClient.registerCommensal(commensal);
        Commensal rsvCommensal = null;

        try{
            rsvCommensal = call.execute().body();
        } catch (IOException e) {
            Log.v("Fonda: ",e.toString());
        }

        getFile(context).save(rsvCommensal);

        return rsvCommensal;
    }

    private JsonFile<Commensal> getFile(Context context) {

        if (localFile == null)
            localFile = new JsonFile<Commensal>("CommenslaLocal", context,Commensal.class);

        return localFile;
    }

    @Override
    public Commensal getCommensal(Context context) {
        return getFile(context).getObj();
    }

}
