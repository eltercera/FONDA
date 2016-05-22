package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import com.ds201625.fonda.R;
import com.ds201625.fonda.logic.HandlerSQLite;


/**
 * Fragment que contiene el formulario de para un perfil
 */
public class CreditCardFragment extends BaseFragment {

    //View elements
    private Spinner spn;
    private View form;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        form = inflater.inflate(R.layout.fragment_add_n_select_cc, container, false);
        spn = (Spinner) form.findViewById(R.id.spinnerCC);
        HandlerSQLite handlerSQLite = new HandlerSQLite(this.getContext());
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getContext(),
                android.R.layout.simple_spinner_item, handlerSQLite.read());
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spn.setAdapter(LTRadapter);

        return form;
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
