package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.FilterFragment;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;

public class RestauranstsActivity extends BaseNavigationActivity {

    /**
     * Componentes
     */
    private ViewPager viewPager;
    private BaseSectionsPagerAdapter pagerAdapter;
    private TabLayout tabLayout;

    private FilterFragment generalFilterFragment;
    private RestaurantsFilterPresenter generalFilterPresenter;

    private FilterFragment zoneFilterFragment;
    private RestaurantsFilterPresenter zoneFilterPresenter;


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

        this.generalFilterFragment = new FilterFragment();
        this.generalFilterPresenter = new RestaurantsFilterPresenter
                (this.generalFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.GENERAL);
        this.generalFilterFragment.setPresenter(this.generalFilterPresenter);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_global),this.generalFilterFragment);

        this.zoneFilterFragment = new FilterFragment();
        this.zoneFilterPresenter = new RestaurantsFilterPresenter
                (this.zoneFilterFragment,
                        RestaurantsFilterPresenter.RestaurantsFilterPresenterType.ZONE);
        this.zoneFilterFragment.setPresenter(this.zoneFilterPresenter);
        this.pagerAdapter.addFragment
                (getResources().getDrawable(R.drawable.ic_zone),this.zoneFilterFragment);

        this.viewPager.setAdapter(this.pagerAdapter);

        this.tabLayout.setupWithViewPager(this.viewPager);
        this.pagerAdapter.iconsSetup();
    }

}