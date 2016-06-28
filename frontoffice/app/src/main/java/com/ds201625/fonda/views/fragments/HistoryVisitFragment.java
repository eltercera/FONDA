package com.ds201625.fonda.views.fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.ListView;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.HistoryVisitsRestaurantService;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsView;
import com.ds201625.fonda.views.contracts.LogicHistoryVisitsViewPresenter;
import com.ds201625.fonda.logic.LogicHistoryVisits;
import com.ds201625.fonda.views.presenters.LogicHistoryVisitsPresenter;
import com.ds201625.fonda.views.adapters.ExpandableListAdapter;
import com.ds201625.fonda.views.adapters.InvoiceViewItemList;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/**
 * Clase de Fragment que maneja el historial de visitas al restaurant
 */
public class HistoryVisitFragment extends BaseFragment implements LogicHistoryVisitsView{
    /**
     * String que indica la clase al logger
     */
    private String TAG = "HistoryVisitFragment";
    /**
     * Lista
     */
    private ListView list;
    /**
     * Vista de lista
     */
    private InvoiceViewItemList invoiceList;

    private LogicHistoryVisitsViewPresenter presenter;
    /**
     * Lista de String que contiene el nombre del restaurante
      */
    private List<String> groupNameRestaurant;

    /**
     * Lista de String que contiene la categoria del restaurante
     */
    private List<String> groupCategoryRestaurant;

    /**
     * Lista de String que contiene la direccion del restaurante
     */
    private List<String> groupAddressRestaurant;

    /**
     * Lista de String que contiene la direccion del restaurante
     */
    private List<String> groupLogoRestaurant;


    /**
     * Lista de String que contiene el pago del restaurante
     */
    private List<String> groupDatePaymentRestaurant;

    /**
     * Lista de String que contiene el grupo de hijos de la lista expandible
     */
    private List<String> childList;

    /**
     * Lista de String que contiene la lista de facturas asociadas a un restaurante
     */
    private List<Invoice> listInvoice;

    /**
     * Lista de String que contiene el historial de pagos del restaurant
     */
    private Map<String, List<String>> collectionVisits;

    /**
     * Vista de lista expandible
     */
    private ExpandableListView expListView;

    /**
     *  Servicio de historial de visitas de un restaurante
     */
    private HistoryVisitsRestaurantService histoyVisitsRestaurantService;

    /**
     *  Iterador
     */
    private Iterator iterator;

    /**
     *  atributo de tipo LogicHistoryVisits
     */
    LogicHistoryVisits historyvisits;

    /**
     * Metodo que se ejecuta al instanciar el fragment
     * @param savedInstanceState Bundle que define el estado de la instancia
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        super.onCreate(savedInstanceState);
        invoiceList = new InvoiceViewItemList(getContext());
        presenter = new LogicHistoryVisitsPresenter(this);
        Log.d(TAG,"Ha salido en onCreate");
    }

    /**
     * Metodo que crea la vista del historial de visitas o pagos del restaurant
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) { createGroupList();
        Log.d(TAG,"Ha entrado en onCreateView");
        View layout = (inflater.inflate(R.layout.fragment_historial_visitas,container,false));
        createCollection();

        try{
            listInvoice = getHistoryVisitsSW();
           // invoiceList = new InvoiceViewItemList(getContext());
            expListView = (ExpandableListView) layout.findViewById(R.id.restaurant_list);
            final ExpandableListAdapter expListAdapter = new ExpandableListAdapter(
                getContext(), groupNameRestaurant,collectionVisits, groupCategoryRestaurant,
                groupAddressRestaurant, groupLogoRestaurant, groupDatePaymentRestaurant);
             expListView.setAdapter(expListAdapter);

            expListView.setOnChildClickListener(new ExpandableListView.OnChildClickListener() {

            /** Metodo para cargar la vista del detalle de historial de pagos
             * Metodo
             * @param parent        Lista expandible que define la vista de la lista
             * @param v             Vista que define la vista de el grupo hijo
             * @param groupPosition Entero que define la posicion del grupo Padre
             * @param childPosition Entero que define la posicion del grupo hijo
             * @param id            Long que define el id del grupo
             * @return Variable boolean
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
        } catch(NullPointerException e){
            Log.e(TAG,"Error al iniciar ordenes",e);
        }
        return layout;
    }

    /**
     * Metodo que consulta el historial de pagos en el Web Service
     */
    private void createGroupList() {

        try {
            historyvisits = new LogicHistoryVisits();
            listInvoice = historyvisits.apihistoryVisits();

            groupNameRestaurant = new ArrayList<String>();
            groupAddressRestaurant = new ArrayList<String>();
            groupCategoryRestaurant = new ArrayList<String>();
            groupLogoRestaurant = new ArrayList<String>();
            groupDatePaymentRestaurant = new ArrayList<String>();

            iterator = listInvoice.listIterator();
            while (iterator.hasNext()) {
                Invoice invoice = (Invoice) iterator.next();
                String nameRestaurant = invoice.getRestaurant().getName();
                String addresRestaurant = invoice.getRestaurant().getAddress();
                String categoryRestaurant = invoice.getRestaurant().getRestaurantCategory().getName();
                String logoRestaurant = invoice.getRestaurant().getLogo();
                Date date = invoice.getDate();
                String datePayment = new SimpleDateFormat("dd-MM-yyyy").format(date);
                groupNameRestaurant.add(nameRestaurant);
                groupAddressRestaurant.add(addresRestaurant);
                groupCategoryRestaurant.add(categoryRestaurant);
                groupDatePaymentRestaurant.add(datePayment);
                groupLogoRestaurant.add(logoRestaurant);
            }
        } catch (RestClientException e) {
            e.printStackTrace();
        } catch (Exception e) {
            System.out.println("Error en la Conexión");
        }
    }

