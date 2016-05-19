package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.views.adapters.CloseViewItemList;
import com.ds201625.fonda.views.adapters.OrderViewItemList;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class CloseAccountFragment extends BaseFragment {




    String[] names = {
            "Pasta Con Salmon",
            "Coca-Cola",
            "Terciopelo Rojo"
    } ;
    String[] quantity = {
            "1",
            "1",
            "1"} ;
    String[] price = {
            "Bs. 1000",
            "Bs. 100",
            "Bs. 500"} ;
    private ListView lv1;

    private CloseViewItemList closeViewItem;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

        View layout = inflater.inflate(R.layout.fragment_close_account,container,false);

        CloseViewItemList adapter = new CloseViewItemList(getContext(),quantity,names,price);
        lv1=(ListView)layout.findViewById(R.id.lVOrden);
        lv1.setAdapter(adapter);

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
