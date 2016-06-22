package com.ds201625.fonda.views.activities;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.NumberPicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.TimePicker;

import java.util.Calendar;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Restaurant;

public class ReserveNewActivity extends BaseNavigationActivity {
    Button btn;
    int year_x,mont_x,day_x;
    int bola;
    static final int DIALOG_ID=0;
    static final int DIALOG_ID2=0;
    EditText hola;
    private Button pickTime;
    private int pHour;
    private int pMinute;
    TextView texto;
    Spinner ncomensal;
    String[] num = {"2", "4", "8", "16"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_new_reserve);
        super.onCreate(savedInstanceState);
        final  Calendar cal= Calendar.getInstance();
        year_x= cal.get(Calendar.YEAR);
        mont_x= cal.get(Calendar.MONTH);
        day_x= cal.get(Calendar.DAY_OF_MONTH);
        pHour = cal.get(Calendar.HOUR_OF_DAY);
        pMinute = cal.get(Calendar.MINUTE);
        showDialogOnButtonClick();
        ncomensal = (Spinner)findViewById(R.id.ncomensal);
        ArrayAdapter<String> adaptador = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, num);
        ncomensal.setAdapter(adaptador);
        //String valor =ncomensal.getSelectedItem().toString();



    }

    public void showDialogOnButtonClick(){
        btn= (Button) findViewById(R.id.button);
        pickTime= (Button) findViewById(R.id.pickTime);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog(DIALOG_ID);

            }
        });
        pickTime.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog(DIALOG_ID2);
            }
        });
    }



    @Override
    protected Dialog onCreateDialog(int id){

        if(id==DIALOG_ID){
            return new DatePickerDialog(this, dpickerListner, year_x, mont_x, day_x );

        }

        if(id==DIALOG_ID2){
            return new TimePickerDialog(this, mTimeSetListener, pHour, pMinute, false);

        }
        return null;
    }

    private TimePickerDialog.OnTimeSetListener mTimeSetListener = new TimePickerDialog.OnTimeSetListener() {
        @Override
        public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
            pHour = hourOfDay;
            pMinute = minute;
        }
    };
    private DatePickerDialog.OnDateSetListener dpickerListner= new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
            year_x =year;
            mont_x=monthOfYear +1;
            day_x=dayOfMonth;
            bola = day_x;
            Toast.makeText(ReserveNewActivity.this, year_x +"/"+ mont_x + "/" + day_x, Toast.LENGTH_LONG).show();

        }
    };



}
