package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.logic.InvalidParameterTypeException;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.views.contracts.LoginViewContract;
import com.ds201625.fonda.logic.SessionData;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public class LoginPresenter {

    private LoginViewContract loginView;
    private String TAG = "LoginPresenter";
    /**
     * Constructor para la vita de LoginActivity
     * @param view
     */
    public LoginPresenter (LoginViewContract view){ loginView = view;}

        public void regiter(String email, String password) throws Exception {
            Log.d(TAG,"Registro Commensal");
            try
            {
                SessionData.getInstance().registerCommensal(email, password);
                this.loginView.displayMsj("Registro Satisfactorio");
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                this.loginView.displayMsj("Error interno: " + e.getMessage());
                throw e;
            } catch (Exception e)
            {
                Log.e(TAG,"Error al Registar Commensal",e);
                this. loginView.displayMsj(e.getMessage());
                throw e;
            }

    }

        public void login(Commensal commensal) throws Exception{
            Log.d(TAG,"Login Commensal");
            try
            {
                SessionData.getInstance().addCommensal(commensal);
                SessionData.getInstance().loginCommensal();
            }
            catch (ParameterOutOfIndexException | InvalidParameterTypeException e) {
                Log.e(TAG,"Error al Logearse un Commensal",e);
                this.loginView.displayMsj("Error interno: " + e.getMessage());
                throw e;
            } catch (Exception e)
            {
                Log.e(TAG,"Error al Logearse un Commensal",e);
                throw e;
            }

        }
}
