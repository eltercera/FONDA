package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.adapters.FiltersAdapter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.RestaurantListFragment;

import java.util.ArrayList;
import java.util.List;

public class RestauranstsActivity extends  BaseNavigationActivity
        implements RestaurantListFragment.restaurantListFragmentListener{

    private ViewPager viewPager;
    private BaseSectionsPagerAdapter RestaurantFilters;
    private RestaurantListFragment restListFrag;
    private FragmentManager fm;
    private Toolbar tb;
    private List<Restaurant> p;
    private boolean onForm;


    @Override
    protected void onCreate(Bundle savedInstanceState) { //Se corren las vistas y menu
        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        tb = (Toolbar)findViewById(R.id.toolbar);
        fm = getSupportFragmentManager();
        viewPager = (ViewPager) findViewById(R.id.viewPager);
        viewPager.setAdapter(new FiltersAdapter(this));


/*        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_global_brown_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_food_primary_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_place_primary_24dp));
        tabs.addTab(tabs.newTab().setIcon(R.drawable.ic_dollar_primary_24dp));*/

        restListFrag= new RestaurantListFragment();
        Bundle args = new Bundle();
        args.putBoolean("multiSelect",false);
        restListFrag.setArguments(args);
        TabLayout tabs = (TabLayout) findViewById(R.id.tabs);
        tabs.setupWithViewPager(viewPager);

        fm.beginTransaction()
                .replace(R.id.fragment_container,restListFrag)
                .commit();

        fm.executePendingTransactions();


    }

    private void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container,fragment)
                .commit();
        fm.executePendingTransactions();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.profile, menu);
        return true;
    }

    @Override
    public void OnRestaurantSelect(Restaurant r) {

    }

    @Override
    public void OnRestaurantSelected(ArrayList<Restaurant> r) {

    }

    @Override
    public void OnRestaurantSelectionMode() {
        tb.setVisibility(View.GONE);
    }

    @Override
    public void OnRestaurantSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
    }

    @Override
    public void onBackPressed() {
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(restListFrag);
        }
    }
}
