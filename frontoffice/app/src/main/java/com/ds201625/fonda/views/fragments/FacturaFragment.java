package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Account;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Currency;
import com.ds201625.fonda.domains.Dish;
import com.ds201625.fonda.domains.*;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.domains.Table;
import com.ds201625.fonda.views.adapters.InvoiceViewItemList;
import java.util.List;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Iterator;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class FacturaFragment extends BaseFragment {

    private ListView lv1;

    private InvoiceViewItemList invoiceViewItem;

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

    RestaurantCategory category = new RestaurantCategory("Casual");
    Restaurant restaurant = new Restaurant("The dining room", "La Castellana", category);

    GenericPerson genericPerson = new GenericPerson();
    Commensal commensal = new Commensal();
    Profile profile = new Profile();
    List<Profile> profiles;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        listDishO.add(dishO1);
        listDishO.add(dishO2);
        listDishO.add(dishO3);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment

        View layout = inflater.inflate(R.layout.fragment_factura,container,false);

        invoiceViewItem = new InvoiceViewItemList(getContext());
        invoiceViewItem.addAll(listDishO);

        float sub = calcularSubTotal(listDishO);
        System.out.println("SubTotal: " + sub);
        double iva = calcularIVA(sub);
        System.out.println("IVA: " + iva);
        float total = calcularTotal(sub,iva);
        System.out.println("Total: " + total);
        Calendar c = Calendar.getInstance();
        SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
        String formattedDate = df.format(c.getTime());
        float propina = (float) (total*0.10);
        float totaltotal = total + propina;

        genericPerson.setSsn("19.739.625");
        genericPerson.setName("Yuneth Molina");
        profile.setProfileName("Yune");
        profile.setPerson(genericPerson);
//        profiles.add(profile);
    //    commensal.setProfiles(profiles);

        //quizas no necesite el iva, total,sub
        Account account = new Account(table,listDishO);
        Payment payment = new Payment();
        payment.setAmount(total);

        Invoice invoice = new Invoice(propina,(float)iva,total,restaurant,date,
                profile,currency,payment,account);


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
        txtName.setText(restaurant.getName());
        //Direccion del Restaurant
        txtDir.setText(restaurant.getAddress());
        //Numero de la Factura
        //El numero de la factura deberia ser autogenerado
        txtNum.setText("001");
        //Fecha y hora
        txtDate.setText(formattedDate);
        //Cedula del Cliente o ssn
        txtCiRif.setText(profile.getPerson().getSsn());
        //Nombre del cliente
        txtClient.setText(profile.getPerson().getName());
        //Subtotal
        txtMontoSub.setText(String.valueOf(sub));
        txtMonSub.setText(currency.getSymbol());
        //Iva
        txtMontoIva.setText(String.valueOf(iva));
        txtMonIva.setText(currency.getSymbol());
        //Total
        txtMontoTota.setText(String.valueOf(totaltotal));
        txtMonTota.setText(currency.getSymbol());
        //Propina
        txtMontoPro.setText(String.valueOf(propina));
        txtMonPro.setText(currency.getSymbol());

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
