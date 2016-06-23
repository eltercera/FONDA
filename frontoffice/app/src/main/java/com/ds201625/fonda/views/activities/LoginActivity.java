package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.interfaces.ILoginView;
import com.ds201625.fonda.interfaces.ILoginViewPresenter;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.presenter.LoginPresenter;


/**
 * A login screen that offers login via email/password.
 */
public class LoginActivity extends BaseActivity implements ILoginView {

    /**
     * Estados de para el formulario y acciones.
     */
    public enum LoginActivityStatus {
        ON_INIT,
        ON_LOGIN,
        ON_REGISTER,
        ON_PASSWORD_FORGET
    }

     // UI references.
    private AutoCompleteTextView mEmailView;
    private EditText mPasswordView;
    private EditText mPasswordView2;
    private TextView mTextViewForgetPass;
    private LoginActivityStatus status = LoginActivityStatus.ON_LOGIN;
    private Button mEmailSignInButton;
    private Button mSignInButton;
    private Button mRegisterButton;
    private LinearLayout mLoginLayout;
    private LinearLayout mInitLayout;
    private ILoginViewPresenter presenter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        presenter = new LoginPresenter(this);
        // para saltar o no
        boolean skp = false;

        // inicializa los datos de la sesion
        if (SessionData.getInstance() == null)
            try {
                SessionData.initInstance(getApplicationContext());
            } catch (Exception e) {
                e.printStackTrace();
            }

        // si existe un token o lo logra obtener uno nuevo vigente salta
        if (SessionData.getInstance().getToken() != null)
            skp = true;

        if (skp)
            skip();
        else {
            // inicializacion de la vista
            setContentView(R.layout.activity_login);
            this.status = LoginActivityStatus.ON_INIT;
            this.getAllElements();

            //agrecacion de acciones.
            mPasswordView.setOnEditorActionListener(new TextView.OnEditorActionListener() {
                @Override
                public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
                    if (id == R.id.login || id == EditorInfo.IME_NULL) {
                        attemptLogin();
                        return true;
                    }
                    return false;
                }
            });

