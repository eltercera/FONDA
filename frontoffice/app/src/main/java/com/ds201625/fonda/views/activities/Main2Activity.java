package com.ds201625.fonda.views.activities;

import android.support.design.widget.TabLayout;

import android.support.v4.view.ViewPager;
import android.os.Bundle;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.Prueba1Fragment;
import com.ds201625.fonda.views.fragments.Prueba2Fragment;

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

        //Importante Primero obtener el Tablayout
        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
        //Inyectarlo al BaseSectionsPagerAdapter
        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager(),tabLayout);

        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);
        tabLayout.setupWithViewPager(mViewPager);

        //Tab solo con icono como titulo
        mSectionsPagerAdapter.addFragment(getResources().getDrawable(R.drawable.contact_card_24),new Prueba1Fragment());
        mSectionsPagerAdapter.addFragment(getResources().getDrawable(R.drawable.nav_reserve),new Prueba2Fragment());
        mSectionsPagerAdapter.addFragment(getResources().getDrawable(R.drawable.calendar_24),new Prueba1Fragment());
        //Tab con solo un String como titulo
        mSectionsPagerAdapter.addFragment("Palabra",new Prueba1Fragment());
        //Tab con Icono y titilo.
        mSectionsPagerAdapter.addFragment("Palabra",getResources().getDrawable(R.drawable.nav_reserve),new Prueba1Fragment());

        //Importante ejecutar esto para que se creen los iconos en el tab.
        mSectionsPagerAdapter.iconsSetup();
    }

}
