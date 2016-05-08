package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;


/**
 * Fragment que contiene el formulario de para un perfil
 */
public class CreditCardFragment extends BaseFragment {

    //Elementos de la vista
    private Spinner spn;
    private String [] values = {" 1234568901234567890 ", " 09876543211234567890"};
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
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getActivity(), android.R.layout.simple_spinner_item, values);
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
