package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.adapters.FiltersAdapter;

public class RestauranstsActivity extends  BaseNavigationActivity {

    private ViewPager viewPager;
    private BaseSectionsPagerAdapter RestaurantFilters;

    @Override
    protected void onCreate(Bundle savedInstanceState) { //Se corren las vistas y menu
        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        viewPager = (ViewPager) findViewById(R.id.viewPager);
        viewPager.setAdapter(new FiltersAdapter(this));

        TabLayout tabs = (TabLayout) findViewById(R.id.tabs);

/*        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_global_brown_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_food_primary_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_place_primary_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_dollar_primary_24dp));*/

        tabs.setupWithViewPager(viewPager);


    }


}
