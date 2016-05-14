package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.domains.Currency;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.views.adapters.OrderViewItemList;
import java.util.ArrayList;
import java.util.List;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class CurrentOrderFragment extends BaseFragment {


    private ArrayList<DishOrder> listDishO = new ArrayList<DishOrder>();

    ListView list;
    private OrderViewItemList orderList;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Currency currency = new Currency("Bs.");
        Dish dish1 = new Dish("Pasta","Pasta Con Salmon",1000,String.valueOf(R.drawable.salmonpasta),currency);
        Dish dish2 = new Dish("Refresco","Coca-Cola",100,String.valueOf(R.drawable.refresco),currency);
        Dish dish3 = new Dish("Torta","Terciopelo Rojo",500,String.valueOf(R.drawable.redv2),currency);

        DishOrder dishO1 = new DishOrder(dish1,1);
        DishOrder dishO2 = new DishOrder(dish2,1);
        DishOrder dishO3 = new DishOrder(dish3,1);

        listDishO.add(dishO1);
        listDishO.add(dishO2);
        listDishO.add(dishO3);
    }



    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                              Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View layout = inflater.inflate(R.layout.fragment_current_order,container,false);

        orderList = new OrderViewItemList(getContext());
        orderList.addAll(listDishO);

        list=(ListView)layout.findViewById(R.id.lvOrderList);
        list.setAdapter(orderList);

        return layout;


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
