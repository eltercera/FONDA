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
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.LogicPayment;
import com.ds201625.fonda.views.activities.OrdersActivity;
import java.text.SimpleDateFormat;
import java.util.Calendar;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class OrderPaymentFragment extends BaseFragment {

    /**
     * Receives the amount
     */
    private float amount;
    /**
     * Shows which is the selected Credit card
     */
    private String selectCC = "";
    /**
     * ListView of Amount, credit card and profile
     */
    private ListView lv1;
    /**
     * Values of the combo box for the tip
     */
    private String [] values = {" % ", " Bs. "};
    /**
     * Spinner that shows the saved creditcards
     */
    private Spinner spinner;
    /**
     * Receives the amount of tip
     */
    private EditText etTip;
    /**
     * Set the amount of tip in currency
     */
    private TextView tvTip;
    /**
     * View
     */
    private View layout;
    /**
     * Sets the total of the bill (Subtota+tax+tip)
     */
    private TextView tvAccount;
    /**
     * Shows the actual date
     */
    private TextView date;
    /**
     * Shows the amount of the check (Subtotal+tax)
     */
    private float always;
    /**
     *
     */
    private InvoiceService invoiceService;
    /**
     * Calendar
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



    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    /**
     * Contains all the asignations
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
        //String that fill the listview
        String[] pay = {"Monto Total " +
                " Bs." + always,
                "Seleccionar Perfil",
                "Tarjeta de Crédito: "+selectCC};
        // Add Elements to the list
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getContext(),
                android.R.layout.simple_list_item_1, pay);
        lv1.setAdapter(adapter);

        // Allow to choose the payment of the tip, in percent or in the current currency
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this.getActivity(),
                android.R.layout.simple_spinner_item, values);
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spinner.setAdapter(LTRadapter);
        //sets date
        c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
        String formattedDate = df.format(c.getTime());
        date.setText(formattedDate);
        EventReg();

        return layout;
    }

    /**
     * Sets the tip of type percet or type currency according to type selected
     */
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

    /**
     * Gets the item selected on Fragment Credit Card and Fragment Profile and shows it on listview
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
     * It activates when the view is restored
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
     * Sends the information of the bill to Web Service
     */
    public void setBill(){

        try {
            invoiceService = FondaServiceFactory.getInstance().getInvoiceService();



        }
        catch (NullPointerException e){
            System.out.println("No es posible realizar la conexión con el Web Server ");
        }
        catch (Exception e){
            System.out.println("Error en la Conexión");
        }
    }

    private void postPayment() {
        //ESTE OBJETO SE GENERA CON INFORMACION SACADA DE OTRO LADO
        //Invoice invoice = new Invoice();
        float a=150;
        //invoice.setTax(a);
        Invoice invoice = new Invoice();
        invoice = null;

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
