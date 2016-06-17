package com.ds201625.fonda.views.activities;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.DatePicker;
import android.widget.NumberPicker;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.entities.Commensal;
import com.ds201625.fonda.domains.entities.Restaurant;

public class ReserveNewActivity extends BaseNavigationActivity {

    TextView tvDate;
    TextView tvHour;
    NumberPicker npDiners = null;

    int year_, month, day, month_;
    int hour_, minute_;
    String sminute;

    String date;
    String time;
    Date reserveDate;
    Date creatDate;
    int commensalNumber;
    Commensal user;
    Restaurant restaurante;

    static final int DIALOG_DATE_ID = 0;
    static final int DIALOG_HOUR_ID = 1;

    private MenuItem setReserve;
    private Toolbar tb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_new_reserve);
        super.onCreate(savedInstanceState);

        final Calendar calendar = Calendar.getInstance();

        year_ = calendar.get(Calendar.YEAR);
        month = calendar.get(Calendar.MONTH);
        day = calendar.get(Calendar.DAY_OF_MONTH);
        month_ = month + 1;

        hour_ = calendar.get(Calendar.HOUR);
        minute_ = calendar.get(Calendar.MINUTE);

        if (minute_ < 10)
            sminute = "0" + minute_;
        else
            sminute = minute_ + "";

        MuestraDialogoFecha();
        MuestraDialogoHora();

        npDiners = (NumberPicker)findViewById(R.id.npPickDiners);
        npDiners.setMaxValue(20);
        npDiners.setMinValue(1);
        npDiners.setWrapSelectorWheel(false);
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.new_reserve, menu);

        setReserve = menu.findItem(R.id.action_save_reserve);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        return true;
    }

    public String MuestraDialogoFecha() {
        tvDate = (TextView)findViewById(R.id.tvCalendar);
        tvDate.setText(day + "/" + month_ + "/" + year_);
        tvDate.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        showDialog(DIALOG_DATE_ID);
                    }
                }
        );
        return date = tvDate.getText().toString();
    }

    public String MuestraDialogoHora() {
        tvHour = (TextView)findViewById(R.id.tvClock);
        tvHour.setText(hour_ + ":" + sminute);
        tvHour.setOnClickListener(
                new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        showDialog(DIALOG_HOUR_ID);
                    }
                }
        );
        return time = tvHour.getText().toString();
    }

    public void formatToDate (String datetime){
        SimpleDateFormat formatter = new SimpleDateFormat("dd/mm/yyyy hh:mm");
        Date _date = null;
        try {
            _date = formatter.parse(datetime);
            formatter.format(_date);
        } catch (ParseException e) {
            e.printStackTrace();
        }
    }


   // formatToDate(""+date + " " + time + "");

    @Override
    protected Dialog onCreateDialog(int id) {
        if (id == DIALOG_DATE_ID)
            return new DatePickerDialog(this, selectDate, year_, month, day);
        if (id == DIALOG_HOUR_ID)
            return new TimePickerDialog(this, selectTime, hour_, minute_,false);

        return null;
    }

    private TimePickerDialog.OnTimeSetListener selectTime
            = new TimePickerDialog.OnTimeSetListener() {
        @Override
        public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
            hour_ = hourOfDay;
            minute_ = minute;

            if (minute_ < 10)
                sminute = "0" + minute_;
            else
                sminute = minute_ + "";

            Toast.makeText(ReserveNewActivity.this, hour_ + ":" + sminute, Toast.LENGTH_LONG).show();
            tvHour.setText(hour_ + ":" + sminute);
        }
    };

    private DatePickerDialog.OnDateSetListener selectDate
            = new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth){
            year_ = year;
            month = monthOfYear + 1;
            day = dayOfMonth;
            Toast.makeText(ReserveNewActivity.this, day + "/" + month_ + "/" + year_, Toast.LENGTH_LONG).show();
            tvDate.setText(day + "/" + month_ + "/" + year_);
        }
    };


}
