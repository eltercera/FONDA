package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.OrderViewItemList;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class CurrentOrderFragment extends BaseFragment {

    ListView list;
    String[] names = {
            "Pasta Con Salmon",
            "Coca-Cola",
            "Terciopelo Rojo"
    } ;
    String[] tipo = {
            "Pasta",
            "Refresco",
            "Torta"} ;
    String[] precio = {
            "Bs. 1000",
            "Bs. 100",
            "Bs. 500"} ;
    Integer[] imageId = {
            R.drawable.salmonpasta,
            R.drawable.refresco,
            R.drawable.redv2
    };

    private MenuItem cerrarBotton;
    private OrderViewItemList orderList;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                              Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View layout = inflater.inflate(R.layout.fragment_current_order,container,false);

        OrderViewItemList adapter = new OrderViewItemList(getContext(),
                tipo,names,precio,imageId);
        list=(ListView)layout.findViewById(R.id.lvOrderList);
        list.setAdapter(adapter);



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
