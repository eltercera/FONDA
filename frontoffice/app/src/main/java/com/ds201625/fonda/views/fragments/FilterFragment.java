package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;
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

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_filter,container,false);
        TabLayout tabLayout = (TabLayout) layout.findViewById(R.id.tabs);
        position = tabLayout.getSelectedTabPosition();
        lvItems = (ListView)layout.findViewById(R.id.lvFilterList);
        switch (position){
            case 0:
                lvItems.setAdapter(new RestaurantAdapter(getContext()));
                break;
            case 1:
                lvItems.setAdapter(new ZonesAdapter(getContext()));
                break;
            case 2:
                lvItems.setAdapter(new CategoriesAdapter(getContext()));
                break;
        }


        return layout;
    }
}
