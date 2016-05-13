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

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class CloseAccountFragment extends BaseFragment {


    private ListView lv1;

    private CloseViewItemList closeViewItem;

    private ArrayList<DishOrder> listDishO = new ArrayList<DishOrder>();

    Currency currency = new Currency("Bs.");
    Dish dish1 = new Dish("Pasta","Pasta Con Salmon",1000,String.valueOf(R.drawable.salmonpasta),currency);
    Dish dish2 = new Dish("Refresco","Coca-Cola",100,String.valueOf(R.drawable.refresco),currency);
    Dish dish3 = new Dish("Torta","Terciopelo Rojo",500,String.valueOf(R.drawable.redv2),currency);

    Table table = new Table(1,2);
    Date date = new Date();
    DishOrder dishO1 = new DishOrder(dish1,1);
    DishOrder dishO2 = new DishOrder(dish2,1);
    DishOrder dishO3 = new DishOrder(dish3,1);

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        listDishO.add(dishO1);
        listDishO.add(dishO2);
        listDishO.add(dishO3);
      //  Account account = new Account(table,listDishO,date);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

        View layout = inflater.inflate(R.layout.fragment_close_account,container,false);

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

        Account account = new Account(table,listDishO,date,(float)iva,total,sub);



        TextView txtDate = (TextView) layout.findViewById(R.id.tvDate);
        TextView txtHour = (TextView) layout.findViewById(R.id.textView20);

        TextView txtMontoSub = (TextView) layout.findViewById(R.id.tVSubTotalValor);
        TextView txtMonSub = (TextView) layout.findViewById(R.id.tVSubMoneda);

        TextView txtMontoIva = (TextView) layout.findViewById(R.id.tVIVAValor);
        TextView txtMonIva = (TextView) layout.findViewById(R.id.tVIVAMoneda);

        TextView txtMontoTota = (TextView) layout.findViewById(R.id.tvMontoTotal);
        TextView txtMonTota = (TextView) layout.findViewById(R.id.tVTotalMoneda);

        txtDate.setText(formattedDate);
        txtHour.setText(formattedHour);
        txtMontoSub.setText(String.valueOf(sub));
        txtMonSub.setText(currency.getSymbol());
        txtMontoIva.setText(String.valueOf(iva));
        txtMonIva.setText(currency.getSymbol());
        txtMontoTota.setText(String.valueOf(total));
        txtMonTota.setText(currency.getSymbol());


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


    public float calcularSubTotal(ArrayList<DishOrder> listDishO){
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


    public double calcularIVA(float sub){

        double iva = sub * (0.12);

        return iva;
    }

    public float calcularTotal(float sub, double iva){

        float result = sub + (float) iva;

        return result;
    }


}
