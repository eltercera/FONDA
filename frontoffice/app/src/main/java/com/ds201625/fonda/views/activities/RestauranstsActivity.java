package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.MenuItemCompat;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.SearchView;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.FilterFragment;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;

/**
 * Activity para la busqueda de restaurantes
 */
public class RestauranstsActivity extends BaseNavigationActivity
        implements SearchView.OnQueryTextListener,MenuItemCompat.OnActionExpandListener,
        FilterFragment.FilterFragmentListener{

    /**
     * Componentes de la vista
     */
    private ViewPager viewPager;
    private TabLayout tabLayout;
    private SearchView searchView;
    private MenuItem searchMenuItem;
    private View errorLayout;
    private View emtyLayout;

    /**
     * Adaptador para tabs
     */
    private BaseSectionsPagerAdapter pagerAdapter;

    /**
     * Fragmen y presentador para busqueda general
     */
    private FilterFragment generalFilterFragment;
    private RestaurantsFilterPresenter generalFilterPresenter;

    /**
     * Fragmen y presentador para busqueda por zona
     */
    private FilterFragment zoneFilterFragment;
    private RestaurantsFilterPresenter zoneFilterPresenter;

    /**
     * Fragmen y presentador para busqueda por categoria
     */
    private FilterFragment categoryFilterFragment;
    private RestaurantsFilterPresenter categoryFilterPresenter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {

        setContentView(R.layout.activity_restaurants);
        super.onCreate(savedInstanceState);

        //Obtencion de componentes
        this.viewPager = (ViewPager) findViewById(R.id.viewPager);
        this.tabLayout = (TabLayout) findViewById(R.id.tabs);
        this.emtyLayout = findViewById(R.id.empty_search_list);
        this.errorLayout = findViewById(R.id.no_connection_list);

        //creación de componentes
        this.pagerAdapter = new BaseSectionsPagerAdapter
                (this.getSupportFragmentManager(),this.tabLayout);

        //creación de fragments
        this.generalFilterFragment = new FilterFragment();
        this.generalFilterPresenter = new RestaurantsFilterPresenter
                (this.generalFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.GENERAL);
        this.generalFilterFragment.setPresenter(this.generalFilterPresenter);
        this.generalFilterFragment.setActivity(this);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_global),this.generalFilterFragment);

        this.categoryFilterFragment = new FilterFragment();
        this.categoryFilterPresenter = new RestaurantsFilterPresenter
                (this.categoryFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.CATEGORY);
        this.categoryFilterFragment.setPresenter(this.categoryFilterPresenter);
        this.categoryFilterFragment.setActivity(this);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_food),this.categoryFilterFragment);

        this.zoneFilterFragment = new FilterFragment();
        this.zoneFilterPresenter = new RestaurantsFilterPresenter
                (this.zoneFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.ZONE);
        this.zoneFilterFragment.setPresenter(this.zoneFilterPresenter);
        this.zoneFilterFragment.setActivity(this);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_zone),this.zoneFilterFragment);

        // Set de Adapters de tabs y view pager
        this.viewPager.setAdapter(this.pagerAdapter);
        this.tabLayout.setupWithViewPager(this.viewPager);
        this.pagerAdapter.iconsSetup();
    }

    @Override
    public void displayMsj(String msj) {
        Toast.makeText(this, msj, Toast.LENGTH_LONG).show();
    }

    @Override
    public void onBackPressed() {
        FilterFragment current = (FilterFragment)pagerAdapter.getItem(viewPager.getCurrentItem());
        if (current.onBackPressed())
            super.onBackPressed();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.filters_search, menu);

        this.searchMenuItem = menu.findItem(R.id.action_search_filters);

        MenuItemCompat.setOnActionExpandListener(this.searchMenuItem,this);
        this.searchView = (SearchView) this.searchMenuItem.getActionView();
        this.searchView.setOnQueryTextListener(this);

        return true;
    }

    @Override
    public boolean onQueryTextSubmit(String query) {
        FilterFragment current = (FilterFragment)pagerAdapter.getItem(viewPager.getCurrentItem());
        current.search(query);
        return false;
    }

    @Override
    public boolean onQueryTextChange(String newText) {
        return false;
    }

    @Override
    public boolean onMenuItemActionExpand(MenuItem item) {
        return true;
    }

    @Override
    public boolean onMenuItemActionCollapse(MenuItem item) {
        FilterFragment current = (FilterFragment)pagerAdapter.getItem(viewPager.getCurrentItem());
        current.search(null);
        return true;
    }

    @Override
    public void closeSearchView() {
        this.searchMenuItem.collapseActionView();
    }

    @Override
    public void setNormalView() {
        this.viewPager.setVisibility(View.VISIBLE);
        this.emtyLayout.setVisibility(View.GONE);
        this.errorLayout.setVisibility(View.GONE);
    }

    @Override
    public void setEmptyView() {
        this.viewPager.setVisibility(View.GONE);
        this.emtyLayout.setVisibility(View.VISIBLE);
        this.errorLayout.setVisibility(View.GONE);
    }

    @Override
    public void setErrorView() {
        this.viewPager.setVisibility(View.GONE);
        this.emtyLayout.setVisibility(View.GONE);
        this.errorLayout.setVisibility(View.VISIBLE);
    }

    @Override
    public void openRestaurantActiviy(Restaurant restaurant) {
        Intent intent = new Intent(this,DetailSearchRestaurantActivity.class);
        intent.putExtra("restaurant", restaurant);
        this.startActivity(intent);
    }
}