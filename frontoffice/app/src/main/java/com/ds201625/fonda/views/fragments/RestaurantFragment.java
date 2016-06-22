package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.adapters.RestaurantViewItemList;

/**
 * Created by gbsoj on 6/1/2016.
 */
public class RestaurantFragment extends BaseFragment
        implements SwipeRefreshLayout.OnRefreshListener
{
    RestaurantFragmentListener mCallBack;
    //Elementos de la vista.
    private ListView restaurantes;
    private SwipeRefreshLayout swipeRefreshLayout;
    private RestaurantViewItemList restaurantList;

    //Para configurar si la lista es multiples secciones o no
    private boolean multi;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //TODO: agregar try/catch en caso de que no se pase el argumento.
        multi = getArguments().getBoolean("multiSelect");
        restaurantList = new RestaurantViewItemList(getContext());
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_restaurant_list,container,false);

       restaurantes = (ListView)layout.findViewById(R.id.lvRestaurantList);
       swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
       swipeRefreshLayout.setOnRefreshListener(this);
       restaurantes.setAdapter(restaurantList);
       restaurantes.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Restaurant item = restaurantList.getItem(position);
                mCallBack.OnRestaurantSelect(item);
            }
        });
        return layout ;
    }

    public void onRefresh() {
        updateList();
    }

    public void updateList() {
        swipeRefreshLayout.setRefreshing(true);
        restaurantList.update();
        restaurantes.refreshDrawableState();
        swipeRefreshLayout.setRefreshing(false);
    }

    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            mCallBack = (RestaurantFragmentListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString()
                    + " must implement OnHeadlineSelectedListener");
        }
    }

    public void onDetach() {
        super.onDetach();
    }


    public interface RestaurantFragmentListener {
        /**
         * Cuando es seleccionado un restaurante
         * @param restaurante
         */
        void OnRestaurantSelect(Restaurant restaurante);

        /**
         * Cuando el modo se seleccion inicia
         */
        void OnRestaurantSelectionMode();

        /**
         * Cuando el modo de seleccion finaliza
         */
        void OnRestaurantSelectionModeExit();
    }
}
