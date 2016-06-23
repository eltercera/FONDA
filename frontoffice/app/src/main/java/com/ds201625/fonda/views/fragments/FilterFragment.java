package com.ds201625.fonda.views.fragments;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.activities.AllRestaurantActivity;
import com.ds201625.fonda.views.activities.DetailRestaurantActivity;
import com.ds201625.fonda.views.activities.RestauranstsActivity;
import com.ds201625.fonda.views.adapters.CategoriesAdapter;
import com.ds201625.fonda.views.adapters.RestaurantAdapter;
import com.ds201625.fonda.views.adapters.ZonesAdapter;

import java.util.Collection;

/**
 * Created by gbsoj on 6/22/2016.
 */
public class FilterFragment extends BaseFragment {

    private ListView lvItems;
    private int position;
    private int scrollFirstItem;
    private int scrollLastItem;
    private int scrollTotalItem;
    private TabLayout tabLayout;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_filter,container,false);
        position = tabLayout.getSelectedTabPosition();
        lvItems = (ListView)layout.findViewById(R.id.lvFilterList);
        switch (position){
            case 0:
                lvItems.setAdapter(new RestaurantAdapter(getContext()));
                lvItems.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Restaurant item = (Restaurant) lvItems.getItemAtPosition(position);
                        Intent intent = new Intent(getActivity(), DetailRestaurantActivity.class);
                        startActivity(intent);
                    }
                });
                break;
            case 1:
                lvItems.setAdapter(new ZonesAdapter(getContext()));
                break;
            case 2:
                lvItems.setAdapter(new CategoriesAdapter(getContext()));
                break;
        }

        lvItems.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView view, int scrollState) {
           }

            @Override
            public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {
                boolean loadMore = (firstVisibleItem + visibleItemCount) >= totalItemCount ;
                if(loadMore){
                    switch (position) {
                        case 0:
                            RestaurantAdapter actualAdapter = (RestaurantAdapter) lvItems.getAdapter();
                            actualAdapter.update();
                            break;
                        case 1:
                            ZonesAdapter actualAdapter2 = (ZonesAdapter) lvItems.getAdapter();
                            actualAdapter2.update();
                            break;
                        case 2:
                            CategoriesAdapter actualAdapter3 = (CategoriesAdapter) lvItems.getAdapter();
                            actualAdapter3.update();
                            break;
                    }
                }
            }
        });

        return layout;
    }

    public void setTabLayout(TabLayout tabLayout) {
        this.tabLayout = tabLayout;
    }

   /* public void onScroll(final int firstVisibleItem,
                         final int visibleItemCount, final int totalItemCount) {
        scrollFirstItem=lvItems.getFirstVisiblePosition();
        scrollLastItem=lvItems.getLastVisiblePosition();
        if (scrollLastItem == scrollTotalItem) {
            switch (position) {
                case 0:
                    RestaurantAdapter actualAdapter = (RestaurantAdapter) lvItems.getAdapter();
                    actualAdapter.update();
                    break;
                case 1:
                    ZonesAdapter actualAdapter2 = (ZonesAdapter) lvItems.getAdapter();
                    //actualAdapter2.update();
                    break;
                case 2:
                    CategoriesAdapter actualAdapter3 = (CategoriesAdapter) lvItems.getAdapter();
                    //actualAdapter3.update();
                    break;
            }
            scrollTotalItem=lvItems.getCount();
        }
    }*/
}
