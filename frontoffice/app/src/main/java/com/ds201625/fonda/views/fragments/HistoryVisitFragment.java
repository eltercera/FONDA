package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.domains.RestaurantCategory;
import com.ds201625.fonda.views.adapters.ExpandableListAdapter;

import java.lang.reflect.Array;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Clase de Prueba para mostar el uso de Fragments
 */
public class HistoryVisitFragment extends BaseFragment {
    List<String> groupList;
    List<String> childList;
    Map<String, List<String>> collectionVisits;
    ExpandableListView expListView;

    //ATRIBUTOS DE PRUEBA

    ArrayList<RestaurantCategory> listCategory = new ArrayList<>();
    ArrayList<Restaurant> listRestaurant = new ArrayList<>();
    ArrayList<Invoice> listInvoice = new ArrayList<>();
    String  date = "12/10/2015";
    Date datepayment;

    // SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    SimpleDateFormat formato = new SimpleDateFormat("yyyyMMdd");

    //categorias prueba
    RestaurantCategory category1 = new RestaurantCategory("Romantico");
    RestaurantCategory category2 = new RestaurantCategory("Casual");
    RestaurantCategory category3 = new RestaurantCategory("Italiano");
    RestaurantCategory category4 = new RestaurantCategory("Americano");
    //restaurantes prueba
    Restaurant restaurant1 = new Restaurant("The dining room", "a", category2);
    Restaurant restaurant2 = new Restaurant("The dining room", "a", category3);
    Restaurant restaurant3 = new Restaurant("The dining room", "a", category4);
    Restaurant restaurant4 = new Restaurant("The dining room", "a", category4);
    Restaurant restaurant5 = new Restaurant("The dining room", "a", category1);

    Profile profile = new Profile(1);

    //facturas prueba
    Invoice  invoice1 = new Invoice(200,600,800,restaurant1,datepayment, profile);
    Invoice  invoice2 = new Invoice(200,600,800,restaurant1,datepayment, profile);
    Invoice  invoice3 = new Invoice(200,600,800,restaurant2,datepayment, profile);
    Invoice  invoice4 = new Invoice(200,600,800,restaurant2,datepayment, profile);
    Invoice  invoice5 = new Invoice(200,600,800,restaurant3,datepayment, profile);
    Invoice  invoice6 = new Invoice(200,600,800,restaurant3,datepayment, profile);
    Invoice  invoice7 = new Invoice(200,600,800,restaurant4,datepayment, profile);
    Invoice  invoice8 = new Invoice(200,600,800,restaurant4,datepayment, profile);
    Invoice  invoice9 = new Invoice(200,600,800,restaurant5,datepayment, profile);
    Invoice  invoice10 = new Invoice(200,600,800,restaurant5,datepayment,profile);


    //FIN ATRIBUTOS DE PRUEBA

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
       //lista categoria prueba
        listCategory.add(category1);
        listCategory.add(category2);
        listCategory.add(category3);
        listCategory.add(category4);

        //lista restaurant prueba
        listRestaurant.add(restaurant1);
        listRestaurant.add(restaurant2);
        listRestaurant.add(restaurant3);
        listRestaurant.add(restaurant4);
        listRestaurant.add(restaurant5);

        //lista factura prueba
        listInvoice.add(invoice1);
        listInvoice.add(invoice2);
        listInvoice.add(invoice3);
        listInvoice.add(invoice4);
        listInvoice.add(invoice5);
        listInvoice.add(invoice6);
        listInvoice.add(invoice7);
        listInvoice.add(invoice8);
        listInvoice.add(invoice9);
        listInvoice.add(invoice10);

       try {
        datepayment = formato.parse(date);
        } catch (ParseException e) {
            e.printStackTrace();
        }


    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) { createGroupList();
      View layout =  (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        expListView = (ExpandableListView) layout.findViewById(R.id.restaurant_list);
        final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(), groupList,collectionVisits, names, shortDescription,location, dates);
        expListView.setAdapter(expListAdapter);

        //setGroupIndicatorToRight();

        expListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            public boolean onChildClick(ExpandableListView parent, View v,
                                        int groupPosition, int childPosition, long id) {
                final String selected = (String) expListAdapter.getChild(
                        groupPosition, childPosition);
                Toast.makeText(getContext(), selected, Toast.LENGTH_LONG)
                        .show();

                return true;
            }
        });
        return layout;

    }

    private void LlenarObjetoRestaurantCategory() {

        for (int i = 0; i< listInvoice.size(); i++) {
            System.out.println("esto es " + listInvoice.get(i).getRestaurant().getName());
        }

    }

    private ArrayList<Invoice> pruebaMetodo(int idPersona) {

        ArrayList<Invoice> lista = new ArrayList<>();

        Iterator iterator = listInvoice.listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            int idProfile = invoice.getProfile().getId();
            if (idProfile == idPersona) {
                lista.add(invoice);
                System.out.println("mamando dos veces" + invoice.getDate());
            }
        }
        return lista;
    }

     String[] dates ={
            "12/01/16",
            "12/01/16",
            "12/01/16",
            "12/01/16",
            "12/01/16"};
    String[]  names = {
            "The dining room",
            "Mogi Mirin",
            "Gordo & Magro",
            "La Casona",
            "Tony's"} ;
    String[] location = {
            "La castellana",
            "Los dos caminos",
            "La California",
            "Parque central",
            "El Rosal"} ;
    String[] shortDescription = {
            "Casual",
            "Romantico",
            "Italiano",
            "Italiano",
            "Americano"} ;


    private void createGroupList() {
       groupList = new ArrayList<String>();

            for (String model : names)
                groupList.add(model);
        }

    private void createCollection() {
        // preparing laptops collection(child)

        Iterator iterator = pruebaMetodo(1).listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            String nombre = invoice.getRestaurant().getName();
            String direccion = invoice.getRestaurant().getAddress();
            RestaurantCategory categoria = invoice.getRestaurant().getRestaurantCategory();
            String[] data1 = {"RESTAURANT :"+nombre,"Direccion: "+direccion};
            collectionVisits = new LinkedHashMap<String, List<String>>();

            for (String listName : groupList) {
                if (listName.equals("The dining room"))
                    loadChild(data1);
                collectionVisits.put(listName, childList);
            }
        }

    }


      //  String[] data2 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
      //  String[] data3 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
        //String[] data4 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };
      //  String[] data5 = {"RESTAURANT: EL TINAJERO","Direccion: las Mercedes","Fecha: 12/10/2015", "Hora: 3:00 Pm","Sub-Total:5.000 Bs","Total:7.000 Bs","Propina:800 Bs","Forma de Pago: tarjeta de credito","Banco: Mercantil" };



    private void loadChild(String[] restaurantDetails) {
        childList = new ArrayList<String>();
        for (String model : restaurantDetails)
            childList.add(model);
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
