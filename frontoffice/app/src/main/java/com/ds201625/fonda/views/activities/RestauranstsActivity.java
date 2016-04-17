package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.widget.TabHost;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.*;

public class RestauranstsActivity extends  BaseNavigationActivity {

    private ViewPager viewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) { //Se corren las vistas y menu

        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        viewPager = (ViewPager) findViewById(R.id.viewPager);
        BaseSectionsPagerAdapter RestaurantFilters = new BaseSectionsPagerAdapter(
                getSupportFragmentManager());

        RestaurantFilters.addFragment("Comida",new FoodFragment());
        RestaurantFilters.addFragment("Zona",new ZoneFragment());
        RestaurantFilters.addFragment("Costo",new CostFragment());
        RestaurantFilters.addFragment("Horario",new TimeFragment());
        RestaurantFilters.addFragment("Cercanos",new NearFragment());
        viewPager.setAdapter(RestaurantFilters);

        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(viewPager);

    }


}
