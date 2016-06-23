package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.*;

public class RestauranstsActivity extends  BaseNavigationActivity {

    private ViewPager viewPager;
    private BaseSectionsPagerAdapter RestaurantFilters;
    private FilterFragment fragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) { //Se corren las vistas y menu

        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        viewPager = (ViewPager) findViewById(R.id.viewPager);
        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);

        FilterFragment zoneFrag = new FilterFragment();
        FilterFragment resFrag = new FilterFragment();
        FilterFragment catFrag = new FilterFragment();
        zoneFrag.setTabLayout(tabLayout);
        resFrag.setTabLayout(tabLayout);
        catFrag.setTabLayout(tabLayout);

        RestaurantFilters = new BaseSectionsPagerAdapter(getSupportFragmentManager(),tabLayout);
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.ic_global),resFrag);
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.ic_zone),zoneFrag);
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.ic_food),catFrag);

        viewPager.setAdapter(RestaurantFilters);
        tabLayout.setupWithViewPager(viewPager);
        RestaurantFilters.iconsSetup();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.search_menu, menu);

        return true;
    }


}
