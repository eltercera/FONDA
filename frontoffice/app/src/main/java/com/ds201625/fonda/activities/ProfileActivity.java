package com.ds201625.fonda.activities;

import android.os.Bundle;
import android.view.Menu;

import com.ds201625.fonda.R;

public class ProfileActivity extends BaseActivityNavigation {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_profile);
        super.onCreate(savedInstanceState);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.profile, menu);
        return true;
    }
}
