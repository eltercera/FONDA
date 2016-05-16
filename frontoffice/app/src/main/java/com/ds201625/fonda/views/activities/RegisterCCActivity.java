package com.ds201625.fonda.views.activities;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;

import com.ds201625.fonda.R;

public class RegisterCCActivity extends AppCompatActivity {

    private EditText number;
    private EditText name;
    private EditText idOwner;
    private EditText expiration;
    private EditText cvv;
    private RadioButton rBVisa;
    private RadioButton rBMaster;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_credit_card);

    }


}

