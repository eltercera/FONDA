package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;

/**
 * Created by Jessica on 15/5/2016.
 */
public class CancelReserveActivity extends BaseNavigationActivity {

    private MenuItem cancelReserve;
    private Toolbar tb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_cancel_reserve);
        super.onCreate(savedInstanceState);
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.cancel_reserve, menu);

        cancelReserve = menu.findItem(R.id.action_cancel_reserve);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        return true;
    }
}
