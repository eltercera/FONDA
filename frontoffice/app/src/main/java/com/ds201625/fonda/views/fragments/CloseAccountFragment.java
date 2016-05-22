package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CurrentOrderService;
import com.ds201625.fonda.domains.Account;
import com.ds201625.fonda.domains.Currency;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.domains.Table;
import com.ds201625.fonda.views.adapters.CloseViewItemList;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

/**
 * Clase Fragment que muestra el cierre de cuenta
 */
public class CloseAccountFragment extends BaseFragment {

    public static float amount;

    /**
     * Lista
     */
    private ListView lv1;

    /**
     * Vista de lista
     */
    private CloseViewItemList closeViewItem;

    /**
     * Lista de DishOrder que contiene la lista de platos ordenados
     */
    private List<DishOrder> listDishO;

    /**
     *  Servicio de orden actual
     */
    private CurrentOrderService currentOrderService;


    /**
     * Metodo que se ejecuta al instanciar el fragment
     * @param savedInstanceState Bundle que define el estado de la instancia
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    /**
     * Metodo que crea la vista de la cierre de cuenta
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {


        View layout = inflater.inflate(R.layout.fragment_close_account,container,false);

        //Llamada al metodo que se comunica con el WS
        listDishO = getListSW();
        closeViewItem = new CloseViewItemList(getContext());
        closeViewItem.addAll(listDishO);

        float sub = calcularSubTotal(listDishO);
        System.out.println("SubTotal: " + sub);
        double iva = calcularIVA(sub);
        System.out.println("IVA: " + iva);
        float total = calcularTotal(sub,iva);
        System.out.println("Total: " + total);
        Calendar c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
        SimpleDateFormat dfh = new SimpleDateFormat("HH:mm:ss");
        String formattedDate = df.format(c.getTime());
        String formattedHour = dfh.format(c.getTime());

        setAmount(total);
        System.out.println("AMOUNT yunet: " + amount);

        TextView txtDate = (TextView) layout.findViewById(R.id.tvDate);
        TextView txtHour = (TextView) layout.findViewById(R.id.textView20);

        TextView txtMontoSub = (TextView) layout.findViewById(R.id.tvSubTotalValor);
        TextView txtMonSub = (TextView) layout.findViewById(R.id.tvSubMoneda);

        TextView txtMontoIva = (TextView) layout.findViewById(R.id.tVIVAValor);
        TextView txtMonIva = (TextView) layout.findViewById(R.id.tvIVAMoneda);

        TextView txtMontoTota = (TextView) layout.findViewById(R.id.tvMontoTotal);
        TextView txtMonTota = (TextView) layout.findViewById(R.id.tvTotalMoneda);

        //Fecha
        txtDate.setText(formattedDate);
        //Hora
        txtHour.setText(formattedHour);
        //Subtotal
        txtMontoSub.setText(String.valueOf(sub));
        //txtMonSub.setText(currency.getSymbol());
        //Iva
        txtMontoIva.setText(String.valueOf(iva));
        // txtMonIva.setText(currency.getSymbol());
        //Total
        txtMontoTota.setText(String.valueOf(total));
        // txtMonTota.setText(currency.getSymbol());


        lv1=(ListView)layout.findViewById(R.id.lVOrden);
        lv1.setAdapter(closeViewItem);

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

    public static float getAmount() {
        return amount;
    }

    public static void setAmount(float amount) {
        CloseAccountFragment.amount = amount;
    }

    /**
     * Metodo que obtiene el subTotal de la Cuenta
     */
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
     * Metodo que obtiene el IVA de la Cuenta
     */
    public double calcularIVA(float sub){

        double iva = sub * (0.12);

        return iva;
    }

    /**
     * Metodo que obtiene el Total de la Cuenta
     */
    public float calcularTotal(float sub, double iva){

        float result = sub + (float) iva;

        return result;
    }

    /**
     * Metodo que obtiene los elementos del WS
     */
    public List<DishOrder> getListSW(){
        List<DishOrder> listDishOWS;
        try {
            currentOrderService = FondaServiceFactory.getInstance().getCurrentOrderService();
            listDishOWS = currentOrderService.getListDishOrder();
            for (int i = 0; i < listDishOWS.size(); i++) {
                System.out.println("Descripcion Plato:  " + listDishOWS.get(i).getDish().getDescription());
            }
            return listDishOWS;
        }
        catch (NullPointerException e){
            System.out.println("No es posible realizar la conexión con el Web Server ");
        }
        catch (Exception e){
            System.out.println("Error en la Conexión");
        }
        return null;
    }

}