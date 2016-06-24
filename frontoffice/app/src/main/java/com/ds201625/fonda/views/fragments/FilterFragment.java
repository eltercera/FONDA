package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.ListView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.views.contracts.RestaurantsFiltersContract;
import com.ds201625.fonda.views.presenters.RestaurantsFilterPresenter;


public class FilterFragment extends BaseFragment
        implements SwipeRefreshLayout.OnRefreshListener,RestaurantsFiltersContract {

    private ListView listView;

    private SwipeRefreshLayout swipeRefreshLayout;

    private RestaurantsFilterPresenter presenter;

    private int lastfirstVisibleItem = 100;
    private int lastvisibleItemCount = 100;

    public void setPresenter(RestaurantsFilterPresenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public ListView getListView() {
        return this.listView;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View layout = inflater.inflate(R.layout.fragment_filter,container,false);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);

        if (this.listView == null)
            this.listView = (ListView)layout.findViewById(R.id.lvFilterList);

        this.presenter.onCreateView();

        this.listView.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView view, int scrollState) {

            }

            @Override
            public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {

                if (totalItemCount > 0 && lastfirstVisibleItem !=firstVisibleItem
                        && lastvisibleItemCount != visibleItemCount) {
                    int lastInScreen = firstVisibleItem + visibleItemCount;
                    if(lastInScreen == totalItemCount) {
                        lastfirstVisibleItem =firstVisibleItem;
                        lastvisibleItemCount = visibleItemCount;
                        presenter.scrollOnBottom();
                    }
                }
            }
        });

        return layout;
    }

    @Override
    public void onRefresh() {
        this.swipeRefreshLayout.setRefreshing(true);
        this.presenter.onRefresh();
        this.swipeRefreshLayout.setRefreshing(false);
    }
}
