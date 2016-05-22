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
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.data_access.services.PaymentService;
import com.ds201625.fonda.domains.Account;
import com.ds201625.fonda.domains.Currency;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Payment;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.LogicPayment;
import com.ds201625.fonda.views.activities.OrdersActivity;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

/**
 * Clase que maneja el Fragment de pago de orden
 */
public class OrderPaymentFragment extends BaseFragment {

    /**
     * Recibe el monto
     */
    private float amount;
    /**
     * Muestra cual es la TDC seleccionada
     */
    private String selectCC = "";
    /**
     * ListView del monto, TDC y perfil
     */
    private ListView lv1;
    /**
     * Valores para el combo Box de propina
     */
    private String [] values = {" % ", " Bs. "};
    /**
     * Spinner que muestra las TDC guardadas en la BD
     */
    private Spinner spinner;
    /**
     * Recibe el monto de la porpina
     */
    private EditText etTip;
    /**
     * Muestra el monto de la propina en moneda
     */
    private TextView tvTip;
    /**
     * Vista
     */
    private View layout;
    /**
     * Muestra el total de la cuenta (Subtotal+iva + propina)
     */
    private TextView tvAccount;
    /**
     * Mestra la fecha actual
     */
    private TextView date;
    /**
     * Muestra el total de la cuenta hasta el momento (Subtotal+iva)
     */
    private float always;
    /**
     *
     */
    private InvoiceService invoiceService;
    /**
     * Calendario
     */
    private Calendar c;

    /**
     * Payment
     */
    Invoice payment;

    /**
     * logicPayment
     */
    LogicPayment logicPayment;

    /**
     * Monto de la propina
     */
    private float tip;
    /**
     * Monto total (propina + subtotal + iva)
     */
    private float add;
    /**
     * Spinner que guarda el tipo de moneda y el porcentaje de la propina
     */
    private int idSpinner;
    /**
     * Fecha conformato
     */
    private String formattedDate;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    /**
     * Contiene todas las declaraciones
     */
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
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        postPayment();
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


        always = amount;
        //String que llena el listview
        String[] pay = {"Monto Total " +
                " Bs." + always,
                "Seleccionar Perfil",
                "Tarjeta de Crédito: "+selectCC};
        // Agrega elementos a la lista
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),
                android.R.layout.simple_list_item_1, pay);
        lv1.setAdapter(adapter);

        // Permite escoger el pago de la propina, en moneda o porcentaje
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getActivity(),
                android.R.layout.simple_spinner_item, values);
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spinner.setAdapter(LTRadapter);
        //Muestra la fecha
        c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
        formattedDate = df.format(c.getTime());
        date.setText(formattedDate);
        EventReg();

        return layout;
    }

    /**
     * Muestra la propina dwependiendo del tipo seleccionado
     */
    private void setTip()
        {
            idSpinner = spinner.getSelectedItemPosition();
        try {


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

    /**
     * Obtiene el item seleccionado en el fragment  y lo retorna al listview
     */
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
                       OrdersActivity.changeFrag(1);
                        break;
                    case 2:
                        OrdersActivity.changeFrag(2);
                        break;
                }
            }
        });
    }

    /**
     * Se activa cuando la vista se restaura
     * @param savedInstanceState
     */
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

    /**
     * Manda la informacion de la factura al web service
     */
    private void postPayment() {
        //ESTE OBJETO SE GENERA CON INFORMACION SACADA DE OTRO LADO
        CloseAccountFragment cls = new CloseAccountFragment();
        List<DishOrder> lista = cls.getListDishO();
        Payment paym = new Payment();
        Currency curr = new Currency();
        Profile prof = new Profile();
        Restaurant rest = new Restaurant();
        Account acc = new Account();

        
        paym.setAmount(always);

        acc.setListDish(lista);
        curr.setSymbol("Bs");
        float tax = cls.getIva();
        prof.setProfileName("Melanie");
        rest.setName("El Tinajero");

        Invoice invoice = new Invoice();
        invoice = null;
        invoice.setAccount(acc);
        invoice.setCurrency(curr);
        invoice.setDate(c.getTime());
        invoice.setPayment(paym);
        invoice.setProfile(prof);
        invoice.setRestaurant(rest);
        invoice.setTax(tax);
        invoice.setTip(tip);
        invoice.setTotal(add);

        logicPayment = new LogicPayment();
        try {
            payment = logicPayment.paymentService(invoice);
            //PRUEBA DE QUE HACE EL POST
            System.out.println("TAX1 : "+ payment.getTax());
        } catch (RestClientException e) {
            System.out.println(e.getMessage());
        } catch (InvalidDataRetrofitException e) {
            System.out.println(e.getMessage());
        }catch (Exception e) {
            System.out.println("Error");
        }


    }


}
