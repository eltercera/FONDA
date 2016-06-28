package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.logic.LogicInvoice;
import com.ds201625.fonda.views.adapters.InvoiceViewItemList;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsViewPresenter;
import com.ds201625.fonda.views.contracts.LogicInvoiceView;
import com.ds201625.fonda.views.contracts.LogicInvoiceViewPresenter;
import com.ds201625.fonda.views.presenters.LogicInvoicePresenter;

import java.util.List;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Iterator;
/**
 * Clase Fragment que muestra la factura
 */
public class InvoiceFragment extends BaseFragment implements LogicInvoiceView {

    /**
     * Lista
     */
    private ListView lv1;

    /**
     * Vista de lista
     */
    private InvoiceViewItemList invoiceViewItem;

    /**
     * Lista de platos ordenados
     */
    private List<DishOrder> listDishO;

    /**
     * Factura de la cuenta
     */
    private Invoice invoice;

    /**
     *  Atributo de tipo LogicInvoice que controla el acceso al WS
     */
    private LogicInvoice logicInvoice;
    private String TAG = "InvoiceFragment";

    private LogicInvoiceViewPresenter presenter;
    /**
     * Metodo que se ejecuta al instanciar el fragment
     * @param savedInstanceState Bundle que define el estado de la instancia
     */
    @Nullable
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        super.onCreate(savedInstanceState);
        invoiceViewItem = new InvoiceViewItemList(getContext());
        presenter = new LogicInvoicePresenter(this);
        Log.d(TAG,"Ha salido en onCreate");
    }

    /**
     * Metodo que crea la vista de la factura
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

        View layout = inflater.inflate(R.layout.fragment_factura,container,false);

        invoice = getInvoiceSW();
        listDishO = invoice.getAccount().getListDish();
        invoiceViewItem = new InvoiceViewItemList(getContext());
        invoiceViewItem.addAll(listDishO);

        float sub = calcularSubTotal(listDishO);
        System.out.println("SubTotal: " + sub);
        double iva = invoice.getTax();
        float total = invoice.getTotal();
        Calendar c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
        String formattedDate = df.format(c.getTime());
        float propina = invoice.getTip();



        TextView txtName = (TextView) layout.findViewById(R.id.tvTitulo);
        TextView txtDir = (TextView) layout.findViewById(R.id.tvDireccion);
        TextView txtNum = (TextView) layout.findViewById(R.id.tvNumInvoice);
        TextView txtDate = (TextView) layout.findViewById(R.id.tvDate);

        TextView txtCiRif = (TextView) layout.findViewById(R.id.tvCIRIF);
        TextView txtClient = (TextView) layout.findViewById(R.id.tvCliente);

        TextView txtMontoSub = (TextView) layout.findViewById(R.id.tvSubTotalValor);
        TextView txtMonSub = (TextView) layout.findViewById(R.id.tvSubMoneda);

        TextView txtMontoIva = (TextView) layout.findViewById(R.id.tVIVAValor);
        TextView txtMonIva = (TextView) layout.findViewById(R.id.tvIVAMoneda);

        TextView txtMontoTota = (TextView) layout.findViewById(R.id.tvMontoTotal);
        TextView txtMonTota = (TextView) layout.findViewById(R.id.tvTotalMoneda);

        TextView txtMontoPro = (TextView) layout.findViewById(R.id.tvMontoPropina);
        TextView txtMonPro = (TextView) layout.findViewById(R.id.tvMonedaPropina);

        TextView txtDesc = (TextView) layout.findViewById(R.id.txt2);
        TextView txtPric = (TextView) layout.findViewById(R.id.txt3);

        txtName.setGravity(Gravity.CENTER);
        txtDir.setGravity(Gravity.CENTER);
        txtDesc.setGravity(Gravity.CENTER);
        txtPric.setGravity(Gravity.RIGHT);

        //Nombre del Restaurant
        txtName.setText(invoice.getRestaurant().getName());
        //Direccion del Restaurant
        txtDir.setText(invoice.getRestaurant().getAddress());
        //Numero de la Factura
        //El numero de la factura deberia ser autogenerado
        txtNum.setText("001");
        //Fecha y hora
        txtDate.setText(formattedDate);
        //Cedula del Cliente o ssn
        txtCiRif.setText(invoice.getProfile().getPerson().getSsn());
        //Nombre del cliente
        txtClient.setText(invoice.getProfile().getPerson().getName());
        //Subtotal
        txtMontoSub.setText(String.valueOf(sub));
        txtMonSub.setText(invoice.getCurrency().getSymbol());
        //Iva
        txtMontoIva.setText(String.valueOf(iva));
        txtMonIva.setText(invoice.getCurrency().getSymbol());

        //Total
        txtMontoTota.setText(String.valueOf(total));
        txtMonTota.setText(invoice.getCurrency().getSymbol());
        //Propina
        txtMontoPro.setText(String.valueOf(propina));
        txtMonPro.setText(invoice.getCurrency().getSymbol());

        //Lista de Platos
        lv1=(ListView)layout.findViewById(R.id.lvOrderDish);
        lv1.setAdapter(invoiceViewItem);

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

    public float calcularSubTotal(List<DishOrder> listDishO){
        float sub = 0;
        float costo;
        int cant;

        Iterator iterator = listDishO.listIterator();
        while (iterator.hasNext()) {
            DishOrder dishOrder = (DishOrder) iterator.next();
            costo = dishOrder.getDish().getCost();
            cant = dishOrder.getCount();

            sub += costo*cant;
        }
        return sub;
    }

    /**
     * Metodo que obtiene los elementos del WS
     */
    @Override
    public Invoice getInvoiceSW() {
        Invoice invoiceWS;
        logicInvoice = new LogicInvoice();
        Log.d(TAG,"Ha ingresado a getInvoiceSW");
        try {
            presenter.findLoggedComensal();
            invoiceWS = presenter.findAllInvoice();
            Log.e(TAG, "Restaurant de la factura:  " + invoiceWS.getRestaurant().getName());
            return invoiceWS;
        } catch (NullPointerException nu) {
            Log.e(TAG, "Error en getHistoryVisitsSW al obtener los pagos", nu);
        } catch (Exception e) {
            Log.e(TAG, "Error en la Conexión");
        }
        return null;
    }
}