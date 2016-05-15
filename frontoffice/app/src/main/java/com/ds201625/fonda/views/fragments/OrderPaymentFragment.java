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
import com.ds201625.fonda.views.activities.OrdersActivity;

import java.text.SimpleDateFormat;
import java.util.Calendar;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class OrderPaymentFragment extends BaseFragment {


    private float amount;
    private String selectCC = "";
    private ListView lv1;
    private String [] values = {" % ", " Bs. "};
    private Spinner spinner;
    private EditText etTip;
    private TextView tvTip;
    private View layout;
    private TextView tvAccount;
    private CreditCardFragment ccFrag;
    private TextView date;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    private void getAllElements(){
        tvAccount = (TextView)layout.findViewById(R.id.tvAccount);
        tvTip = (TextView)layout.findViewById(R.id.tvTip);
        etTip = (EditText)layout.findViewById(R.id.etTip);
        lv1 =(ListView)layout.findViewById(R.id.lVOrden);
        date = (TextView)layout.findViewById(R.id.tvDate);
        spinner = (Spinner) layout.findViewById(R.id.spinner);
    }


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        layout = inflater.inflate(R.layout.fragment_order_payment,container,false);
        getAllElements();
        String selectedCCPass = null;
        float amountRec = 0;

        try {
            amountRec = getArguments().getFloat("amount");
            selectedCCPass = getArguments().getString("creditC");
        }catch (NullPointerException n)
        { n.getMessage();}
        finally {
            if(selectedCCPass != null) {
                selectCC = selectedCCPass;
                amount = amountRec;
            }
                amount = amountRec;

        }


        float always = amount;
        //String that fill the listview
        String[] pay = {"Monto Total " +
                " Bs." + always,
                "Seleccionar Perfil",
                "Tarjeta de Crédito: "+selectCC};
        // Add Elements to the list
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),android.R.layout.simple_list_item_1, pay);
        lv1.setAdapter(adapter);

        // Allow to choose the payment of the tip, in percent or in the current currency
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getActivity(), android.R.layout.simple_spinner_item, values);
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spinner.setAdapter(LTRadapter);
        //sets date
        Calendar c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
        String formattedDate = df.format(c.getTime());
        date.setText(formattedDate);
        EventReg();

        return layout;
    }


    private void setTip()
    {
        try {
            float tip;
            float add;
            int idSpinner = spinner.getSelectedItemPosition();

        if (idSpinner==0)
            {
                tvTip.setText("");
                tvAccount.setText("");
                tip = (Float.parseFloat(etTip.getText().toString()) / 100) * amount;
                add = tip + amount;
                tvTip.setText(Float.toString(tip));
                tvAccount.setText(Float.toString(add));
            }
        else if (idSpinner==1)
            {
                tvTip.setText("");
                tvAccount.setText("");
                tvTip.setText(etTip.getText().toString());
                add = Float.parseFloat(etTip.getText().toString()) + amount;
                tvAccount.setText(Float.toString(add));
            }
        }
        catch (NumberFormatException e){
            e.getMessage();
            System.out.println("Ha ocurrido un error de formato de numero");
        }
    }

    private void EventReg(){
        lv1 = (ListView)layout.findViewById(R.id.lVOrden);

        lv1.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                String itemSelected = parent.getItemAtPosition(position).toString();

                switch(position){
                    case 0:
                        Toast.makeText(getContext(), "Su " + itemSelected, Toast.LENGTH_SHORT).show();
                        break;
                    case 1:
                        //Intent cambio = new Intent (getContext(),ProfileListFragment.class);
                        //startActivity(cambio);
                        break;
                    case 2:

                         ccFrag = new CreditCardFragment();
                         OrdersActivity.showFragment(ccFrag);
                         System.out.println("ENTROOOOOOOOOOOOOOO A LA TDC");


                        break;
                }
            }
        });
    }

     //La vista ha sido creada y cualquier configuración guardada está cargada
    @Override
    public void onViewStateRestored(Bundle savedInstanceState) {
        super.onViewStateRestored(savedInstanceState);
        EventReg();
        // Verify and reflects the amount of the tip

        etTip.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                setTip();
            }

            @Override
            public void afterTextChanged(Editable s) {
                setTip();
            }
        });
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
