package com.ds201625.fonda.activities;


import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;


import com.ds201625.fonda.R;


/**
 * A login screen that offers login via email/password.
 */
public class LoginActivity extends AppCompatActivity {

    public enum LoginActivityStatus {
        ON_LOGIN,
        ON_REGISTER,
        ON_PASSWORD_FORGET
    }

     // UI references.
    private AutoCompleteTextView mEmailView;
    private EditText mPasswordView;
    private EditText mPasswordView2;
    private TextView mTextViewRegister;
    private TextView mTextViewForgetPass;
    private TextView mTextViewStartSesion;
    private LoginActivityStatus status = LoginActivityStatus.ON_LOGIN;
    private Button mEmailSignInButton;


    private void getAllElements() {
        mEmailView = (AutoCompleteTextView) findViewById(R.id.email);
        mPasswordView = (EditText) findViewById(R.id.password);
        mPasswordView2 = (EditText) findViewById(R.id.password2);
        mTextViewForgetPass = (TextView) findViewById(R.id.textViewForgetPass);
        mTextViewRegister = (TextView) findViewById(R.id.textViewRegiter);
        mEmailSignInButton = (Button) findViewById(R.id.email_sign_in_button);
        mTextViewStartSesion = (TextView) findViewById(R.id.textViewStartSesion);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        this.getAllElements();

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

        mTextViewRegister.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                setOnRegister();
            }
        });

        mTextViewStartSesion.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                setOnLogin();
            }
        });

        mTextViewForgetPass.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                setOnForgetPass();
            }
        });

    }

    private void setOnRegister() {
        this.status = LoginActivityStatus.ON_REGISTER;
        mPasswordView2.setVisibility(View.VISIBLE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mTextViewRegister.setVisibility(View.GONE);
        mTextViewStartSesion.setVisibility(View.VISIBLE);
        mEmailSignInButton.setText(getString(R.string.login_register));
        mPasswordView.setVisibility(View.VISIBLE);
    }

    private void setOnForgetPass() {
        this.status = LoginActivityStatus.ON_PASSWORD_FORGET;
        mPasswordView2.setVisibility(View.GONE);
        mTextViewForgetPass.setVisibility(View.GONE);
        mTextViewRegister.setVisibility(View.GONE);
        mTextViewStartSesion.setVisibility(View.VISIBLE);
        mEmailSignInButton.setText(getString(R.string.login_recover_passwd));
        mPasswordView.setVisibility(View.GONE);
    }

    private void setOnLogin() {
        this.status = LoginActivityStatus.ON_LOGIN;
        mPasswordView2.setVisibility(View.GONE);
        mTextViewForgetPass.setVisibility(View.VISIBLE);
        mTextViewRegister.setVisibility(View.VISIBLE);
        mTextViewStartSesion.setVisibility(View.GONE);
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
                    seguir();
                    break;
                case ON_REGISTER:
                    regiter();
                    break;
                case ON_PASSWORD_FORGET:
                    setOnLogin();
                    break;
            }
        }
    }

    private boolean isEmailValid(String email) {
        //TODO: Replace this with your own logic
        return email.contains("@");
    }

    private boolean isPasswordValid(String password) {
        //TODO: Replace this with your own logic
        return password.length() > 4;
    }

    @Override
    public void onBackPressed() {
        if(status == LoginActivityStatus.ON_LOGIN)
            super.onBackPressed();
        else
            setOnLogin();
    }

    private void seguir() {
        startActivity(new Intent(this,MainActivity.class));
    }

    private void regiter() {

        AlertDialog.Builder builder = new AlertDialog.Builder(this);

        builder.setMessage("El registro de la cuenta "+mEmailView.getText().toString()
                +" fue satisfactorio.")
                .setTitle("Registro de Cuenta");


        builder.setPositiveButton("Continuar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) {
                setOnLogin();
                seguir();
            }
        });

        AlertDialog dialog = builder.create();

        dialog.show();
    }
}