    /**
     * Metodo que maneja el detalle del historial del pago del restaurant
     */
    private void createCollection() {
        try{
            collectionVisits = new LinkedHashMap<String, List<String>>();
            iterator = listInvoice.listIterator();
            while (iterator.hasNext()) {
                Invoice invoice = (Invoice) iterator.next();
                String nameRestaurant = invoice.getRestaurant().getName();
                String addresRestaurant = invoice.getRestaurant().getAddress();
                String categoryRestaurant = invoice.getRestaurant().getRestaurantCategory().getName();
                float tax = invoice.getTax();
                float tip = invoice.getTip();
                float totalPayment = invoice.getTotal();
                String datePayment = new SimpleDateFormat("dd-MM-yyyy").format(invoice.getDate());
                String name = invoice.getProfile().getProfileName();
                String[] dataDetailHistoryVisits= {"Nombre: "+name, "Restaurant :"+nameRestaurant,"Direccion: "
                        +addresRestaurant,"Categoria: "+categoryRestaurant,"Fecha: "+datePayment,"Propina: "
                        +tip,"I.V.A: "+tax,"Monto Cancelado: "+totalPayment};

                for (String listName : groupNameRestaurant) {
                    if (listName.equals(nameRestaurant)) {
                        loadChild(dataDetailHistoryVisits);
                        collectionVisits.put(listName, childList);
                    }
                }
            }
        }
        catch (NullPointerException e){
            System.out.println("No es posible realizar la conexión con el Web Server ");
        }

        catch (Exception e){
            System.out.println("Error en la Conexión");
        }
    }

    /**
     * Metodo que carga a una lista el detalle del historial de pagos del restaurant
     * @param restaurantDetails Array de String que define los datos del detalle del pago
     */
    private void loadChild(String[] restaurantDetails) {
        childList = new ArrayList<String>();
        for (String model : restaurantDetails) {
            childList.add(model);
        }
    }

    @Override
    public List<Invoice> getHistoryVisitsSW() {
        List<Invoice> listHistorySW;
        Log.d(TAG,"Ha ingresado a getHistoryVisitsSW");
        try {
            //Llamo al comando de requireLogedCommensalCommand
            presenter.findLoggedComensal();
            listHistorySW = presenter.findAllHistoryVisits();
            return listHistorySW;
        } catch (NullPointerException nu) {
            Log.e(TAG, "Error en getHistoryVisitsSW al obtener los pagos", nu);
        } catch (Exception e) {
            System.out.println("Error en la Conexión");
        }
        Log.d(TAG,"Ha finalizado getHistoryVisitsSW");
        return null;
    }
}
