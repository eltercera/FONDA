package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CategoryService;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.views.activities.FilterCategoryList;

import java.util.Iterator;
import java.util.List;

/**
 * Created by Valentina on 17/04/2016.
 */
public class FoodFragment extends BaseFragment {

    /**
     * List view para mostrar lista en pantalla
     */
    private ListView list;
    /**
     * Servicio de categorias
     */
    private CategoryService categoryService;
    /**
     *Lista que contiene las categorias
     */
    private List<RestaurantCategory> listCategory;
    /**
     * Adaptador para el list view
     */
    private FilterCategoryList adapter;
    /**
     * Iterador para recorrer las categorias
     */
    private Iterator iterator;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View view= inflater.inflate(R.layout.fragment_food,container,false);
        list=(ListView)view.findViewById(R.id.listViewRestaurants);

        categoryService = FondaServiceFactory.getInstance().getCategoryService();
        listCategory = categoryService.getRestaurantCategory();
        iterator = listCategory.listIterator();


        FilterCategoryList adapter = new
                FilterCategoryList(getActivity(),listCategory);

        list.setAdapter(adapter);

       /* list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                Toast.makeText(getActivity(), "You Clicked at " + location[+position], Toast.LENGTH_SHORT).show();
                Intent intent = new Intent (getActivity(),AllRestaurantActivity.class);
                startActivity(intent);
            }
        });
*/
        setupListView();
        return view;

    }

    private void setupListView() {
        FilterCategoryList adapter = new FilterCategoryList(getActivity(), listCategory);
        list.setAdapter(adapter);

    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }



}