            mEmailSignInButton.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    attemptLogin();
                }
            });

            mSignInButton.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    setOnLogin();
                    showLoginForm();
                }
            });

            mRegisterButton.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View v) {
                    setOnRegister();
                    showLoginForm();
                }
            });

            mTextViewForgetPass.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    setOnForgetPass();
                }
            });
        }
    }

    /**
     * Obtiene todos los componentes de la vista.
     */
    private void getAllElements() {
        mEmailView = (AutoCompleteTextView) findViewById(R.id.email);
        mPasswordView = (EditText) findViewById(R.id.password);
        mPasswordView2 = (EditText) findViewById(R.id.password2);
        mEmailSignInButton = (Button) findViewById(R.id.email_sign_in_button);
        mSignInButton = (Button) findViewById(R.id.signin_button);
        mRegisterButton = (Button) findViewById(R.id.register_button);
        mLoginLayout = (LinearLayout) findViewById(R.id.email_login_form);
        mInitLayout = (LinearLayout) findViewById(R.id.init_layout);
        mTextViewForgetPass = (TextView) findViewById(R.id.textViewForgetPass);
    }

    /**
     * Coloca los componentes en modo de registro
     */
    private void setOnRegister() {
        this.status = LoginActivityStatus.ON_REGISTER;
        mEmailView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mEmailView.setNextFocusDownId(R.id.password);
        mPasswordView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mPasswordView.setNextFocusDownId(R.id.password2);
        mPasswordView2.setVisibility(View.VISIBLE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mEmailSignInButton.setText(getString(R.string.login_register));
        mPasswordView.setVisibility(View.VISIBLE);
    }

    /**
     * Coloca los componentes de la vista en modo de Olvido de contraseña
     */
    private void setOnForgetPass() {
        this.status = LoginActivityStatus.ON_PASSWORD_FORGET;
        mEmailView.setImeOptions(EditorInfo.IME_ACTION_DONE);
        mPasswordView2.setVisibility(View.GONE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mEmailSignInButton.setText(getString(R.string.login_recover_passwd));
        mPasswordView.setVisibility(View.GONE);
    }

    /**
     * Coloca los componentes en como de inicio de sesión.
     */
    private void setOnLogin() {
        this.status = LoginActivityStatus.ON_LOGIN;
        mPasswordView.setImeOptions(EditorInfo.IME_ACTION_DONE);
        mEmailView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mEmailView.setNextFocusDownId(R.id.password);
        mPasswordView2.setVisibility(View.GONE);
        mTextViewForgetPass.setVisibility(View.VISIBLE);
        mEmailSignInButton.setText(getString(R.string.login_start_session));
        mPasswordView.setVisibility(View.VISIBLE);
    }

    private void attemptLogin() {

        // Reset errors.
        mEmailView.setError(null);
        mPasswordView.setError(null);

        // Store values at the time of the login attempt.
        String email = mEmailView.getText().toString();
        String password = mPasswordView.getText().toString();
        String repassword = mPasswordView2.getText().toString();

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(password) && !isPasswordValid(password)) {
            mPasswordView.setError(getString(R.string.error_invalid_password));
            focusView = mPasswordView;
            cancel = true;
        }

        // Check for a valid email address.
        if (TextUtils.isEmpty(email)) {
            mEmailView.setError(getString(R.string.error_field_required));
            focusView = mEmailView;
            cancel = true;
        } else if (!isEmailValid(email)) {
            mEmailView.setError(getString(R.string.error_invalid_email));
            focusView = mEmailView;
            cancel = true;
        }

        if (cancel) {
            // There was an error; don't attempt login and focus the first
            // form field with an error.
            focusView.requestFocus();
        } else {
            // Show a progress spinner, and kick off a background task to
            // perform the user login attempt.
            switch (status) {
                case ON_LOGIN:
                    login(email,password);
                    break;
                case ON_REGISTER:
                    regiter(email,password,repassword);
                    break;
                case ON_PASSWORD_FORGET:
                    regiter(email,password,repassword);
                    break;
            }
        }
    }

    private void showLoginForm() {
        mInitLayout.setVisibility(View.GONE);
        mLoginLayout.setVisibility(View.VISIBLE);
    }

    private void showInitForm() {
        this.status = LoginActivityStatus.ON_INIT;
        mInitLayout.setVisibility(View.VISIBLE);
        mLoginLayout.setVisibility(View.GONE);
    }

    /**
     * Validacion de un email
     * @param email el correo
     * @return true si el correo tiene un patron valido false lo contrario
     */
    private boolean isEmailValid(String email) {
        if (email == null) {
            return false;
        } else {
            return android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches();
        }
    }

    private boolean isPasswordValid(String password) {
        return password.length() >= 6;
    }

    /**
     * Captura de accion del boton de hardware (back)
     */
    @Override
    public void onBackPressed() {
        if(status == LoginActivityStatus.ON_INIT)
            super.onBackPressed();
        else
            showInitForm();
    }

    /**
     * Acción de saltar esta actividad.
     */
    private void skip() {
        startActivity(new Intent(this,FavoritesActivity.class));
    }

    /**
     * Registro de un commensal.
     * @param email el correo a registrar
     * @param password contraseña
     * @param repassword recontraseñan :)
     */
    @Override
    public void regiter(String email, String password, String repassword) {
        Toast msj = null;
        boolean succ = false;
        if (!password.equals(repassword)){
            msj = Toast.makeText(getBaseContext(),
                    "Las contraseñas no coinciden",
                    Toast.LENGTH_SHORT);
        } else {
            try {
                presenter.regiter(email, password);
                succ = true;
            } catch (Exception e) {
                msj = Toast.makeText(getBaseContext(),
                        "Error en el Registro",Toast.LENGTH_SHORT);
            }

            if (succ){
                msj = Toast.makeText(getBaseContext(),
                        "Registro Satisfactorio",
                        Toast.LENGTH_SHORT);
            } else {
                msj = Toast.makeText(getBaseContext(),
                        "Error en el registro",
                        Toast.LENGTH_SHORT);
            }
        }
        if (msj != null)
            msj.show();

        if (succ){
            setOnLogin();
            showLoginForm();
        }
    }

    @Override
    public void login(String email, String password) {
        boolean succ = false;
        Commensal commensal;
        commensal = new Commensal();
        commensal.setPassword(password);
        commensal.setEmail(email);
        try {
           presenter.login(commensal);
            succ = true;
        } catch (Exception e) {
            Toast.makeText(getBaseContext(), "Error al iniciar sesión",
                    Toast.LENGTH_SHORT).show();
        }

        if (succ){
            skip();
        } else {
            Toast.makeText(getBaseContext(),
                    "Error al iniciar sesión",
                    Toast.LENGTH_SHORT).show();
        }
    }

}

