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

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class OrderPaymentFragment extends BaseFragment {



    private String[] comidas = {"  " +
            "Monto Total      Bs.    2000   ",
            "Seleccionar Perfil",
            "Seleccionar TDC"};
    private ListView lv1;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

        View layout = inflater.inflate(R.layout.fragment_order_payment,container,false);

        lv1 =(ListView)layout.findViewById(R.id.lVOrden);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),android.R.layout.simple_list_item_1, comidas);
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
