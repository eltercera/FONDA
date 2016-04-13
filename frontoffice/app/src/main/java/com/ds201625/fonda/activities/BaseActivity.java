package com.ds201625.fonda.activities;

import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;

/**
 * Created by rrodriguez on 4/10/16.
 */
public abstract class BaseActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    protected void onStop() {
        super.onStop();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }

    @Override
    protected void onPause() {
        super.onPause();
    }

    @Override
    protected void onResume() {
        super.onResume();
    }

    @Override
    protected void onStart() {
        super.onStart();
    }

    protected AlertDialog buildSingleDialog(String title, String text) {

        AlertDialog.Builder builder = new AlertDialog.Builder(this);

        builder.setMessage(text)
                .setTitle(title);
        builder.setNeutralButton("OK",null);

        return builder.create();
    }
}
