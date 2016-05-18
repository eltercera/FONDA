package com.ds201625.fonda.views.fragments;

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
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.views.adapters.ExpandableListAdapter;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Clase de Fragment que maneja el Historial de Visitas al Restaurant
 */
public class HistoryVisitFragment extends BaseFragment {
    private List<String> groupNameRestaurant;
    private List<String> groupCategoryRestaurant;
    private List<String> groupAddressRestaurant;
    private List<String> groupDatePaymentRestaurant;
    private List<String> childList;
    private Map<String, List<String>> collectionVisits;
    private ExpandableListView expListView;
    private HistoryVisitsRestaurantService histoyVisitsRestaurantService;
    private List<Invoice> listInvoice;

    /**
     * Metodo que se ejecuta al instanciar el Fragment
     * @param savedInstanceState
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    /**
     * Metodo que crea la vista del historial de visitas o pagos al restaurant
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) { createGroupList();
      View layout =  (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        expListView = (ExpandableListView) layout.findViewById(R.id.restaurant_list);
        final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(),  groupNameRestaurant,collectionVisits,  groupCategoryRestaurant,
                groupAddressRestaurant, groupDatePaymentRestaurant);
        expListView.setAdapter(expListAdapter);

        expListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            /** Metodo para cargar la vista del detalle de historial de pagos
             * Metodo
             * @param parent
             * @param v
             * @param groupPosition
             * @param childPosition
             * @param id
             * @return variable boolean
             */
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

    /**
     * Metodo que consulta el historial de pagos en el Web Service
     */
    private void createGroupList() {
        try{
            histoyVisitsRestaurantService = FondaServiceFactory.getInstance().getHistoryVisitsService();
            listInvoice= histoyVisitsRestaurantService.getHistoryVisits();
        }catch (Exception e){
            System.out.println("asd");
        }
        catch (ExceptionInInitializerError e){

        }
        groupNameRestaurant = new ArrayList<String>();
        groupAddressRestaurant= new ArrayList<String>();
        groupCategoryRestaurant= new ArrayList<String>();
        groupDatePaymentRestaurant = new ArrayList<String>();
        Iterator iterator = listInvoice.listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            String nameRestaurant = invoice.getRestaurant().getName();
            String addresRestaurant = invoice.getRestaurant().getAddress();
            String categoryRestaurant = invoice.getRestaurant().getRestaurantCategory().getNameCategory();
            Date datePayment = invoice.getDate();
            String newstring = new SimpleDateFormat("dd-MM-yyyy").format(datePayment);
            groupNameRestaurant.add(nameRestaurant);
            groupAddressRestaurant.add(addresRestaurant);
            groupCategoryRestaurant.add(categoryRestaurant);
            groupDatePaymentRestaurant.add(newstring );
        }
        }

    /**
     * Metodo que maneja el detalle del historial del pago del Restaurant
     */
    private void createCollection() {
        // preparing detailRestaurant for collection(child)
        collectionVisits = new LinkedHashMap<String, List<String>>();
        Iterator iterator = listInvoice.listIterator();
        while (iterator.hasNext()) {
            Invoice invoice = (Invoice) iterator.next();
            String nameRestaurant = invoice.getRestaurant().getName();
            String addresRestaurant = invoice.getRestaurant().getAddress();
            String categoryRestaurant = invoice.getRestaurant().getRestaurantCategory().getNameCategory();
            float tax = invoice.getTax();
            float tip= invoice.getTip();
            float totalPayment = invoice.getTotal();
            String datePayment = new SimpleDateFormat("dd-MM-yyyy").format(invoice.getDate());
            String name= invoice.getProfile().getProfileName();
            String[] data1 = {"Nombre: "+name, "Restaurant :"+nameRestaurant,"Direccion: "
                    +addresRestaurant,"Categoria: "+categoryRestaurant,"Fecha: "+datePayment,"Propina: "
                    +tip,"I.V.A: "+tax,"Monto Cancelado: "+totalPayment};

            for (String listName : groupNameRestaurant) {
                if (listName.equals(nameRestaurant)) {
                    loadChild(data1);
                    collectionVisits.put(listName, childList);
                }
            }
        }
    }

    /**
     * Metodo que carga a una lista el detalle del historial de pagos del restaurant
     * @param restaurantDetails
     */
    private void loadChild(String[] restaurantDetails) {
        childList = new ArrayList<String>();
        for (String model : restaurantDetails)
            childList.add(model);
    }
}
