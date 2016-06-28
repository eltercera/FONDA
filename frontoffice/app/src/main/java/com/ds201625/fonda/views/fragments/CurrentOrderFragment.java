package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.views.contracts.LogicCurrentOrderView;
import com.ds201625.fonda.views.contracts.LogicCurrentOrderViewPresenter;
import com.ds201625.fonda.logic.Commands.OrderCommands.LogicCurrentOrderCommand;
import com.ds201625.fonda.views.presenters.LogicCurrentOrderPresenter;
import com.ds201625.fonda.views.adapters.OrderViewItemList;
import java.util.List;

/**
 * Clase Fragment que muestra la orden actual realizada por el cliente
 */
public class CurrentOrderFragment extends BaseFragment implements
        LogicCurrentOrderView{

    /**
     * String que indica la clase al logger
     */
    private String TAG = "CurrentOrderFragment";
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
    private LogicCurrentOrderCommand logicCurrentOrder;

    private LogicCurrentOrderViewPresenter presenter;
    /**
     * Metodo que se ejecuta al instanciar el fragment
     * @param savedInstanceState Bundle que define el estado de la instancia
     */
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreate");
        super.onCreate(savedInstanceState);
        orderList = new OrderViewItemList(getContext());
        presenter = new LogicCurrentOrderPresenter(this);
    }


    /**
     * Metodo que crea la vista de la orden actual
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d(TAG,"Ha entrado en onCreateView");
        //Indicar el layout que va a usar el fragment
        View layout = inflater.inflate(R.layout.fragment_current_order,container,false);
        list=(ListView)layout.findViewById(R.id.lvOrderList);

        try{
            listDishO = getOrderSW();
            orderList = new OrderViewItemList(getContext());
            if(listDishO != null)
                orderList.addAll(listDishO);
            list.setAdapter(orderList);
        }
        catch(NullPointerException e){
            Log.e(TAG,"Error al iniciar ordenes",e);
        }

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
    @Override
    public List<DishOrder> getOrderSW(){
        List<DishOrder> listDishOWS;
        logicCurrentOrder = new LogicCurrentOrderCommand();
        Log.d(TAG,"Ha ingresado a getOrderSW");
        try {
            //Llamo al comando de requireLogedCommensalCommand
            presenter.findLoggedComensal();
//            listDishOWS = logicCurrentOrder.getCurrentOrderSW();
//            for (int i = 0; i < listDishOWS.size(); i++) {
//                System.out.println("Descripcion Plato:  " + listDishOWS.get(i).getDish().getDescription());
//            }
//            return listDishOWS;
            //Llamo al comando de allFavoriteRestaurantCommand
            listDishOWS = presenter.findAllDishOrder();
            return listDishOWS;
        } catch (NullPointerException nu) {
            Log.e(TAG, "Error en getOrderSW al obtener la orden", nu);
        } catch (Exception e) {
            System.out.println("Error en la Conexión");
        }
        Log.d(TAG,"Ha finalizado getOrderSWgetOrderSW");
        return null;
    }
}