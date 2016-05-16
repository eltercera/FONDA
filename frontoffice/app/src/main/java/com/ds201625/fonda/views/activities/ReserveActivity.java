package com.ds201625.fonda.views.activities;
import android.content.Intent;
import android.os.Bundle;
import com.ds201625.fonda.R;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

/**
 * Created by Jessica on 18/4/2016.
 */

public class ReserveActivity extends BaseNavigationActivity {
    ListView list;
    String[] restaurants = {
            "The dining room",
            "Mogi Mirin"};
    String[] date = {
            "15/09/2016",
            "27/09/2016"};
    String[] time = {
            "8:00 p.m.",
            "6:00 p.m."};
    String[] dinners = {
            "3 comensales",
            "2 comensales" };
    Integer[] picture = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_reserve);
        super.onCreate(savedInstanceState);

        ReserveList adapter = new
                ReserveList (ReserveActivity.this,restaurants,date,time,dinners, picture);
        list = (ListView)findViewById(R.id.listOfReservations);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Toast.makeText(ReserveActivity.this, "You Clicked at " + restaurants[+position], Toast.LENGTH_SHORT).show();
                Intent change = new Intent (ReserveActivity.this,CancelReserveActivity.class);
                startActivity(change);
            }
        });
    }
}