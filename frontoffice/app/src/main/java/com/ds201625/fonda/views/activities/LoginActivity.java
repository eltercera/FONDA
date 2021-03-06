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
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.views.contracts.LoginViewContract;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.presenters.LoginPresenter;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * A login screen that offers login via email/password.
 */
public class LoginActivity extends BaseActivity implements LoginViewContract {

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
    private EditText mRePasswordView;
    private TextView mTextViewForgetPass;
    private LoginActivityStatus status = LoginActivityStatus.ON_LOGIN;
    private Button mEmailSignInButton;
    private Button mSignInButton;
    private Button mRegisterButton;
    private LinearLayout mLoginLayout;
    private LinearLayout mInitLayout;
    private LoginPresenter presenter;

    /**
     * Metodo que se llama cuando se crea el activities
     * @param savedInstanceState
     */
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
        mRePasswordView = (EditText) findViewById(R.id.password2);
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
        mRePasswordView.setVisibility(View.VISIBLE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mEmailSignInButton.setText(getString(R.string.login_register));
        mPasswordView.setVisibility(View.VISIBLE);
    }

    /**
     * Coloca los componentes de la vista en modo de Olvido de contraseña
     */
    private void setOnForgetPass() {
        this.status = LoginActivityStatus.ON_PASSWORD_FORGET;
        mEmailView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mEmailView.setNextFocusDownId(R.id.password);
        mPasswordView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mPasswordView.setNextFocusDownId(R.id.password2);
        mRePasswordView.setVisibility(View.VISIBLE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mEmailSignInButton.setText(getString(R.string.login_recover_passwd));
        mPasswordView.setVisibility(View.VISIBLE);
    }

    /**
     * Coloca los componentes en como de inicio de sesión.
     */
    private void setOnLogin() {
        this.status = LoginActivityStatus.ON_LOGIN;
        mPasswordView.setImeOptions(EditorInfo.IME_ACTION_DONE);
        mEmailView.setImeOptions(EditorInfo.IME_ACTION_NEXT);
        mEmailView.setNextFocusDownId(R.id.password);
        mRePasswordView.setVisibility(View.GONE);
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
        String repassword = mRePasswordView.getText().toString();

        String alphanumeric = "^[A-Za-z0-9]+$";

        boolean cancel = false;
        View focusView = null;

        // Check for a valid password, if the user entered one.
        if (!TextUtils.isEmpty(password) && !isPasswordValid(password,alphanumeric,6).isEmpty()) {
            mPasswordView.setError(isPasswordValid(password,alphanumeric,6));
            focusView = mPasswordView;
            cancel = true;
        }else if (TextUtils.isEmpty(password)) {
            mPasswordView.setError(getString(R.string.error_field_required));
            focusView = mPasswordView;
            cancel = true;
        }

        // Check for a valid email address.
        if (TextUtils.isEmpty(email)) {
            mEmailView.setError(getString(R.string.error_field_required));
            focusView = mEmailView;
            cancel = true;
        } else if (!isEmailValid(email)) {
            mEmailView.setError(getString(R.string.error_format_email));
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

    private String isPasswordValid(String password, String patron, int min) {
        Pattern patternPassword = Pattern.compile(patron, Pattern.CASE_INSENSITIVE);
        Matcher matcherPassword = patternPassword.matcher(password);
        if (!matcherPassword.matches() && password.length() < min){
            return getString(R.string.error_invalid_password);
        }
        else if (!matcherPassword.matches()) {
            return getString(R.string.error_format_password);
        }
        else if (password.length() < min){
            return getString(R.string.error_length_password);
        }
        return "";
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
        // Reset error.
        mPasswordView.setError(null);

        Toast msj = null;
        View focus = null;
        boolean succ = false;

        if (TextUtils.isEmpty(repassword)) {
            mRePasswordView.setError(getString(R.string.error_field_required));
            focus = mRePasswordView;
            focus.requestFocus();
        } else if (!password.equals(repassword)){
            msj = Toast.makeText(getBaseContext(),
                    "Las contraseñas no coinciden",
                    Toast.LENGTH_SHORT);
        } else {
            try {
                presenter.regiter(email, password);
                succ = true;
            } catch (Exception e) {
                succ = false;
            }
        }

        if (succ){
            setOnLogin();
            showLoginForm();
        }
    }

    /**
     * Metodo que permite el logi ndel comensal
     * @param email del comensal que desea ingresar
     * @param password del comensal que desea ingresar
     */
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
            succ = false;
        }

        if (succ){
            skip();
        } else {
            displayMsj("Error al iniciar sesión");
        }
    }

    /**
     * Metodo encargado del despliegue de msj al usuario
     * @param msj
     */
    @Override
    public void displayMsj(String msj) {
        Toast.makeText(this, msj, Toast.LENGTH_LONG).show();
    }
}