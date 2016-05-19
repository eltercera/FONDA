package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.*;

public class RestauranstsActivity extends  BaseNavigationActivity {

    String[] names = {
            "The dining room",
            "Mogi Mirin",
            "Gordo & Magro",
            "La Casona",
            "Tony's"} ;
    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;
    String[] shortDescription = {
            "Casual",
            "Romantico",
            "Italiano",
            "Italiano",
            "Americano"} ;
    Integer[] imageId = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002,
            R.mipmap.ic_restaurant003,
            R.mipmap.ic_restaurant004,
            R.mipmap.ic_restaurant005,

    };

    private ViewPager viewPager;
    private BaseSectionsPagerAdapter RestaurantFilters;

    @Override
    protected void onCreate(Bundle savedInstanceState) { //Se corren las vistas y menu

        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        viewPager = (ViewPager) findViewById(R.id.viewPager);
        TabLayout tabLayout = (TabLayout) findViewById(R.id.tabs);

        RestaurantFilters = new BaseSectionsPagerAdapter(getSupportFragmentManager(),tabLayout);
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.filter_food),new FoodFragment());
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.filter_zone),new ZoneFragment());
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.filter_cost),new CostFragment());
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.filter_time),new TimeFragment());
        RestaurantFilters.addFragment(getResources().getDrawable(R.drawable.filter_near),new NearFragment());

        viewPager.setAdapter(RestaurantFilters);
        tabLayout.setupWithViewPager(viewPager);
        RestaurantFilters.iconsSetup();


    }


}
