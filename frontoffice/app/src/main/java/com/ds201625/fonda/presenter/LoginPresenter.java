
package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.AddCommensalWebApiControllerException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.interfaces.ILoginView;
import com.ds201625.fonda.interfaces.ILoginViewPresenter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public class LoginPresenter implements ILoginViewPresenter {

    private ILoginView loginView;
    private String TAG = "LoginPresenter";
    /**
     * Constructor para la vita de LoginActivity
     * @param view
     */
    public LoginPresenter (ILoginView view){ loginView = view;}

    @Override
        public void regiter(String email, String password) throws AddCommensalWebApiControllerException {
        Log.d(TAG,"Metodo para registrar Commensal");
        try
            {
                SessionData.getInstance().registerCommensal(email, password);
            } catch(AddCommensalWebApiControllerException e){
                Log.e(TAG, "Se ha generado error al agregar un Commensal", e);
                throw  new AddCommensalWebApiControllerException(e);
            }
            catch (RestClientException e) {
                Log.e(TAG, "Se ha generado error al agregar un Commensal", e);
                throw  new AddCommensalWebApiControllerException(e);
            } catch (NullPointerException e) {
                Log.e(TAG, "Se ha generado error al agregar un Commensal", e);
                throw  new AddCommensalWebApiControllerException(e);
            } catch (Exception e) {
                Log.e(TAG, "Se ha generado error al agregar un Commensal");
                throw  new AddCommensalWebApiControllerException(e);
            }

    }

        @Override
        public void login(Commensal commensal) {
            try
            {
                SessionData.getInstance().addCommensal(commensal);
                SessionData.getInstance().loginCommensal();
            } catch (Exception e) {
                e.printStackTrace();
            }

        }
}
