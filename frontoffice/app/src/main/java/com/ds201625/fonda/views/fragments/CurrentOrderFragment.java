package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.logic.LogicCurrentOrder;
import com.ds201625.fonda.views.adapters.OrderViewItemList;
import java.util.List;

/**
 * Clase Fragment que muestra la orden actual realizada por el cliente
 */
public class CurrentOrderFragment extends BaseFragment {


    /**
     * Lista
     */
    private ListView list;

    /**
     * Vista de lista
     */
    private OrderViewItemList orderList;

    /**
     * Lista de DishOrder que contiene la lista de platos ordenados
     */
    private List<DishOrder> listDishO;

    /**
     *  Atributo de tipo LogicCurrentOrder que controla el acceso al WS
     */
    private LogicCurrentOrder logicCurrentOrder;

    /**
     * Metodo que se ejecuta al instanciar el fragment
     * @param savedInstanceState Bundle que define el estado de la instancia
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }


    /**
     * Metodo que crea la vista de la orden actual
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View layout = inflater.inflate(R.layout.fragment_current_order,container,false);

        listDishO = getListSW();
        orderList = new OrderViewItemList(getContext());
        if(listDishO != null)
            orderList.addAll(listDishO);

        list=(ListView)layout.findViewById(R.id.lvOrderList);
        list.setAdapter(orderList);

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

    /**
     * Metodo que obtiene los elementos del WS
     */
    public List<DishOrder> getListSW(){
        List<DishOrder> listDishOWS;
        logicCurrentOrder = new LogicCurrentOrder();
        try {
            listDishOWS = logicCurrentOrder.getCurrentOrderSW().getListDishOrder();
            for (int i = 0; i < listDishOWS.size(); i++) {
                System.out.println("Descripcion Plato:  " + listDishOWS.get(i).getDish().getDescription());
            }
            return listDishOWS;
        }
        catch (RestClientException e) {
            e.printStackTrace();
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