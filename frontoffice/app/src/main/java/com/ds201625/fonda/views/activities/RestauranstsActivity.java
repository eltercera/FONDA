package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.FilterFragment;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;

/**
 * Activity para la busqueda de restaurantes
 */
public class RestauranstsActivity extends BaseNavigationActivity {

    /**
     * Componentes de la bista
     */
    private ViewPager viewPager;
    private TabLayout tabLayout;

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

        //creación de componentes
        this.pagerAdapter = new BaseSectionsPagerAdapter
                (this.getSupportFragmentManager(),this.tabLayout);

        //creación de fragments
        this.generalFilterFragment = new FilterFragment();
        this.generalFilterPresenter = new RestaurantsFilterPresenter
                (this.generalFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.GENERAL);
        this.generalFilterFragment.setPresenter(this.generalFilterPresenter);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_global),this.generalFilterFragment);

        this.categoryFilterFragment = new FilterFragment();
        this.categoryFilterPresenter = new RestaurantsFilterPresenter
                (this.categoryFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.CATEGORY);
        this.categoryFilterFragment.setPresenter(this.categoryFilterPresenter);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_food),this.categoryFilterFragment);

        this.zoneFilterFragment = new FilterFragment();
        this.zoneFilterPresenter = new RestaurantsFilterPresenter
                (this.zoneFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.ZONE);
        this.zoneFilterFragment.setPresenter(this.zoneFilterPresenter);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_zone),this.zoneFilterFragment);

        // Set de Adapters de tabs y view pager
        this.viewPager.setAdapter(this.pagerAdapter);
        this.tabLayout.setupWithViewPager(this.viewPager);
        this.pagerAdapter.iconsSetup();
    }

}