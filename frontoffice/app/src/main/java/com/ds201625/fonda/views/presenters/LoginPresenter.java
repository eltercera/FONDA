package com.ds201625.fonda.views.presenters;

import com.ds201625.fonda.domains.Commensal;
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

        public void regiter(String email, String password) {
            try
            {
                SessionData.getInstance().registerCommensal(email, password);
            } catch (Exception e) {
                e.printStackTrace();
            }

    }

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
