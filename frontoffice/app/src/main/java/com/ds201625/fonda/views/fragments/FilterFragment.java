package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;

/**
 * Created by gbsoj on 6/22/2016.
 */
public class FilterFragment extends BaseFragment {

    private ListView lvItems;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_filter,container,false);

        lvItems = (ListView)layout.findViewById(R.id.lvFilterList);
//        lvItems.setAdapter(); //SetearAdapter

        return layout;
    }
}
