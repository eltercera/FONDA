package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.ds201625.fonda.R;

import org.w3c.dom.Text;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class OrderPaymentFragment extends BaseFragment {



    private String[] pay = {"  " +
            "Monto Total      Bs.    2000   ",
            "Seleccionar Perfil",
            "Seleccionar TDC"};
    private ListView lv1;
    private String [] values = {" % ", " Bs. "};
    private Spinner spinner;
    private String changed;
    private EditText etTip;
    private TextView tvTip;
    private View layout;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

       layout = inflater.inflate(R.layout.fragment_order_payment,container,false);

        // Elements of the list
        lv1 =(ListView)layout.findViewById(R.id.lVOrden);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),android.R.layout.simple_list_item_1, pay);
        lv1.setAdapter(adapter);

        // Allow to choose the payment of the tip, in percent or in the current currency
        spinner = (Spinner) layout.findViewById(R.id.spinner);
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getActivity(), android.R.layout.simple_spinner_item, values);
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spinner.setAdapter(LTRadapter);


        // Verify and reflects the amount of the tip
        tvTip = (TextView) layout.findViewById(R.id.tvTip);
        etTip = (EditText) layout.findViewById(R.id.etTip);
        changed = etTip.getText().toString();
        etTip.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {
                if (spinner.getSelectedItemPosition()==0)
                {

                }
                else if (spinner.getSelectedItemPosition()==1)
                {
                    tvTip.setText(etTip.getText().toString());
                }

            }
        });

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
