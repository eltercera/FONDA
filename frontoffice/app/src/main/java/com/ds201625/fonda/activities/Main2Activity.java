package com.ds201625.fonda.activities;


import android.support.design.widget.TabLayout;


import android.support.v4.view.ViewPager;
import android.os.Bundle;

import com.ds201625.fonda.R;
import com.ds201625.fonda.fragments.Prueba1Fragment;
import com.ds201625.fonda.fragments.Prueba2Fragment;

/**
 * Actividad de prueba para mostrar el uso de los Tabs.
 */
public class Main2Activity extends BaseNavigationActivity {

    private BaseSectionsPagerAdapter mSectionsPagerAdapter;

    private ViewPager mViewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_main2);
        super.onCreate(savedInstanceState);

        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager());

        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);

        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(mViewPager);

        mSectionsPagerAdapter.addFragment("Primera",new Prueba1Fragment());
        mSectionsPagerAdapter.addFragment("Segunda",new Prueba2Fragment());
        mSectionsPagerAdapter.addFragment("Tercera",new Prueba1Fragment());
    }

}
