package com.ds201625.fonda.activities;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;

public class PagoOrdenActivity extends Activity {
    private TextView total;
    private EditText propina;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pago_orden);
        Spinner spinner = (Spinner) findViewById(R.id.spinner);
        String[] valores = {"43265789098456787", "0987678765458765"};
        spinner.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, valores));
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {

            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int position, long id) {
                Toast.makeText(adapterView.getContext(), (String) adapterView.getItemAtPosition(position), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
                // vacio

            }
        });
    }

    public void suma(View v) {
        int m=2000;
        propina = (EditText)findViewById(R.id.eT_propina);
        total = (TextView)findViewById(R.id.tV_ultimo);
        int a= Integer.parseInt(propina.getText().toString());
        int z=a+m;
        total.setText(String.valueOf(z));
    }
}
