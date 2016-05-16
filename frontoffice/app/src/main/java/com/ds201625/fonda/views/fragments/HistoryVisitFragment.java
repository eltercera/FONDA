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
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.data_access.services.ProfileService;
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
    private List<Invoice> p;


    //ATRIBUTOS DE PRUEBA

    ArrayList<RestaurantCategory> listCategory = new ArrayList<>();
    ArrayList<Restaurant> listRestaurant = new ArrayList<>();
    ArrayList<Invoice> listInvoice = new ArrayList<>();
    String  date = "12/10/2015";
    Date datepayment;

    // SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    //categorias prueba
    RestaurantCategory category1 = new RestaurantCategory("Romantico");
    RestaurantCategory category2 = new RestaurantCategory("Casual");
    RestaurantCategory category3 = new RestaurantCategory("Italiano");
    RestaurantCategory category4 = new RestaurantCategory("Americano");
    //restaurantes prueba
    Restaurant restaurant1 = new Restaurant("The dining room", "La Castellana", category2);
    Restaurant restaurant2 = new Restaurant("Mogi Mirin", "Los Dos Caminos", category1);
    Restaurant restaurant3 = new Restaurant("Gordo & Magro", "La California", category3);
    Restaurant restaurant4 = new Restaurant("La Casona", "Parque Central", category3);
    Restaurant restaurant5 = new Restaurant("Tony's", "El Rosal", category4);

    Profile profile = new Profile(1, "Adriana");

    //facturas prueba
    Invoice  invoice1 = new Invoice(200,600,800,restaurant1,datepayment, profile);
    Invoice  invoice2 = new Invoice(300,600,800,restaurant2,datepayment, profile);
    Invoice  invoice3 = new Invoice(200,600,800,restaurant3,datepayment, profile);
    Invoice  invoice4 = new Invoice(200,600,800,restaurant4,datepayment, profile);
    Invoice  invoice5 = new Invoice(200,600,800,restaurant3,datepayment, profile);
  //  Invoice  invoice6 = new Invoice(200,600,800,restaurant3,datepayment, profile);
   // Invoice  invoice7 = new Invoice(200,600,800,restaurant4,datepayment, profile);
   // Invoice  invoice8 = new Invoice(200,600,800,restaurant4,datepayment, profile);
    //Invoice  invoice9 = new Invoice(200,600,800,restaurant5,datepayment, profile);
    //Invoice  invoice10 = new Invoice(200,600,800,restaurant5,datepayment,profile);

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

    /*    int idPerson = 1;
        HistoryVisitsRestaurantService ps = FondaServiceFactory.getInstance().getHistoryVisitsService();
        p=ps.getHistoryVisits();
        for (int i = 0; i< p.size(); i ++){
            System.out.println("mamalooo  "+p.get(i).getTax());
            String newstring = new SimpleDateFormat("yyyy-MM-dd").format(p.get(i).getDate());
            System.out.println("mamalooo1  "+newstring);
        }*/




        //lista factura prueba
        listInvoice.add(invoice1);
        listInvoice.add(invoice2);
        listInvoice.add(invoice3);
        listInvoice.add(invoice4);
        listInvoice.add(invoice5);
      //  listInvoice.add(invoice6);
       // listInvoice.add(invoice7);
        //listInvoice.add(invoice8);
        //listInvoice.add(invoice9);
        //listInvoice.add(invoice10);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) { createGroupList();
      View layout =  (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        expListView = (ExpandableListView) layout.findViewById(R.id.restaurant_list);
        final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(), groupList,collectionVisits, shortDescription,location, dates);
        expListView.setAdapter(expListAdapter);


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

    private ArrayList<Invoice> pruebaMetodo(int idPersona) {

        ArrayList<Invoice> lista = new ArrayList<>();

        Iterator iterator = listInvoice.listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            int idProfile = invoice.getProfile().getId();
            if (idProfile == idPersona) {
                lista.add(invoice);
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
        Iterator iterator = pruebaMetodo(1).listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            String nameRestaurant = invoice.getRestaurant().getName();
            groupList.add(nameRestaurant);
        }
        }

    private void createCollection() {
        // preparing detailRestaurant for collection(child)
        collectionVisits = new LinkedHashMap<String, List<String>>();
        HistoryVisitsRestaurantService ps = FondaServiceFactory.getInstance().getHistoryVisitsService();
        p=ps.getHistoryVisits();
        Iterator iterator = p.listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            String nameRestaurant = invoice.getRestaurant().getName();
            String addresRestaurant = invoice.getRestaurant().getAddress();
            String categoryRestaurant = invoice.getRestaurant().getRestaurantCategory().getNameCategory();
            float tax = invoice.getTax();
            float tip= invoice.getTip();
            float totalPayment = invoice.getTotal();
            String datePayment = new SimpleDateFormat("yyyy-MM-dd").format(invoice.getDate());
            String name= invoice.getProfile().getProfileName();
            String[] data1 = {"Nombre: "+name, "Restaurant :"+nameRestaurant,"Direccion: "
                    +addresRestaurant,"Categoria: "+categoryRestaurant,"Fecha: "+datePayment,"Propina: "
                    +tip,"I.V.A: "+tax,"Monto Cancelado: "+totalPayment};

            for (String listName : groupList) {
                if (listName.equals(nameRestaurant)) {
                    loadChild(data1);
                    collectionVisits.put(listName, childList);
                }
            }
        }

    }

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
